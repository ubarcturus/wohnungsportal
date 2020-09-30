using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Wohnungsportal.Models
{
	public class Furnishing
	{
		public int FurnishingId { get; set; }
		[Display(Name = "Küche")]
		public byte Kitchen { get; set; }
		public byte Internet { get; set; }
	}
}
