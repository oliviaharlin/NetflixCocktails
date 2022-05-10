using System;
using System.Net.Http;

namespace NetflixCocktails.Helper
{
    public class Helper
    {

            public class CocktailAPI {

                public HttpClient Initial() {
                    var client = new HttpClient();

                    string server = "http://www.thecocktaildb.com";
                    string relativePath = "api/json/v1/1/random.php";

                    Uri serverUri = new Uri(server);
                    Uri relativeUri = new Uri(relativePath, UriKind.Relative);
                    Uri fullUri = new Uri(serverUri, relativeUri);

                    client.BaseAddress = fullUri;
                    return client;
                }
            }

    }
    
}
