using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetflixCocktails.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static NetflixCocktails.Helper.Helper;

//TESTKOMMENTAR AV OLIVIA
//LISA TESTAR
namespace NetflixCocktails.Controllers
{
    public class HomeController : Controller
    {

        CocktailAPI _api = new CocktailAPI();


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        } */


        public async Task<IActionResult> Index()
        {

           Cocktail cocktail = new Cocktail();

            
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("http://www.thecocktaildb.com/api/json/v1/1/random.php");

            if (res.IsSuccessStatusCode) {
            

                string responseBody = await res.Content.ReadAsStringAsync();

                JObject googleSearch = JObject.Parse(responseBody);

                IList<JToken> results = googleSearch["drinks"].Children().ToList();

                IList<Cocktail> searchResults = new List<Cocktail>();
                foreach (JToken result in results)
                {
                    Cocktail cocktail1 = result.ToObject<Cocktail>();
                    searchResults.Add(cocktail1);
                }


                List<String> ingredients = new List<string>();
                List<String> measurements = new List<string>();
                List<String> content = new List<string>();
                ingredients.Add(searchResults[0].strIngredient1);
                ingredients.Add(searchResults[0].strIngredient2);
                ingredients.Add(searchResults[0].strIngredient3);
                ingredients.Add(searchResults[0].strIngredient4);
                ingredients.Add(searchResults[0].strIngredient5);
                ingredients.Add(searchResults[0].strIngredient6);
                ingredients.Add(searchResults[0].strIngredient7);
                ingredients.Add(searchResults[0].strIngredient8);
                ingredients.Add(searchResults[0].strIngredient9);
                ingredients.Add(searchResults[0].strIngredient10);
                ingredients.Add(searchResults[0].strIngredient11);
                ingredients.Add(searchResults[0].strIngredient12);
                ingredients.Add(searchResults[0].strIngredient13);
                ingredients.Add(searchResults[0].strIngredient14);
                ingredients.Add(searchResults[0].strIngredient15);

                measurements.Add(searchResults[0].strMeasure1);
                measurements.Add(searchResults[0].strMeasure2);
                measurements.Add(searchResults[0].strMeasure3);
                measurements.Add(searchResults[0].strMeasure4);
                measurements.Add(searchResults[0].strMeasure5);
                measurements.Add(searchResults[0].strMeasure6);
                measurements.Add(searchResults[0].strMeasure7);
                measurements.Add(searchResults[0].strMeasure8);
                measurements.Add(searchResults[0].strMeasure9);
                measurements.Add(searchResults[0].strMeasure10);
                measurements.Add(searchResults[0].strMeasure11);
                measurements.Add(searchResults[0].strMeasure12);
                measurements.Add(searchResults[0].strMeasure13);
                measurements.Add(searchResults[0].strMeasure14);
                measurements.Add(searchResults[0].strMeasure15);



                for (int i=0; i<15; i++)
                {
                    string ingredient = ingredients[i];
                    string measurement = measurements[i];
                    if(ingredient != null || measurement != null)
                    {
                        string line = measurement + " " + ingredient;
                        content.Add(line);

                    }
               
                }

                searchResults[0].ingredientList = content;


                return View(searchResults[0]);

            }

            ViewBag.error = "null";

            return View();


            
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
