using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wohnungsportal.Models;

namespace Wohnungsportal.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Apartment> Apartment { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
    }
}
