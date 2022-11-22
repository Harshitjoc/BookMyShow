using BookMyShow.Controllers;
using BookMyShow.Data;
using BookMyShow.Models;
using Microsoft.AspNetCore.Http;

namespace BookMyShow.UnitTests
{
    public class MoviesControllerTests
    {
        private BookMyShowContext context;

        public void Setup()
        {
            context = new BookMyShowContext();
        }

        [Fact]
        public async void Get_Movies_ToListAsync()
        {
            // Arrange
            var moviesController = new MoviesController(context);

            // Act
            var movies = await moviesController.GetMovies();

            // Assert
            Assert.NotNull(movies.Result);

        }
        [Fact]
        public async void Get_Movie_FindAsync()
        {
            // Arrange
            var moviesController = new MoviesController(context);
            int id = 0;
            // Act
            var getMovie = await moviesController.GetMovie(id);
            
            // Assert
            Assert.NotNull(getMovie);
        }
    }
}