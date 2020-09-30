using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wohnungsportal.Models
{
	public class Reservations
	{
		public int Id { get; set; }
		[DataType(DataType.Date)]
		public DateTime Start { get; set; }
		[DataType(DataType.Date)]
		public DateTime End { get; set; }
		public int Fk_UserId { get; set; }
		public int Fk_ApartmentId { get; set; }
	}
}
