using Microsoft.Extensions.Configuration;
using TMDbLib.Client;

namespace Infrastructure.v1.Contexts
{
    public class TmdbContext
    {
        private readonly TMDbClient _client;
        public TmdbContext(IConfiguration config)
        {
            _client = new TMDbClient(apiKey: config["TmdbApiKey"]);
        }
    }
}