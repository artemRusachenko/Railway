namespace Railway.Domain.Routes
{
    public interface IRouteRepository
    {
        public Task<ICollection<RouteBetweenStationSPResult>> GetRoutesBetweenStations(int depStation, int arrStation, DateTime depaturedate);
    }
}
