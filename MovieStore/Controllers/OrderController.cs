using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Operations.OrderOpertation.Command.CreateOrder;
using MovieStore.Business.Operations.OrderOpertation.Command.DeleteOrder;
using MovieStore.Business.Operations.OrderOpertation.Query.GetDetailOrder;
using MovieStore.Business.Operations.OrderOpertation.Query.GetOrders;
using MovieStore.Business.Validation.Order;
using MovieStore.Core.CrossCuttingConcerns.Validation;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.ViewModel.OrderViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public OrderController(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            GetOrdersQuery query = new GetOrdersQuery(_db,_mapper);

            List<GetOrdersViewModel> result = query.Handler();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetailOrder(int id)
        {
            GetDetailOrderQuery query = new GetDetailOrderQuery(_db,_mapper);
            query.Id = id;

            ValidationTool.Validate(new GetDetailOrderQueryValidator(), query);

            GetDetailOrderViewModel result=query.Handler();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] CreateOrderViewModel model)
        {
            CreateOrderCommand command = new CreateOrderCommand(_db,_mapper);
            command.Model = model;

            ValidationTool.Validate(new CreateOrderCommandValidator(), command);

            command.Handler();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_db);
            command.OrderId = id;

            ValidationTool.Validate(new DeleteOrderCommandValidator(), command);

            command.Handler();

            return Ok();
        }
    }
}
