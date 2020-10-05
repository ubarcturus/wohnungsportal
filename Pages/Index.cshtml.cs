using System;
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
		private readonly ApplicationDbContext _context;
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public List<Apartment> Apartments { get; private set; }

		public void OnGet()
		{
			try
			{
				Apartments = _context.Apartment.ToList();
			}
			catch (Exception exception)
			{
				_logger.LogWarning($"Och ne. {exception.Message}");
			}
		}
	}
}