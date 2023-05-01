using Application.v1.DTOs;
using Application.v1.Interfaces;
using Application.v1.Services.MovieService.Query;
using Application.v1.Services.PersonService.Query;
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

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IRequestHandler<GetPersonByIdQuery, ResponseMessage>, GetPersonByIdQueryHandler>();

            return services;
        }
    }
}