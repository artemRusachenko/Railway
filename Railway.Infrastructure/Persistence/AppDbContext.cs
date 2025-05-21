using Microsoft.EntityFrameworkCore;
using Railway.Domain.Carriages;
using Railway.Domain.CarriageTypes;
using Railway.Domain.Passengers;
using Railway.Domain.Routes;
using Railway.Domain.RouteStations;
using Railway.Domain.Seats;
using Railway.Domain.Stations;
using Railway.Domain.Tickets;
using Railway.Domain.Trains;
namespace Railway.Infrastructure.Persistence;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carriage> Carriages { get; set; }

    public virtual DbSet<CarriageType> CarriageTypes { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<RouteStation> RouteStations { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    public virtual DbSet<RouteBetweenStationSPResult> RouteBetweenStations { get; set; }
    public virtual DbSet<GetPassengerTicketsSPResult> PassengerTickets { get; set; }
    public virtual DbSet<GetStationScheduleForDaySPResult> StationsScheduleForDay { get; set; }
    public virtual DbSet<GetStationsForRouteSPResult> StationsForRoute { get; set; }
    public virtual DbSet<GetTrainCarriagesInfoSPResult> TrainCarriages { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carriage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carriage__3214EC0796305BA3");

            entity.ToTable("Carriage");

            entity.HasOne(d => d.CarriageType).WithMany(p => p.Carriages)
                .HasForeignKey(d => d.CarriageTypeId)
                .HasConstraintName("FK__Carriage__Carria__4AB81AF0");

            entity.HasOne(d => d.Train).WithMany(p => p.Carriages)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Carriage__TrainI__49C3F6B7");
        });

        modelBuilder.Entity<CarriageType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carriage__3214EC07627BB7AF");

            entity.ToTable("CarriageType");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Passenge__88915F90034CCB8F");

            entity.ToTable("Passenger");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Route__3214EC078C9077A1");

            entity.ToTable("Route");

            entity.Property(e => e.RouteName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RouteNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RouteStation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RouteSta__3214EC0793FE8046");

            entity.ToTable("RouteStation");

            entity.HasOne(d => d.Route).WithMany(p => p.RouteStations)
                .HasForeignKey(d => d.RouteId)
                .HasConstraintName("FK__RouteStat__Route__440B1D61");

            entity.HasOne(d => d.Station).WithMany(p => p.RouteStations)
                .HasForeignKey(d => d.StationId)
                .HasConstraintName("FK__RouteStat__Stati__44FF419A");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seat__3214EC071A7290D2");

            entity.ToTable("Seat");

            entity.HasOne(d => d.Carriage).WithMany(p => p.Seats)
                .HasForeignKey(d => d.CarriageId)
                .HasConstraintName("FK__Seat__CarriageId__4D94879B");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Station__3214EC07FD9F3A28");

            entity.ToTable("Station");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3214EC07BEAD8557");

            entity.ToTable("Ticket");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.ArrivalStation).WithMany(p => p.TicketArrivalStations)
                .HasForeignKey(d => d.ArrivalStationId)
                .HasConstraintName("FK__Ticket__ArrivalS__5535A963");

            entity.HasOne(d => d.DepartureStation).WithMany(p => p.TicketDepartureStations)
                .HasForeignKey(d => d.DepartureStationId)
                .HasConstraintName("FK__Ticket__Departur__5441852A");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PassengerId)
                .HasConstraintName("FK__Ticket__Passenge__534D60F1");

            entity.HasOne(d => d.Seat).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeatId)
                .HasConstraintName("FK__Ticket__SeatId__52593CB8");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Train__3214EC07AF69D308");

            entity.ToTable("Train");

            entity.Property(e => e.ArrivalDate).HasColumnType("date");
            entity.Property(e => e.DepatureDate).HasColumnType("date");

            entity.HasOne(d => d.Route).WithMany(p => p.Trains)
                .HasForeignKey(d => d.RouteId)
                .HasConstraintName("FK__Train__RouteId__3F466844");
        });

        modelBuilder.Entity<RouteBetweenStationSPResult>()
               .HasNoKey()
               .ToView(null); 
        
        modelBuilder.Entity<GetPassengerTicketsSPResult>()
               .HasNoKey()
               .ToView(null);

        modelBuilder.Entity<GetStationScheduleForDaySPResult>()
           .HasNoKey()
           .ToView(null);

        modelBuilder.Entity<GetStationsForRouteSPResult>()
           .HasNoKey()
           .ToView(null);

        modelBuilder.Entity<GetTrainCarriagesInfoSPResult>()
           .HasNoKey()
           .ToView(null);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
