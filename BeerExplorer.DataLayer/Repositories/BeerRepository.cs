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
	public class BeerRepository
	{
		/// <summary>
		/// Create a new beer object
		/// </summary>
		/// <param name="beer"></param>
		/// <returns></returns>
		public bool InsertBeer(Beer beer)
		{
			bool result = false;
			
			using (CouchbaseClient client = new CouchbaseClient())
			{
				result = client.StoreJson(StoreMode.Add, beer.Name, beer);
			}
			
			return result;
		}

		/// <summary>
		/// Update an existing beer
		/// </summary>
		/// <param name="beer"></param>
		/// <returns></returns>
		public bool UpdateBeer(Beer beer)
		{
			bool result = false;

			using (CouchbaseClient client = new CouchbaseClient())
			{
				result = client.StoreJson(StoreMode.Set, beer.Name, beer);
			}

			return result;
		}

		/// <summary>
		/// Add new or update existing beer object
		/// </summary>
		/// <param name="beer"></param>
		/// <returns></returns>
		public bool InsertOrUpdateBeer(Beer beer)
		{
			bool result = false;

			using (CouchbaseClient client = new CouchbaseClient())
			{
				result = client.StoreJson(StoreMode.Replace, beer.Name, beer);
			}

			return result;
		}

		/// <summary>
		/// Retrieve the beer object by name
		/// </summary>
		/// <param name="beerName"></param>
		/// <returns></returns>
		public Beer GetBeer(string beerName)
		{
			using (CouchbaseClient client = new CouchbaseClient())
			{
				Beer beer = client.GetJson<Beer>(beerName);
				return beer;
			}
		}

		/// <summary>
		/// Get a list of beers brewed by a specific brewery
		/// </summary>
		/// <param name="breweryName"></param>
		/// <returns></returns>
		public IList<Beer> GetBeerByBrewery(string breweryId)
		{
			List<Beer> resultSet = new List<Beer>();
			Beer beer = null;

			using (CouchbaseClient client = new CouchbaseClient())
			{
				var view = client.GetView("beer", "by_brewery_id")
								 .StartKey<string>(breweryId)
								 .EndKey<string>(breweryId);

				foreach (var row in view)
				{
					beer = client.GetJson<Beer>(row.ItemId);
					resultSet.Add(beer);
				}
			}

			return resultSet;
		}
	}
}
