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

        public async Task<ResponseMessage> AddGenreAsync(GenreDto genreDto)
        {
            if (genreDto is null) return Response(
                statusCode: 401, message: "Data Not Provided");

            if (await IsGenreExistAsync(genreDto: genreDto)) return Response(
                statusCode: 400, message: "Genre Already Exist");

            var genre = _mapper.Map<Genre>(genreDto);
            await _context.Genres.AddAsync(genre);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Genre Added Successfully");

            return Response(statusCode: 500,
                message: "Error while adding Genre");
        }
        public async Task<ResponseMessage> UpdateGenreAsync(GenreDto genreDto)
        {
            if (genreDto is null) return Response(
                statusCode: 401, message: "Data Not Provided");

            var genre = await GetGenreAsync(genreDto: genreDto);

            if (genre is null) return Response(
                statusCode: 400, message: "Genre doesn't exist!");

            if (genre.Name == genreDto.Name) return Response(
                statusCode: 400, message: "Genre state not modified!");

            _mapper.Map(genreDto, genre);

            if (await SaveAllAsync()) return Response(
                statusCode: 200, message: "Genre Updated Successfully");

            return Response(statusCode: 500,
                message: "Error while updating Genre");
        }

        public async Task<bool> IsGenreExistAsync(GenreDto genreDto) =>
            await _context.Genres.AnyAsync(x =>
                x.Name == genreDto.Name);

        public async Task<Genre> GetGenreAsync(GenreDto genreDto) =>
            await _context.Genres.SingleOrDefaultAsync(x =>
                x.Id == genreDto.Id);

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