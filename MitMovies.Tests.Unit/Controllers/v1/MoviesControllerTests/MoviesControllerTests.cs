using API.Controllers.v1;
using MediatR;
using Moq;


namespace MitMovies.Tests.Unit.Controllers.v1.MoviesControllerTests
{
    public partial class MoviesControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private MoviesController _controller;

        public MoviesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new MoviesController(_mediatorMock.Object);
        }
    }
}