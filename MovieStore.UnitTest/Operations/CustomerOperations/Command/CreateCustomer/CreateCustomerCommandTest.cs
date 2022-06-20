using AutoMapper;
using FluentAssertions;
using MovieStore.Business.Operations.CustomerOperations.Command.CreateCustomer;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.CustomerViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.CustomerOperations.Command.CreateCustomer
{
    public class CreateCustomerCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        private readonly IMapper _mapper;

        public CreateCustomerCommandTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void WhenAlreadyExistCustomerNameAndSurnameIsGiven_InvalidOperationException_ShoudBeReturn()
        {
            Customer customer = new Customer()
            {
                Name = "test",
                Surname = "test",
                Email = "test@gmail.com",
                Password = "123456",
                CreatedDate = DateTime.Now,
                IsActive=true
            };

            _db.Customers.Add(customer);
            _db.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(_db,_mapper);
            command.Model = new CreateCustomerViewModel() { Name = customer.Name, Surname = customer.Surname };

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu İsim ve soyisimli Müşteri Mevcut");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Customer_ShouldBeCreated()
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_db,_mapper);
            CreateCustomerViewModel model = new CreateCustomerViewModel()
            {
                Name = "test",
                Surname = "test",
                Email = "test@gmail.com",
                Password = "123456"
            };

            command.Model = model;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Customer customer = _db.Customers.SingleOrDefault(x => x.Name + x.Surname == model.Name + model.Surname);

            customer.Should().NotBeNull();
            customer.Name.Should().Be(model.Name);
            customer.Surname.Should().Be(model.Surname);
            customer.Email.Should().Be(model.Email);
            customer.Password.Should().Be(model.Password);
        }


    }
}
