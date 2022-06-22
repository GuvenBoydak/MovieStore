using AutoMapper;
using FluentAssertions;
using MovieStore.Business.Operations.OrderOpertation.Command.CreateOrder;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.OrderViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.OrderOperations.Command.CreateOrder
{
    public class CreateOrderCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        private readonly IMapper _mapper;

        public CreateOrderCommandTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenCustomerHasPurchasedThisMovieBeforeIsGiven_InvalidOperationException_ShoudBeReturn()
        {
            Order order = new Order() { CustomerId = 1, MovieId = 1, IsActive = true, OrderDate = DateTime.Now, Price = 100 };

            _db.Orders.Add(order);
            _db.SaveChanges();

            CreateOrderCommand command = new CreateOrderCommand(_db, _mapper);
            command.Model = new CreateOrderViewModel() { CustomerId = order.CustomerId, MovieId = order.MovieId, Price = order.Price, OrderDate = order.OrderDate };

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Müsteri bu filmi daha önce satın almış");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Order_ShouldBeCreated()
        {
            CreateOrderCommand command = new CreateOrderCommand(_db, _mapper);
            CreateOrderViewModel model = new CreateOrderViewModel() { CustomerId = 1, MovieId = 2 ,Price = 100  };

            command.Model = model;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Order order = _db.Orders.SingleOrDefault(x => x.MovieId == model.MovieId && x.CustomerId ==model.CustomerId);

            order.Should().NotBeNull();
            order.CustomerId.Should().Be(model.CustomerId);
            order.MovieId.Should().Be(model.MovieId);
            order.Price.Should().Be(model.Price);
            order.OrderDate.Should().Be(model.OrderDate);
        }
    }
    
}
