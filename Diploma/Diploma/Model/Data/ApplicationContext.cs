using Microsoft.EntityFrameworkCore;

namespace Diploma.Model.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Cabinet> Cabinets { get; set;}
        public DbSet<Reception> Receptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PC-232-07\SQLEXPRESS;Initial Catalog=Hospital;Persist Security Info=True;User ID=U-19;Password=19$RPEe");
        }
    }
}
