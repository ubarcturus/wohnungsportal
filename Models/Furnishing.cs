using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Wohnungsportal.Models
{
	public class Furnishing
	{
		public int FurnishingId { get; set; }
		public byte Kitchen { get; set; }
		public byte Internet { get; set; }
	}
}
