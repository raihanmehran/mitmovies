using Application.v1.DTOs;
using Application.v1.Services.MovieService.Query;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TMDbLib.Objects.Movies;

namespace MitMovies.Tests.Unit.Controllers.v1.MoviesControllerTests
{
    public partial class MoviesControllerTests
    {
        [Fact]
        public async void GetMovieById_Returns_OkResult_WithMovieData_WhenMovieExists_WithGivenMovieId()
        {
            // Arrange
            int movieId = 123;
            var expectedMovieData = new Movie { Id = movieId };
            var expectedResult = new ResponseMessage { Data = expectedMovieData };

            _mediatorMock.Setup(x => x.Send(It.Is<GetMovieByIdQuery>(q =>
                q.MovieId == movieId), default))
                .ReturnsAsync(expectedResult);

            // Act
            var response = await _controller.GetMovieById(movieId: movieId);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<ActionResult<ResponseMessage>>(response);
            var okResult = Assert.IsType<OkObjectResult>(response.Result);
            var movie = Assert.IsType<Movie>(okResult.Value);
            Assert.Equal(expectedMovieData.Id, movie.Id);
        }

        [Fact]
        public async void GetMovieById_Returns_NotFoundResult_WhenMovieDoesNotExist()
        {
            // Arrange
            int movieId = 999999999;
            var expectedMovieData = new ResponseMessage { Data = null };
            _mediatorMock.Setup(x => x.Send(It.Is<GetMovieByIdQuery>(q =>
                q.MovieId == movieId), default))
                .ReturnsAsync(expectedMovieData);

            // Act
            var response = await _controller.GetMovieById(movieId: movieId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(response.Result);
            Assert.Null(response.Value);
        }
    }
}