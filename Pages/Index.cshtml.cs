using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Wohnungsportal.Data;
using Wohnungsportal.Models;

namespace Wohnungsportal.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

		public List<Apartment> Apartments { get; set; }

        public void OnGet()
        {
            Apartments = new List<Apartment>();
            Apartments = _context.Apartment.Where(_ => true).ToList();
        }
    }
}