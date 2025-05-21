namespace Railway.Domain.Tickets
{
    public interface ITicketRepository
    {
        public Task<List<GetPassengerTicketsSPResult>> GetPessangerTickets(int passengerId);
        public Task<bool> AddTicket(int passengerId, int seatId, int depatureStationId, int arrivalStationId);
    }
}
