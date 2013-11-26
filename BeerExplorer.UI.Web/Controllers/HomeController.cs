using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BeerExplorer.DataLayer.Entities;
using BeerExplorer.DataLayer.Repositories;

namespace BeerExplorer.UI.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		
		public JsonResult __getBreweryList()
		{
			// BreweryRepository repo = new BreweryRepository();
			// List<Brewery> breweryList = repo.GetBreweryList().ToList();

			// For the initial screen we only need the name and coordinates of the brewery to mark them. So select and send only the required data
			// string data = Newtonsoft.Json.JsonConvert.SerializeObject(breweryList.Where(b => b.Geo != null).Select(b => new { b.Id, b.Name, b.Geo }));

			string data = "[{\"Id\":\"21st_amendment_brewery_cafe\",\"Name\":\"21st Amendment Brewery Cafe\",\"Geo\":{\"accuracy\":\"ROOFTOP\",\"lat\":37.7825,\"lng\":-122.393}}]";
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult __getBreweryDetails(string id)
		{
			BreweryRepository repo = new BreweryRepository();
			Brewery brewery = repo.GetBrewery(id);

			BeerRepository beerRepo = new BeerRepository();
			List<Beer> beerList = beerRepo.GetBeerByBrewery(id).ToList();
			brewery.BeerList = beerList;

			string data = Newtonsoft.Json.JsonConvert.SerializeObject(brewery);
			
			return Json(data, JsonRequestBehavior.AllowGet);
		}

	}
}
