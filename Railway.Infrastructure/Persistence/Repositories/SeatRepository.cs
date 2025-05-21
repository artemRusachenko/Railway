using Microsoft.EntityFrameworkCore;
using Railway.Domain.Seats;
using Railway.Shared.DTOs;

namespace Railway.Infrastructure.Persistence.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly AppDbContext _context;
        public SeatRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<SeatInfo>> GetSeatsByCarriageId(int trainId, int carriageId, int departureStationId, int arrivalStationId)
        {
            // 1. Получаем RouteId по поезду
            var routeId = await _context.Trains
                .Where(t => t.Id == trainId)
                .Select(t => t.RouteId)
                .FirstOrDefaultAsync();

            if (routeId == 0)
                return new List<SeatInfo>();

            // 2. Получаем последовательные номера станций отправления и прибытия
            var depSeq = await _context.RouteStations
                .Where(rs => rs.RouteId == routeId && rs.StationId == departureStationId)
                .Select(rs => rs.SequenceNumber)
                .FirstOrDefaultAsync();

            var arrSeq = await _context.RouteStations
                .Where(rs => rs.RouteId == routeId && rs.StationId == arrivalStationId)
                .Select(rs => rs.SequenceNumber)
                .FirstOrDefaultAsync();

            if (depSeq == 0 || arrSeq == 0)
                return new List<SeatInfo>();

            // 3. Получаем все места в вагоне
            var seats = await _context.Seats
                .Where(s => s.CarriageId == carriageId)
                .Select(s => new SeatInfo
                {
                    SeatId = s.Id,
                    SeatNumber = s.SeatNumber ?? 0,
                    IsFree = true
                })
                .ToListAsync();

            // 4. Получаем Id занятых мест, которые пересекают маршрут
            var occupiedSeatIds = await _context.Tickets
            .Where(t =>
                // связываем с местом
                _context.Seats.Any(s => s.Id == t.SeatId &&
                    // связываем с вагоном
                    _context.Carriages.Any(c => c.Id == s.CarriageId && c.TrainId == trainId)
                )
            )
            .Join(_context.Seats, t => t.SeatId, s => s.Id, (t, s) => new { Ticket = t, Seat = s })
            .Join(_context.Carriages, ts => ts.Seat.CarriageId, c => c.Id, (ts, c) => new { ts.Ticket, ts.Seat, Carriage = c })
            .Join(_context.Trains, tsc => tsc.Carriage.TrainId, tr => tr.Id, (tsc, tr) => new { tsc.Ticket, tsc.Seat, tsc.Carriage, Train = tr })
            .Join(_context.RouteStations, tsc_tr => new { StationId = tsc_tr.Ticket.DepartureStationId, RouteId = tsc_tr.Train.RouteId }, rs => new { rs.StationId, rs.RouteId }, (tsc_tr, rs) => new { tsc_tr.Ticket, tsc_tr.Seat, tsc_tr.Carriage, tsc_tr.Train, RsDep = rs })
            .Join(_context.RouteStations, x => new { StationId = x.Ticket.ArrivalStationId, RouteId = x.Train.RouteId }, rs => new { rs.StationId, rs.RouteId }, (x, rs) => new { x.Ticket, x.Seat, x.Carriage, x.Train, x.RsDep, RsArr = rs })
            .Where(x => x.Train.Id == trainId
                && x.Carriage.Id == carriageId
                && !(x.RsArr.SequenceNumber <= depSeq || x.RsDep.SequenceNumber >= arrSeq)
            )
            .Select(x => x.Seat.Id)
            .Distinct()
            .ToListAsync();

            // 5. Обновляем статус мест
            foreach (var seat in seats)
            {
                if (occupiedSeatIds.Contains(seat.SeatId))
                    seat.IsFree = false;
            }

            return seats;
        }
    }
}
