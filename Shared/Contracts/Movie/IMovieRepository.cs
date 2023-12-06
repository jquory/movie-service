using dummy_api.Shared.DTOs.Movie;

namespace dummy_api.Shared.Contracts.Movie;

public interface IMovieRepository
{
    public (List<MovieResponse>, Exception) GetAllMovies();
}