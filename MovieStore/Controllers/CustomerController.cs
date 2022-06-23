using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Operations.CustomerOperations.Command.CreateCustomer;
using MovieStore.Business.Operations.CustomerOperations.Command.CreateRefleshToken;
using MovieStore.Business.Operations.CustomerOperations.Command.CreateToken;
using MovieStore.Business.Operations.CustomerOperations.Command.DeleteCustomer;
using MovieStore.Business.Validation.Customer;
using MovieStore.Core.CrossCuttingConcerns.Validation;
using MovieStore.Core.Utilities.Security.JWT.TokenOperations;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.ViewModel.CustomerViewModel;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public CustomerController(IMovieStoreDb db, IMapper mapper, IConfiguration config)
        {
            _db = db;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerViewModel model)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_db,_mapper);

            command.Model = model;

            ValidationTool.Validate(new CreateCustomerCommandValidator(), command);

            command.Handler();

            return Ok(model);
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenViewModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_db,_config);
            command.Model = login;

            ValidationTool.Validate(new CreateTokenCommandValidator(), command);

           Token token= command.Handler();

            return token;
        }

        [HttpGet("refleshToken")]
        public ActionResult<Token> RefleshToken([FromBody] string token)
        {
            CreateRefleshTokenCommand command = new CreateRefleshTokenCommand(_db,_config);
            command.RefleshToken = token;

            Token result = command.Handler();

            return result;
        }




        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_db);

            command.CustomerId = id;

            ValidationTool.Validate(new DeleteCustomerCommandValidator(),command);

            command.Handler();

            return Ok();
        }
    }
}
