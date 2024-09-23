using Microsoft.EntityFrameworkCore;

namespace MSSD_725_Week_4_Project.Models
{
    public class DogReservationContext : DbContext
    {
        public DogReservationContext(DbContextOptions<DogReservationContext> options)
        : base(options)
        {
        }

        public DbSet<DogReservation> DogReservations { get; set; } = null!;
    }
}
