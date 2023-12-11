using System.Net;
using dummy_api.Shared.Contracts.Movie;
using dummy_api.Shared.DTO;
using dummy_api.Shared.DTO.Movie;
using Microsoft.AspNetCore.Mvc;

namespace dummy_api.Controllers.Movie;

[ApiController]
public class MovieController: ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    [Route("/")]
    public async Task<ActionResult> GetAllMovies()
    {
        try
        {
            var (result, err) = _movieService.GetAllMovies();

            if (err != null || result == null)
            {
                return NotFound(new ApiMessage<List<MovieResponse>?>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Status = "Not Found",
                    Message = err.Message,
                });
            }

            return Ok(new ApiMessage<List<MovieResponse>?>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Status = "OK",
                Message = "Success",
                Data = result
            });
        }
        catch (Exception err)
        {
            return NotFound(new ApiMessage<List<MovieResponse>?>()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Status = "Error",
                Message = err.Message,
                Data = null
            });
        }
    }

    [HttpGet]
    [Route("/movie/{id}")]
    public async Task<ActionResult> GetMovieById([FromRoute] Guid id)
    {
        try
        {
            var (result, err) = _movieService.GetMovieById(id);

            if (result == null)
            {
                return NotFound(new ApiMessage<MovieResponse>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Status = "Not Found",
                    Message = err.Message,
                });
            }

            return Ok(new ApiMessage<MovieResponse>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                Status = "OK",
                Message = "Success",
                Data = result
            });
        }
        catch (Exception err)
        {
            return NotFound(new ApiMessage<MovieResponse>()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Status = "Internal Server Error",
                Message = err.Message,
                Data = null
            });
        }
    }

    [HttpPost]
    [Route("/movie")]
    public async Task<ActionResult> CreateMovie([FromBody] MovieRequest request)
    {
        try
        {
            var (result, err) = _movieService.CreateMovie(request);

            if (err != null)
            {
                return NotFound(new ApiMessage<MovieResponse>()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Status = "Error",
                    Message = err.Message,
                    Data = null
                });
            }

            return Ok(new ApiMessage<MovieResponse>()
            {
                StatusCode = (int)HttpStatusCode.Created,
                Status = "Created",
                Message = "Movie Recorded",
                Data = result
            });
        }
        catch (Exception err)
        {
            return NotFound(new ApiMessage<MovieResponse>()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Status = "Error",
                Message = err.Message,
                Data = null
            });
        }
    }
}