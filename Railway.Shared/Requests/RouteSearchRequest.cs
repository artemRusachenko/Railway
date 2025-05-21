namespace Railway.Shared.Requests
{
    public class RouteSearchRequest
    {
        public int DepStation { get; set; }
        public int ArrStation { get; set; }
        public DateTime DepatureDate { get; set; }
    }
}
