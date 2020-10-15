using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wohnungsportal.Models
{
	public class Apartment
	{
		public int Id { get; set; }

		[Display(Name = "Anzahl Zimmer")] public int NRooms { get; set; }

		[Display(Name = "Beschreibung")] public string Description { get; set; }

		[Display(Name = "Preis pro Nacht")] public float Price { get; set; }

		[Display(Name = "Ort")] public string Location { get; set; }

		[Display(Name = "Bild")] public string PictureName { get; set; }

		[Display(Name = "Küche")] public bool Kitchen { get; set; }

		[Display(Name = "WLAN")] public bool Wlan { get; set; }

		[NotMapped] public bool IsReserved { get; set; }
	}
}