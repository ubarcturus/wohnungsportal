using System;
using System.ComponentModel.DataAnnotations;

namespace Wohnungsportal.Models
{
    public class Reservation
    {
		public int Id { get; set; }

		[DataType(DataType.Date)] 
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")] 
		public DateTime Start { get; set; }

		[DataType(DataType.Date)] 
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")] 
		public DateTime End { get; set; }

		public string IdentityUserId { get; set; }

		public int ApartmentId { get; set; }
	}
}