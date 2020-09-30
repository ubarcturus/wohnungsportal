﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Wohnungsportal.Models
{
	public class Apartments
	{
		public int Id { get; set; }
		[Display(Name = "Anzahl Zimmer")]
		public int NRooms { get; set; }
		[Display(Name = "Ausstattung")]
		public int Furnishing { get; set; }
		[Display(Name = "Preis")]
		public decimal Price { get; set; }
		public byte Status { get; set; }
		[Display(Name = "Ort")]
		public string Location { get; set; }
		public Blob Picture { get; set; }
	}
}