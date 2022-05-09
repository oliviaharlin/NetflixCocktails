using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NetflixCocktails.Models
{
    [JsonObject()]
    public class Cocktail
    {

        [JsonProperty("strDrink")]
        public string strDrink { get; set; }

        [JsonProperty("strCategory")]
        public string strCategory { get; set; }

        [JsonProperty("strAlcoholic")]
        public string strAlcoholic { get; set; }

        [JsonProperty("strGlass")]
        public string strGlass { get; set; }

        [JsonProperty("strInstructions")]
        public string strInstructions { get; set; }

        [JsonProperty("strDrinkThumb")]
        public string strDrinkThumb { get; set; }

        [JsonProperty("strIngredient1")]
        public string strIngredient1 { get; set; }
        [JsonProperty("strIngredient2")]
        public string strIngredient2 { get; set; }
        [JsonProperty("strIngredient3")]
        public string strIngredient3 { get; set; }
        [JsonProperty("strIngredient4")]
        public string strIngredient4 { get; set; }
        [JsonProperty("strIngredient5")]
        public string strIngredient5 { get; set; }
        [JsonProperty("strIngredient6")]
        public string strIngredient6 { get; set; }
        [JsonProperty("strIngredient7")]
        public string strIngredient7 { get; set; }
        [JsonProperty("strIngredient8")]
        public string strIngredient8 { get; set; }
        [JsonProperty("strIngredient9")]
        public string strIngredient9 { get; set; }
        [JsonProperty("strIngredient10")]
        public string strIngredient10 { get; set; }
        [JsonProperty("strIngredient11")]
        public string strIngredient11 { get; set; }
        [JsonProperty("strIngredient12")]
        public string strIngredient12 { get; set; }
        [JsonProperty("strIngredient13")]
        public string strIngredient13 { get; set; }
        [JsonProperty("strIngredient14")]
        public string strIngredient14 { get; set; }
        [JsonProperty("strIngredient15")]
        public string strIngredient15 { get; set; }


        [JsonProperty("strMeasure1")]
        public string strMeasure1 { get; set; }
        [JsonProperty("strMeasure2")]
        public string strMeasure2 { get; set; }
        [JsonProperty("strMeasure3")]
        public string strMeasure3 { get; set; }
        [JsonProperty("strMeasure4")]
        public string strMeasure4 { get; set; }
        [JsonProperty("strMeasure5")]
        public string strMeasure5 { get; set; }
        [JsonProperty("strMeasure6")]
        public string strMeasure6 { get; set; }
        [JsonProperty("strMeasure7")]
        public string strMeasure7 { get; set; }
        [JsonProperty("strMeasure8")]
        public string strMeasure8 { get; set; }
        [JsonProperty("strMeasure9")]
        public string strMeasure9 { get; set; }
        [JsonProperty("strMeasure10")]
        public string strMeasure10 { get; set; }
        [JsonProperty("strMeasure11")]
        public string strMeasure11 { get; set; }
        [JsonProperty("strMeasure12")]
        public string strMeasure12 { get; set; }
        [JsonProperty("strMeasure13")]
        public string strMeasure13 { get; set; }
        [JsonProperty("strMeasure14")]
        public string strMeasure14 { get; set; }
        [JsonProperty("strMeasure15")]
        public string strMeasure15 { get; set; }

        public List<String> ingredientList { get; set; }



    }
}
