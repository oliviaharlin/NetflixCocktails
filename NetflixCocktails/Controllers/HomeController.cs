using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        MovieAPI _api2 = new MovieAPI();


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


        public IActionResult Index()
        {
            string s = HttpContext.Session.GetString("session");
            var result = JsonConvert.DeserializeObject<RandomMovieCocktail>(s);


            return View(result);


            
        }




        public async Task<IActionResult> Result()
        {

            //MOVIE
            Movie movie = new Movie();
            HttpClient client = _api2.Initial();
            HttpResponseMessage res = await client.GetAsync("https://k2maan-moviehut.herokuapp.com/api/random");

            if (res.IsSuccessStatusCode)
            {

                var result1 = res.Content.ReadAsStringAsync().Result;

                movie = JsonConvert.DeserializeObject<Movie>(result1);

            }

        



            //COCK-TAIL
            Cocktail cocktail = new Cocktail();


            HttpClient client2 = _api.Initial();
            HttpResponseMessage res2 = await client2.GetAsync("http://www.thecocktaildb.com/api/json/v1/1/random.php");

            if (res2.IsSuccessStatusCode)
            {


                string responseBody = await res2.Content.ReadAsStringAsync();

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



                for (int i = 0; i < 15; i++)
                {
                    string ingredient = ingredients[i];
                    string measurement = measurements[i];
                    if (ingredient != null || measurement != null)
                    {
                        string line = measurement + " " + ingredient;
                        content.Add(line);

                    }

                }

                searchResults[0].ingredientList = content;


                RandomMovieCocktail randomMovieCocktail = new RandomMovieCocktail()
                {
                    ingredientList = searchResults[0].ingredientList,
                    strDrink = searchResults[0].strDrink,
                    strCategory = searchResults[0].strCategory,
                    strAlcoholic = searchResults[0].strAlcoholic,
                    strGlass = searchResults[0].strGlass,
                    strInstructions = searchResults[0].strInstructions,
                    strDrinkThumb = searchResults[0].strDrinkThumb,

                    name = movie.name,
                    releaseYear = movie.releaseYear,
                    runtime = movie.runtime,
                    genre = movie.genre,
                    imdbRating = movie.imdbRating,
                    overview = movie.overview,
                    director = movie.director



                };

                var obj = JsonConvert.SerializeObject(randomMovieCocktail);
                HttpContext.Session.SetString("session", obj);


                return View(randomMovieCocktail);
            }


            return View();

        }

        public IActionResult Privacy()
        {
            string s = HttpContext.Session.GetString("session");
            var result = JsonConvert.DeserializeObject<RandomMovieCocktail>(s);


            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
