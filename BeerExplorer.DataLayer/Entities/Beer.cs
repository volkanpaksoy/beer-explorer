using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Couchbase.Extensions;
using Newtonsoft.Json;

namespace BeerExplorer.DataLayer.Entities
{
	[Serializable]
	public class Beer
	{
		[JsonProperty("type")]
		public string Type
		{
			get
			{
				return BeerExplorer.DataLayer.Constants.TYPE_BEER;
			}
		}
		
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("style")]
		public string Style { get; set; }

		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("brewery_id")]
		public string Brewer { get; set; }

		[JsonProperty("abv")]
		public double ABV { get; set; }

		[JsonProperty("srm")]
		public double SRM { get; set; }

		[JsonProperty("upc")]
		public double UPC { get; set; }

		[JsonProperty("ibu")]
		public double IBU { get; set; }

		[JsonProperty("updated")]
		public DateTime Updated { get; set; }
	}
}
