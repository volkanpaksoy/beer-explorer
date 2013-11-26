using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeerExplorer.DataLayer.Entities;
using Couchbase;
using Couchbase.Extensions;
using Enyim.Caching.Memcached;

namespace BeerExplorer.DataLayer.Repositories
{
	public class BreweryRepository
	{
		/// <summary>
		/// Create a new brewery object
		/// </summary>
		/// <param name="brewery"></param>
		/// <returns></returns>
		public bool InsertBrewery(Brewery brewery)
		{
			bool result = false;
			
			using (CouchbaseClient client = new CouchbaseClient())
			{
				result = client.StoreJson(StoreMode.Add, brewery.Name, brewery);
			}
			
			return result;
		}

		/// <summary>
		/// Update an existing brewery
		/// </summary>
		/// <param name="brewery"></param>
		/// <returns></returns>
		public bool UpdateBrewery(Brewery brewery)
		{
			bool result = false;

			using (CouchbaseClient client = new CouchbaseClient())
			{
				result = client.StoreJson(StoreMode.Set, brewery.Name, brewery);
			}

			return result;
		}

		/// <summary>
		/// Add new or update existing beer object
		/// </summary>
		/// <param name="beer"></param>
		/// <returns></returns>
		public bool InsertOrUpdateBrewery(Brewery brewery)
		{
			bool result = false;

			using (CouchbaseClient client = new CouchbaseClient())
			{
				result = client.StoreJson(StoreMode.Replace, brewery.Name, brewery);
			}

			return result;
		}

		/// <summary>
		/// Retrieve the brewery object by key
		/// </summary>
		/// <param name="breweryId"></param>
		/// <returns></returns>
		public Brewery GetBrewery(string breweryId)
		{
			using (CouchbaseClient client = new CouchbaseClient())
			{
				Brewery brewery = client.GetJson<Brewery>(breweryId);
				return brewery;
			}
		}

		/// <summary>
		/// Get all breweries from view
		/// </summary>
		/// <returns></returns>
		public IList<Brewery> GetBreweryList()
		{
			List<Brewery> resultSet = new List<Brewery>();
			Brewery brewery = null;

			using (CouchbaseClient client = new CouchbaseClient())
			{
				var view = client.GetView("beer", "brewery");

				foreach (var row in view)
				{
					brewery = client.GetJson<Brewery>(row.ItemId);
					resultSet.Add(brewery);
				}
			}

			return resultSet;
		}
	}
}
