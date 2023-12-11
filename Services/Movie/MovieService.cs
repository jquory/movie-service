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

    public (MovieResponse?, Exception?) GetMovieById(Guid id)
    {
        try
        {
            var (result, err) = _movieRepository.GetMovieById(id);

            if (result == null)
            {
                return (null, new Exception("Movie Not Found"));
            }

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