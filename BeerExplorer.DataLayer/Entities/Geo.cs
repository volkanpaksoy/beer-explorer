using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace BeerExplorer.DataLayer.Entities
{
	[Serializable]
	public class Geo
	{
		[JsonProperty("accuracy")]
		public string Accuracy { get; set; }

		[JsonProperty("lat")]
		public double Latitude { get; set; }

		[JsonProperty("lng")]
		public double Longitude { get; set; }
	}
}
