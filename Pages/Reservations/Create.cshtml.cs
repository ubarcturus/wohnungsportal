using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wohnungsportal.Data;
using Wohnungsportal.Models;

namespace Wohnungsportal.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly Wohnungsportal.Data.ApplicationDbContext _context;
        private UserManager<IdentityUser> UserManager;

        public CreateModel(Wohnungsportal.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        public IActionResult OnGet(int id)
        {
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {

	        bool reserved = _context.Reservation.Any(r => r.ApartmentId == id && Reservation.Start <= r.End && Reservation.End >= r.Start);

	        if (reserved)
	        {
		        ModelState.AddModelError("", "Diese Wohnung ist in Ihrem angegebenen Zeitraum bereits reserviert.");
		        return Page();
	        }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Reservation.ApartmentId = id;
            Reservation.IdentityUserId = UserManager.GetUserId(User);

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
