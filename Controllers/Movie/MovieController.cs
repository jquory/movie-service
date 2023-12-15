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
    public ActionResult GetAllMovies()
    {
        try
        {
            // Get movie data
            var (result, err) = _movieService.GetAllMovies();

            // Check if movie data is null or has error
            if (err != null || result == null)
            {
                return NotFound(new ApiMessage<List<MovieResponse>?>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Status = "Not Found",
                    Message = "Movie Not Found",
                });
            }

            // Return movie data
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
    public ActionResult GetMovieById([FromRoute] Guid id)
    {
        try
        {
            // Get movie data
            var (result, err) = _movieService.GetMovieById(id);

            // Check if movie data is null or has error
            if (result == null)
            {
                return NotFound(new ApiMessage<MovieResponse>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Status = "Not Found",
                    Message = "Movie Not Found",
                });
            }

            // Return movie data
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
    public ActionResult CreateMovie([FromBody] MovieRequest request)
    {
        try
        {
            // Execute create movie
            var (result, err) = _movieService.CreateMovie(request);

            // Check is it any error when execute new movie
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
    
            // Return success if no error
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