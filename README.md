# BeerExplorer
============

Toy project using Couchbase's beer-sample database


## Pre-requisites
============

* Couchbase with beer-sample database
* (Optional) Google Maps API Key: You can obtain one freely at https://code.google.com/apis/console/
Apparently as of V3 we can use Maps API without a key but if you want to monitor your usage it may be helpful to use a key. 
 

## Usage
============

To use the application on your system, update the web.config file with your Maps API key and Couchbase URL. By default, it assumes Couchbase is installed on localhost and comes with a blank key for the map. 

Also, you have to create a new view which is used to retrieve the beers of a brewery:

**Name:** by\_brewery\_id

**Map function:** 

	function(doc, meta) {
		if (doc.type == "beer" && doc.brewery_id) {
  			emit(doc.brewery_id, meta.id);
  		}
	}


The rest of the database is intact. I don't want to upload a backup copy of it as I'm not sure if we are allowed to distribute it. So there is a bit of a manual work here.


## Screenshots
===========

Main page:

![](https://s3-eu-west-1.amazonaws.com/vp-projects-img/beerexplorer/Main-Page.png)


Brewery Selection (Displays all beers brewed on the left panel):

![](https://s3-eu-west-1.amazonaws.com/vp-projects-img/beerexplorer/Brewery-Selected.png)



