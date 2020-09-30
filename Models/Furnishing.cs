using System.ComponentModel.DataAnnotations;

namespace Wohnungsportal.Models
{
	public class Furnishing
	{
		public int Id { get; set; }

		[Display(Name = "Küche")] public byte Kitchen { get; set; }

		[Display(Name = "WLAN")] public byte Wlan { get; set; }
	}
}