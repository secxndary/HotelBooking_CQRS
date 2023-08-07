using Entities.Models;
using Entities.Models.UserModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Repository.Configuration.Identity;
namespace Repository;

public class RepositoryContext : IdentityDbContext<UserIdentity>
{
    public RepositoryContext(DbContextOptions options) 
        : base (options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfiguration(new RoomTypeConfiguration())
            .ApplyConfiguration(new RoomConfiguration())
            .ApplyConfiguration(new HotelConfiguration())
            .ApplyConfiguration(new ReservationConfiguration())
            .ApplyConfiguration(new FeedbackConfiguration())
            .ApplyConfiguration(new RoomPhotoConfiguration())
            .ApplyConfiguration(new HotelPhotoConfiguration())
            .ApplyConfiguration(new RoleIdentityConfiguration())
            .ApplyConfiguration(new UserIdentityConfiguration())
            .ApplyConfiguration(new UserIRolesConfiguration());
    }

    public DbSet<RoomType>? RoomTypes { get; set; }
    public DbSet<RoomPhoto>? RoomPhotos { get; set; }
    public DbSet<HotelPhoto>? HotelPhotos { get; set; }
    public DbSet<Hotel>? Hotels { get; set; }
    public DbSet<Room>? Rooms { get; set; }
    public DbSet<Reservation>? Reservations { get; set; }
    public DbSet<Feedback>? Feedbacks { get; set; }
}