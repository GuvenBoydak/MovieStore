using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Operations.ActorOperations.Command.CreateActor;
using MovieStore.Business.Operations.ActorOperations.Command.DeleteActor;
using MovieStore.Business.Operations.ActorOperations.Command.UpdateActor;
using MovieStore.Business.Operations.ActorOperations.Query.GetActors;
using MovieStore.Business.Operations.ActorOperations.Query.GetDetailActor;
using MovieStore.Business.Validation.Actor;
using MovieStore.Core.CrossCuttingConcerns.Validation;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.ViewModel.ActorViewModel;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public ActorController(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorsQuery query = new GetActorsQuery(_db,_mapper);
           List<GetActorViewModel> vm= query.Handler();

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            GetDetailActorQuery query = new GetDetailActorQuery(_db,_mapper);

            query.ActorId= id;

            ValidationTool.Validate(new GetDetailActorQueryValidator(), query);

            GetDetailActorViewModel result = query.Handlerr();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorViewModel model)
        {
            CreateActorCommand command = new CreateActorCommand(_db,_mapper);
            command.Model = model;

            ValidationTool.Validate(new CreateActorCommandValidator(), command);

            command.Handler();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorViewModel model)
        {
            UpdateActorCommand command = new UpdateActorCommand(_db);
            command.ActorId= id;
            command.Model = model;

            ValidationTool.Validate(new UpdateActorCommandValidator(), command);

            command.Handler();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command=new DeleteActorCommand(_db);
            command.ActorId = id;

            ValidationTool.Validate(new DeleteActorCommandValidator(), command);

            command.Handler();

            return Ok();
        }
    }
}
