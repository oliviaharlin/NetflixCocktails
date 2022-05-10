using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NetflixCocktails.Models
{
    [JsonObject()]
    public class Movie
    {

        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("releaseYear")]
        public int releaseYear { get; set; }

        [JsonProperty("certificate")]
        public string certificate { get; set; }

        [JsonProperty("runtime")]
        public string runtime { get; set; }

        [JsonProperty("genre")]
        public string genre { get; set; }

        [JsonProperty("imdbRating")]
        public double imdbRating { get; set; }

        [JsonProperty("overview")]
        public string overview { get; set; }

        [JsonProperty("metaScore")]
        public int metaScore{ get; set; }

        [JsonProperty("director")]
        public string director { get; set; }

    }
}