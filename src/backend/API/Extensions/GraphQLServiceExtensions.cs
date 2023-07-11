using API.Resolvers.Queries;
using HotChocolate.Data;

namespace API.Extensions
{
    public static class GraphQLServiceExtensions
    {
        public static IServiceCollection AddGraphQLServices(
            this IServiceCollection services, IConfiguration config
        )
        {
            services.AddHttpContextAccessor();

            services.AddGraphQLServer()
            .AddQueryType<UserDetailQueires>()
            .AddProjections()
            .AddFiltering()
            .AddSorting();

            return services;
        }
    }
}