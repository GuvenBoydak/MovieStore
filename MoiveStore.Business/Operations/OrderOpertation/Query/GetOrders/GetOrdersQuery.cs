using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Core.Entities;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.OrderOpertation.Query.GetOrders
{
    public class GetOrdersQuery
    {
        public GetOrdersViewModel Model { get; set; }
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public GetOrdersQuery(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<GetOrdersViewModel> Handler()
        {
            List<Customer> list = _db.Customers.Include(x => x.Orders).ThenInclude(x => x.movie).Where(x => x.Orders.Any(x => x.IsActive)).OrderBy(x => x.Id).ToList();

            List<GetOrdersViewModel> vm = _mapper.Map<List<GetOrdersViewModel>>(list);

            return vm;
        }
    }
}
