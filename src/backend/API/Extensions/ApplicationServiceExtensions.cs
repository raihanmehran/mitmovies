using API.Utils;
using Application.v1.DTOs;
using Application.v1.Interfaces;
using Application.v1.Services.AccountService.Command;
using Application.v1.Services.AccountService.Query;
using Application.v1.Services.AuthService.Command;
using Application.v1.Services.FavouriteMovieService.Command;
using Application.v1.Services.FavouriteMovieService.Query;
using Application.v1.Services.FavouritePersonService.Command;
using Application.v1.Services.FavouritePersonService.Query;
using Application.v1.Services.FavouriteTvShowService.Command;
using Application.v1.Services.FavouriteTvShowService.Query;
using Application.v1.Services.GenreService.Command;
using Application.v1.Services.GenreService.Query;
using Application.v1.Services.MovieService.Query;
using Application.v1.Services.PersonService.Query;
using Application.v1.Services.PhotoService.Command;
using Application.v1.Services.TokenService.Command;
using Application.v1.Services.TrendingMoviesService.Query;
using Application.v1.Services.TvShowService.Query;
using Application.v1.Services.UserGenreService.Command;
using Application.v1.Services.UserPhotoService.Command;
using Application.v1.Services.UserService.Command;
using Application.v1.Services.UserService.Query;
using Application.v1.Services.WatchedMovieService.Command;
using Application.v1.Services.WatchedMovieService.Query;
using Application.v1.Services.WatchedTvShowService.Command;
using Application.v1.Services.WatchedTvShowService.Query;
using Application.v1.Utils;
using Domain.v1.Entities;
using Domain.v1.Utils;
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
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<LogUserActivity>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRequestHandler<AuthenticateUserCommand, ResponseMessage>, AuthenticateUserCommandHandler>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRequestHandler<RegisterUserCommand, ResponseMessage>, RegisterUserCommandHandler>();
            services.AddScoped<IRequestHandler<GetUsersWithRoleQuery, ResponseMessage>, GetUsersWithRoleQueryHandler>();
            services.AddScoped<IRequestHandler<EditUserRolesCommand, ResponseMessage>, EditUserRolesCommandHandler>();

            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IRequestHandler<GetMovieByIdQuery, ResponseMessage>, GetMovieByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetMovieDetailByIdQuery, ResponseMessage>, GetMovieDetailByIdQueryHandler>();
            services.AddScoped<IRequestHandler<SearchMovieQuery, ResponseMessage>, SearchMovieQueryHandler>();
            services.AddScoped<IRequestHandler<GetUpcomingMoviesQuery, ResponseMessage>, GetUpcomingMoviesQueryHandler>();
            services.AddScoped<IRequestHandler<GetPopularMoviesQuery, ResponseMessage>, GetPopularMoviesQueryHandler>();
            services.AddScoped<IRequestHandler<GetTopRatedMoviesQuery, ResponseMessage>, GetTopRatedMoviesQueryHandler>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IRequestHandler<GetPersonByIdQuery, ResponseMessage>, GetPersonByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetPopularPeopleQuery, ResponseMessage>, GetPopularPeopleQueryHandler>();

            services.AddScoped<ITrendingMoviesRepository, TrendingMoviesRepository>();
            services.AddScoped<IRequestHandler<GetTodayTrendingMoviesQuery, ResponseMessage>, GetTodayTrendingMoviesQueryHandler>();
            services.AddScoped<IRequestHandler<GetThisWeekTrendingMoviesQuery, ResponseMessage>, GetThisWeekTrendingMoviesQueryHandler>();

            services.AddScoped<ITvShowsRepository, TvShowsRepository>();
            services.AddScoped<IRequestHandler<GetPopularTvShowsQuery, ResponseMessage>, GetPopularTvShowsQueryHandler>();
            services.AddScoped<IRequestHandler<GetTopRatedTvShowsQuery, ResponseMessage>, GetTopRatedTvShowsQueryHandler>();
            services.AddScoped<IRequestHandler<GetTvShowByIdQuery, ResponseMessage>, GetTvShowByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetTrendingTvShowsQuery, ResponseMessage>, GetTrendingTvShowsQueryHandler>();
            services.AddScoped<IRequestHandler<SearchTvShowsQuery, ResponseMessage>, SearchTvShowsQueryHandler>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRequestHandler<GetUserByUsernameQuery, AppUser>, GetUserByUsernameQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserByUserIdQuery, AppUser>, GetUserByUserIdQueryHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, ResponseMessage>, UpdateUserCommandHandler>();
            services.AddScoped<IRequestHandler<GetMemberByUserIdQuery, ResponseMessage>, GetMemberByUserIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetMembersQuery, PagedList<MemberDto>>, GetMembersQueryHandler>();

            services.AddScoped<IFavouriteMoviesRepository, FavouriteMoviesRepository>();
            services.AddScoped<IRequestHandler<AddMovieToFavouriteCommand, ResponseMessage>, AddMovieToFavouriteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveMovieFromFavouritesCommand, ResponseMessage>, RemoveMovieFromFavouritesCommandHandler>();
            services.AddScoped<IRequestHandler<GetFavouriteMoviesQuery, ResponseMessage>, GetFavouriteMoviesQueryHandler>();

            services.AddScoped<IFavouritePersonRepository, FavouritePersonRepository>();
            services.AddScoped<IRequestHandler<AddPersonToFavouriteCommand, ResponseMessage>, AddPersonToFavouriteCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePersonFromFavouriteCommand, ResponseMessage>, RemovePersonFromFavouriteCommandHandler>();
            services.AddScoped<IRequestHandler<GetFavouritePeopleQuery, ResponseMessage>, GetFavouritePeopleQueryHandler>();

            services.AddScoped<IFavouriteTvShowsRepository, FavouriteTvShowsRepository>();
            services.AddScoped<IRequestHandler<AddTvShowToFavouritesCommand, ResponseMessage>, AddTvShowToFavouritesCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveTvShowToFavouritesCommand, ResponseMessage>, RemoveTvShowToFavouritesCommandHandler>();
            services.AddScoped<IRequestHandler<GetFavouriteTvShowsQuery, ResponseMessage>, GetFavouriteTvShowsQueryHandler>();

            services.AddScoped<IWatchedMoviesRepository, WatchedMoviesRepository>();
            services.AddScoped<IRequestHandler<AddMovieToWatchedCommand, ResponseMessage>, AddMovieToWatchedCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveMovieFromWatchedCommand, ResponseMessage>, RemoveMovieFromWatchedCommandHandler>();
            services.AddScoped<IRequestHandler<GetWatchedMoviesQuery, ResponseMessage>, GetWatchedMoviesQueryHandler>();

            services.AddScoped<IWatchedTvShowsRepository, WatchedTvShowsRepository>();
            services.AddScoped<IRequestHandler<AddTvShowToWatchedCommand, ResponseMessage>, AddTvShowToWatchedCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveTvShowFromWatchedCommand, ResponseMessage>, RemoveTvShowFromWatchedCommandHandler>();
            services.AddScoped<IRequestHandler<GetWatchedTvShowsQuery, ResponseMessage>, GetWatchedTvShowsQueryHandler>();

            services.AddScoped<IGenresRepository, GenresRepository>();
            services.AddScoped<IRequestHandler<AddGenreCommand, ResponseMessage>, AddGenreCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateGenreCommand, ResponseMessage>, UpdateGenreCommandHandler>();
            services.AddScoped<IRequestHandler<GetGenreByIdQuery, ResponseMessage>, GetGenreByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetGenresQuery, ResponseMessage>, GetGenresQueryHandler>();

            services.AddScoped<IUserGenresRepository, UserGenresRepository>();
            services.AddScoped<IRequestHandler<UpdateUserGenresCommand, ResponseMessage>, UpdateUserGenresCommandHandler>();

            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IRequestHandler<AddProfilePhotoCommand, ResponseMessage>, AddProfilePhotoCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserPhotoCommand, ResponseMessage>, DeleteUserPhotoCommandHandler>();
            services.AddScoped<IRequestHandler<AddCoverPhotoCommand, ResponseMessage>, AddCoverPhotoCommandHandler>();

            return services;
        }
    }
}