using Application.v1.DTOs;
using Application.v1.Interfaces;
using AutoMapper;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.v1.Repositories
{
    public class GenresRepository : IGenresRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public GenresRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> AddGenre(GenreDto genreDto)
        {
            if (genreDto is null) return Response(
                statusCode: 401, message: "Data Not Provided");

            if (await IsGenreExist(genreDto: genreDto)) return Response(
                statusCode: 400, message: "Genre Already Exist");

            var genre = _mapper.Map<Genre>(genreDto);
            await _context.Genres.AddAsync(genre);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Genre Added Successfully");

            return Response(statusCode: 500,
                message: "Error while adding Genre");
        }

        public async Task<bool> IsGenreExist(GenreDto genreDto)
        {
            var genre = await GetGenre(genreDto: genreDto);

            return genre == null ? false : true;
        }

        public async Task<Genre> GetGenre(GenreDto genreDto) =>
            await _context.Genres.SingleOrDefaultAsync(x =>
                x.Name == genreDto.Name);

        public async Task<bool> SaveAllAsync() =>
            await _context.SaveChangesAsync() > 0;

        private ResponseMessage Response(int statusCode, string message, object data = null)
        {
            var response = new ResponseMessage();
            response.StatusCode = statusCode;
            response.Message = message;
            response.Data = data;

            return response;
        }
    }
}