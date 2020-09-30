using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Wohnungsportal.Models;

namespace Wohnungsportal.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public List<Apartment> Apartments { get; set; }

		public void OnGet()
		{
			Apartments = new List<Apartment>();
		}
	}
}