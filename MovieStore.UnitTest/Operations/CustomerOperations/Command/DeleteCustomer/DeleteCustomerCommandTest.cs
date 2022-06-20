using FluentAssertions;
using MovieStore.Business.Operations.CustomerOperations.Command.DeleteCustomer;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.CustomerOperations.Command.DeleteCustomer
{
    public class DeleteCustomerCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;

        public DeleteCustomerCommandTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
        }

        [Fact]
        public void WhenTheCustomerToDeleteIsNotFound_InvalidOperationException_ShoudBeReturn()
        {
            int customerId = 5;

            DeleteCustomerCommand command = new DeleteCustomerCommand(_db);
            command.CustomerId = customerId;

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Müşteri Buunamadı");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Customer_ShouldBeDeleted()
        {
            int customerId = 1;

            DeleteCustomerCommand command = new DeleteCustomerCommand(_db);
            command.CustomerId = customerId;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Customer customers = _db.Customers.SingleOrDefault(x=>x.Id==customerId);

            customers.Should().Be(null);
        }
    }
}
