using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Operations.CustomerOperations.Command.CreateCustomer;
using MovieStore.Business.Operations.CustomerOperations.Command.DeleteCustomer;
using MovieStore.Business.Validation.Customer;
using MovieStore.Core.CrossCuttingConcerns.Validation;
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

        public CustomerController(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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
