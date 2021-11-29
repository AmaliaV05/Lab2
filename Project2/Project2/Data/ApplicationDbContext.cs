using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project2.Models;

namespace Project2.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }        
        public DbSet<Film> Films { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<UserRole> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>()
                .HasIndex(p => p.Title)
                .IsUnique()
                .HasFilter(null);

            modelBuilder.Entity<UserRole>()
               .HasData(new UserRole { Name = UserRole.ROLE_USER, NormalizedName = UserRole.ROLE_USER.ToUpper() },
                        new UserRole { Name = UserRole.ROLE_ADMIN, NormalizedName = UserRole.ROLE_ADMIN.ToUpper() });
        }
    }
}
