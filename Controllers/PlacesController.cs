using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController
    {
        static readonly HttpClient client = new HttpClient();

        // GET api/places/Beijing
        [HttpGet("{placename}")]
        public ActionResult<string> Get(string placename)
        {
            
            return getDetails(placename).Result;
        }
        static async Task<string> getDetails(string name){
            string apiKey = "AIzaSyDkpHKaeWZF3aA8iKZCtEpkiHtXG_by6_4";
            string baseUrl = "https://maps.googleapis.com/maps/api/";
            string findPlace = "place/findplacefromtext/json?inputtype=textquery&fields=photos,formatted_address,name,rating,opening_hours,geometry&input=";
            
            string responseBody = await client.GetStringAsync(new Uri(string.Format("{1}{2}{3}&key={0}",apiKey,baseUrl,findPlace,name)));
            return responseBody;
        }
    }
}