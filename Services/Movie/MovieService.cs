using dummy_api.Database;
using dummy_api.Shared.Contracts.Movie;
using dummy_api.Shared.DTOs.Movie;

namespace dummy_api.Services.Movie;

public class MovieService: IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public (List<MovieResponse>?, Exception?) GetAllMovies()
    {
        try
        {
            var (result, err) = _movieRepository.GetAllMovies();

            if (err != null)
            {
                return (null, err);
            }

            return (result, null);
        }
        catch (Exception err)
        {
            return (null, err);
        }
    }

    public (MovieResponse?, Exception?) CreateMovie(MovieRequest? request)
    {
        try
        {
            var (newMovie, err) = _movieRepository.CreateMovie(request);

            if (err != null)
            {
                return (null, new Exception(err.Message));
            }

            return (newMovie, null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
}