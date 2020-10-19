using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Wohnungsportal.Data;
using Wohnungsportal.Models;

namespace Wohnungsportal.Pages
{
	public class DetailsModel : PageModel
	{
		private readonly ApplicationDbContext _context;

		public DetailsModel(ApplicationDbContext context)
		{
			_context = context;
		}

		public Apartment Apartment { get; set; }
		public List<Reservation> Reservation { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Apartment = await _context.Apartment.FirstOrDefaultAsync(apartment => apartment.Id == id);

			

			Reservation =
				await _context.Reservation.Where(reservation => reservation.ApartmentId == Apartment.Id && reservation.End >= DateTime.Now.Date).ToListAsync();

			if (Apartment == null)
			{
				return NotFound();
			}


			return Page();
		}
	}
}