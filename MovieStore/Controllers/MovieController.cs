using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DataAccess.Abstract;
using MovieStore.Business.Operations.MovieOperations.Query.GetMovies;
using MovieStore.Entities.ViewModel.MovieViewModel;
using MovieStore.Business.Operations.MovieOperations.Query.GetDetailMovie;
using MovieStore.Core.CrossCuttingConcerns.Validation;
using MovieStore.Business.Validation.Movie;
using MovieStore.Entities.Entities;
using MovieStore.Business.Operations.MovieOperations.Command.CreateMovie;
using MovieStore.Business.Operations.MovieOperations.Command.UpdateMovie;
using MovieStore.Business.Operations.MovieOperations.Command.DeleteMovie;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(_db,_mapper);

            List<GetMovieViewModel> result = query.Handler();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetailMovie(int id)
        {
            GetDetailMovieQuery query = new GetDetailMovieQuery(_db,_mapper);
            query.MovieId = id;

            ValidationTool.Validate(new GetDetailMovieQueryValidator(), query);

            GetDetailMovieViewModel result = query.Handler();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieViewModel model)
        {
            CreateMovieCommand command = new CreateMovieCommand(_db, _mapper);

            command.Model = model;

            command.Handler();

            ValidationTool.Validate(new CreateMovieCommandValidation(), command);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieViewModel model)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_db);
            command.MovieId=id;
            command.Model = model;

            ValidationTool.Validate(new UpdateMovieCommandValidation(), command);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command =new  DeleteMovieCommand(_db);

            command.MovieId = id;

            ValidationTool.Validate(new DeleteMovieCommandValidation(), command);

            return Ok();
        }

    }
}
