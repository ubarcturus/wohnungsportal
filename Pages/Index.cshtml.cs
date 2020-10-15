using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wohnungsportal.Data;
using Wohnungsportal.Models;

namespace Wohnungsportal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Apartment> Apartments { get; private set; }
        public List<Reservation> Reservations { get; private set; }

        public async Task<PageResult> OnGetAsync()
        {
            try
            {
                Apartments = await _context.Apartment.ToListAsync();
                Reservations = await _context.Reservation.ToListAsync();

                foreach (var reservation in Reservations)
                {
	                foreach (var apartment in Apartments)
	                {
		                if (apartment.Id == reservation.ApartmentId)
		                {
			                if (reservation.Start <= DateTime.Now.Date && reservation.End >= DateTime.Now.Date)
			                {
				                apartment.IsReserved = true;
			                }
		                }
	                }
                }
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"Och ne. {exception.Message}");
            }

            return Page();
        }
    }
}