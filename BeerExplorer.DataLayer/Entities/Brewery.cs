using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace BeerExplorer.DataLayer.Entities
{
	[Serializable]
	public class Brewery
	{
		[JsonProperty("type")]
		public string Type 
		{
			get
			{
				return BeerExplorer.DataLayer.Constants.TYPE_BREWERY;
			}
		}

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("state")]
		public string State { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("website")]
		public string Website { get; set; }

		[JsonProperty("updated")]
		public DateTime Updated { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("address")]
		public List<string> AddresssList { get; set; }

		[JsonProperty("geo")]
		public Geo Geo { get; set; }

		[JsonProperty("beerList")]
		public List<Beer> BeerList { get; set; }
	}
}
