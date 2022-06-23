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

namespace MovieStore.Business.Operations.OrderOpertation.Query.GetDetailOrder
{
    public class GetDetailOrderQuery
    {
        public int Id { get; set; }

        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public GetDetailOrderQuery(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public GetDetailOrderViewModel Handler()
        {
            Customer customer = _db.Customers.Include(x => x.Orders).ThenInclude(x => x.movie).SingleOrDefault(x=>x.Id==Id);
            if (customer == null)
                throw new InvalidOperationException("Sipariş bulunamadı");

            GetDetailOrderViewModel vm =_mapper.Map<GetDetailOrderViewModel>(customer);

            return vm;
        }

    }
}
