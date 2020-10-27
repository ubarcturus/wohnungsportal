using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wohnungsportal.Data;
using Wohnungsportal.Helpers;
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
				                break;
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

        public void OnGetDisplay(int minRooms, int maxRooms, string location, bool kitchen, bool wlan, float minPrice, float maxPrice)
        {


	        var apartments = (from a in _context.Apartment
		        select a);

	        if (minRooms != 0 && maxRooms != 0)
	        {
		        apartments = apartments.Where(a => a.NRooms >= minRooms && a.NRooms <= maxRooms);
	        }

	        if (location != null)
	        {
		        apartments = apartments.Where(a => a.Location.Contains(location));
	        }

	        if (kitchen)
	        {
		        apartments = apartments.Where(a => a.Kitchen == true);
	        }

	        if (wlan)
	        {
		        apartments = apartments.Where(a => a.Wlan == true);
	        }

	        if (minPrice != 0 && maxPrice != 0)
	        {
		        apartments = apartments.Where(a => a.Price >= minPrice && a.Price <= maxPrice);
	        }

	        /*apartments = apartments.Where(a => a.NRooms >= minPrice && a.NRooms <= maxPrice &&
	                                           a.Location.Contains(location) && a.Wlan == wlan &&
	                                           a.Kitchen == kitchen &&
	                                           a.Price >= minPrice && a.Price <= maxPrice);*/

	        Apartments = apartments.ToList();

        }
    }
}