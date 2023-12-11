using dummy_api.Database;
using dummy_api.Shared.Contracts.Movie;
using dummy_api.Shared.DTO.Movie;
using dummy_api.Models.Entities;

namespace dummy_api.Repositories.Movie;

public class MovieRepository: IMovieRepository
{
    private readonly DataContext _db;

    public MovieRepository(DataContext db)
    {
        _db = db;
    }
    
    public (List<MovieResponse>?, Exception?) GetAllMovies()
    {
        try
        {
            // Query all movies with director name from table 'Directors' and genre name from table 'Genres'
            var query = _db.Movies
                .Join(_db.Directors, movie => movie.DirectorId, director => director.DirectorId,
                    (movie, director) => new { movie, director })
                .Join(_db.Genres, @t => @t.movie.GenreId, genre => genre.GenreId,
                    (result, genre) => new MovieResponse
                    {
                        Id = result.movie.MovieId,
                        Title = result.movie.Title,
                        ReleaseDate = result.movie.ReleaseDate,
                        Duration = result.movie.Duration,
                        Synopsis = result.movie.Synopsis,
                        Director = result.director.DirectorName,
                        Genre = genre.GenreName,
                    });

            // Convert query result to list
            var result = query.ToList();
            
            // Check if result is empty
            if (result.Count == 0)
            {
                return (null, new Exception("No movies found"));
            }

            // Return list of movies and no error
            return (result, null);
        }
        catch (Exception err)
        {
            return (null, new Exception(err.Message));
        }
    }
    
    public (MovieResponse?, Exception?) GetMovieById(Guid id)
    {
        try
        {
            // Query get single movie where 'movieId' equals 'id' from parameters, join genre name, and director name
            var query = _db.Movies.Where(movie => movie.MovieId == id)
                .Join(_db.Directors, movie => movie.DirectorId, director => director.DirectorId,
                    (movie, director) => new { movie, director })
                .Join(_db.Genres, @t => @t.movie.GenreId, genre => genre.GenreId,
                    (result, genre) => new MovieResponse
                    {
                        Id = result.movie.MovieId,
                        Title = result.movie.Title,
                        ReleaseDate = result.movie.ReleaseDate,
                        Duration = result.movie.Duration,
                        Synopsis = result.movie.Synopsis,
                        Director = result.director.DirectorName,
                        Genre = genre.GenreName,
                    });

            // Convert query result to get first result
            var result = query.FirstOrDefault();

            // Check if result not found
            if (result == null)
            {
                return (null, new Exception("No movies found")); 
            }

            // Return the Movie if its found
            return (result, null);
        }
        catch (Exception err)
        {
            return (null, new Exception(err.Message));
        }
    }
    
    public (MovieResponse?, Exception?) CreateMovie(MovieRequest? request)
    {
        try
        {
            // Check if the data from request form is null
            if (request == null)
            {
                return (null, new Exception("request can not be null"));
            }
            
            // Insert new data to movie table
            var newMovie = new Models.Entities.Movie
            {
                Title = request.Title,
                ReleaseDate = request.ReleaseDate,
                Duration = request.Duration,
                Synopsis = request.Synopsis,
                DirectorId = request.DirectorId,
                GenreId = request.GenreId,
            };
            
            // Execute inserted data
            _db.Movies.Add(newMovie);
            _db.SaveChanges();

            // Returning success response
            return (new MovieResponse()
            {
                Id = newMovie.MovieId,
            }, null);
        }
        catch (Exception err)
        {
            return (null, new Exception(err.Message));
        }
    }
}