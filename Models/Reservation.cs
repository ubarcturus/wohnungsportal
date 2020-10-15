﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Wohnungsportal.Models
{
    public class Reservation
    {
		public int Id { get; set; }

		[DataType(DataType.Date)] public DateTime Start { get; set; }

		[DataType(DataType.Date)] public DateTime End { get; set; }

		public string IdentityUserId { get; set; }

		public int ApartmentId { get; set; }
	}
}