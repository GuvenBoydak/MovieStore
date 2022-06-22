using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Operations.DirectorOperations.Command.CreateDirector;
using MovieStore.Business.Operations.DirectorOperations.Command.DeleteDirector;
using MovieStore.Business.Operations.DirectorOperations.Command.UpdateDirector;
using MovieStore.Business.Operations.DirectorOperations.Query.GetDetailDirector;
using MovieStore.Business.Operations.DirectorOperations.Query.GetDirectors;
using MovieStore.Business.Validation.Director;
using MovieStore.Core.CrossCuttingConcerns.Validation;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.ViewModel.DirectorViewModel;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public DirectorController(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorsQuery query = new GetDirectorsQuery(_db, _mapper);
            List<GetDirectorsViewModel> result = query.Handler();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetailDirector(int id)
        {
            GetDetailDirectorQuery query = new GetDetailDirectorQuery(_db, _mapper);
            query.DirectorId = id;

            ValidationTool.Validate(new GetDetailDirectorQueryValidator(), query);

            GetDetailDirectorViewModel result = query.Handler();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorViewModel model)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_db, _mapper);
            command.Model = model;

            ValidationTool.Validate(new CreateDirectorCommandValidator(),command);

            command.Handler();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorViewModel model)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_db);
            command.DirectorId = id;
            command.Model = model;

            ValidationTool.Validate(new UpdateDirectorCommandValidator(), command);

            command.Handler();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_db);
            command.DirectorId = id;

            ValidationTool.Validate(new DeleteDirectorCommandValidator(), command);
            command.Handler();

            return Ok();
        }
    }
}
