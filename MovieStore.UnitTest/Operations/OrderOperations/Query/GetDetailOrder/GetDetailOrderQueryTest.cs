using AutoMapper;
using FluentAssertions;
using MovieStore.Business.Operations.OrderOpertation.Query.GetDetailOrder;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.OrderOperations.Query.GetDetailOrder
{
    public class GetDetailOrderQueryTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        private readonly IMapper _mapper;

        public GetDetailOrderQueryTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidOrderIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            GetDetailOrderQuery query = new GetDetailOrderQuery(_db,_mapper);
            query.Id = 0;

            FluentActions.Invoking(() => query.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Sipariş bulunamadı");
        }

        [Fact]
        public void WhenValidOrderIdIsGiven_InvalidOperationException_ShouldNotBeReturnError()
        {   
            GetDetailOrderQuery query = new GetDetailOrderQuery(_db, _mapper);
            query.Id = 1;

            FluentActions.Invoking(() => query.Handler()).Invoke();
        }
    }
}
