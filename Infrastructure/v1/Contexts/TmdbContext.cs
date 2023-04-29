using Microsoft.Extensions.Configuration;
using TMDbLib.Client;

namespace Infrastructure.v1.Contexts
{
    public class TmdbContext
    {
        public readonly TMDbClient client;
        public TmdbContext(IConfiguration config)
        {
            client = new TMDbClient(apiKey: config["TmdbApiKey"]);
        }
    }
}