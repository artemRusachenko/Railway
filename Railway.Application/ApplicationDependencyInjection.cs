using Microsoft.Extensions.DependencyInjection;
using Railway.Application.Services;
using Railway.Application.Services.Seats;
using Railway.Application.Services.Stations;
using Railway.Application.Services.Tickets;
using Railway.Application.Services.Trains;

namespace Railway.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRouteSercvice, RouteService>();
            services.AddScoped<ITicketsService, TicketsService>();
            services.AddScoped<IStationService, StationService>();
            services.AddScoped<ITrainService, TrainService>();
            services.AddScoped<ISeatService, SeatService>();
            return services;
        }
    }
}
