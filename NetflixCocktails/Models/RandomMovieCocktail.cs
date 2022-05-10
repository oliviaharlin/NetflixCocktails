using System;
using System.Collections.Generic;

namespace NetflixCocktails.Models
{
    public class RandomMovieCocktail
    {

        //COCK-TAIL
        public string strDrink { get; set; }
        public string strCategory { get; set; }      
        public string strAlcoholic { get; set; }
        public string strGlass { get; set; }
        public string strInstructions { get; set; }
        public string strDrinkThumb { get; set; }
        public List<String> ingredientList { get; set; }
       
        //MOVIE
        public string name { get; set; }
        public int releaseYear { get; set; }
        public string runtime { get; set; }
        public string genre { get; set; }
        public double imdbRating { get; set; }
        public string overview { get; set; }
        public string director { get; set; }
    }
}
