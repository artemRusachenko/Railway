using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Railway.Domain.Passengers;
using Railway.Domain.Routes;
using Railway.Domain.Seats;
using Railway.Domain.Stations;
using Railway.Domain.Tickets;
using Railway.Domain.Trains;
using Railway.Infrastructure.Persistence;
using Railway.Infrastructure.Persistence.Repositories;

namespace Railway.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITicketRepository, TIcketRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IStationRepository, StationRepository>();
            services.AddScoped<ITrainRepository, TrainRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IPassengerRepository, PassengerRepository>();

            return services;
        }
    }
}
