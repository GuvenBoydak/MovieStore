using FluentAssertions;
using MovieStore.Business.Operations.OrderOpertation.Command.DeleteOrder;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.OrderOperations.Command.DeleteOrder
{
    public class DeleteOrderCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;

        public DeleteOrderCommandTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
        }

        [Fact]
        public void WhenTheOrderToDeleteIsNotFound_InvalidOperationException_ShoudBeReturn()
        {
            int id = 5;

            DeleteOrderCommand command = new DeleteOrderCommand(_db);
            command.OrderId = id;

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Siparis Bulunamadı");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Order_ShouldBeDeleted()
        {
            int id = 1;

            DeleteOrderCommand command = new DeleteOrderCommand(_db);
            command.OrderId = id;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Order order = _db.Orders.SingleOrDefault(x => x.Id == id);

            order.IsActive.Should().Be(false);
        }
    }
}
