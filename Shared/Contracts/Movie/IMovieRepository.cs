using dummy_api.Shared.DTO.Movie;

namespace dummy_api.Shared.Contracts.Movie;

public interface IMovieRepository
{
    public (List<MovieResponse>?, Exception?) GetAllMovies();
    public (MovieResponse?, Exception?) CreateMovie(MovieRequest? request);
}