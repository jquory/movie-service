using dummy_api.Database;
using dummy_api.Shared.Contracts.Movie;
using dummy_api.Shared.DTO.Movie;

namespace dummy_api.Services.Movie;

public class MovieService: IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    // Get All Movies
    public (List<MovieResponse>?, Exception?) GetAllMovies()
    {
        try
        {
            var (result, err) = _movieRepository.GetAllMovies();
            
            // If error exists
            if (err != null)
            {
                return (null, err);
            }
            
            // Return success data
            return (result, null);
        }
        catch (Exception err)
        {
            return (null, err); 
        }
    }

    // Get single movie by id
    public (MovieResponse?, Exception?) GetMovieById(Guid id)
    {
        try
        {
            var (result, err) = _movieRepository.GetMovieById(id);
            
            // If id from parameter not found or not match
            if (result == null)
            {
                return (null, new Exception("Movie Not Found"));
            }
            
            // If movie with id from parameter exists
            return (result, null);
        }
        catch (Exception err)
        {
            return (null, new Exception(err.Message));
        }
    }

    
    // Create New Movie
    public (MovieResponse?, Exception?) CreateMovie(MovieRequest? request)
    {
        try
        {
            var (newMovie, err) = _movieRepository.CreateMovie(request);
            
            // If error
            if (err != null)
            {
                return (null, new Exception(err.Message));
            }
            
            // Create new movie
            return (newMovie, null);
        }
        catch (Exception err)
        {
            return (null, new Exception(err.Message));
        }
    }
}