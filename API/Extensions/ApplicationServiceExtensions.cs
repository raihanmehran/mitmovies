using Application.v1.DTOs;
using Application.v1.Interfaces;
using Application.v1.Services.MovieService.Query;
using Application.v1.Services.PersonService.Query;
using Application.v1.Services.TrendingMoviesService.Query;
using Application.v1.Services.TvShowService.Query;
using Infrastructure.v1.Contexts;
using Infrastructure.v1.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration config
        )
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<TmdbContext>();

            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IRequestHandler<GetMovieByIdQuery, ResponseMessage>, GetMovieByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetMovieDetailByIdQuery, ResponseMessage>, GetMovieDetailByIdQueryHandler>();
            services.AddScoped<IRequestHandler<SearchMovieQuery, ResponseMessage>, SearchMovieQueryHandler>();
            services.AddScoped<IRequestHandler<GetUpcomingMoviesQuery, ResponseMessage>, GetUpcomingMoviesQueryHandler>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IRequestHandler<GetPersonByIdQuery, ResponseMessage>, GetPersonByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetPopularPeopleQuery, ResponseMessage>, GetPopularPeopleQueryHandler>();

            services.AddScoped<ITrendingMoviesRepository, TrendingMoviesRepository>();
            services.AddScoped<IRequestHandler<GetTodayTrendingMoviesQuery, ResponseMessage>, GetTodayTrendingMoviesQueryHandler>();
            services.AddScoped<IRequestHandler<GetThisWeekTrendingMoviesQuery, ResponseMessage>, GetThisWeekTrendingMoviesQueryHandler>();

            services.AddScoped<ITvShowsRepository, TvShowsRepository>();
            services.AddScoped<IRequestHandler<GetPopularTvShowsQuery, ResponseMessage>, GetPopularTvShowsQueryHandler>();

            return services;
        }
    }
}