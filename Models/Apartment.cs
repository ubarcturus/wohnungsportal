using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Wohnungsportal.Models
{
	public class Apartments
	{
		public int Id { get; set; }

		[Display(Name = "Anzahl Zimmer")] public int NRooms { get; set; }

		[Display(Name = "Ausstattung")] public int Furnishing { get; set; }

		[Display(Name = "Preis")] public float Price { get; set; }

		[Display(Name = "Ort")] public string Location { get; set; }

		[Display(Name = "Bild")] public Blob Picture { get; set; }

		[Display(Name = "Küche")] public bool Kitchen { get; set; }

		[Display(Name = "WLAN")] public bool Wlan { get; set; }
	}
}