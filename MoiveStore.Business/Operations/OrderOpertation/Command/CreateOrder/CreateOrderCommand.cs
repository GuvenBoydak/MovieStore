using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.OrderOpertation.Command.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderViewModel Model { get; set; }
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public CreateOrderCommand(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void Handler()
        {
            Order order = _db.Orders.FirstOrDefault(x => x.MovieId == Model.MovieId && x.CustomerId == Model.CustomerId);
            if (order != null)
                throw new InvalidOperationException("Müsteri bu filmi daha önce satın almış");

            order = _mapper.Map<Order>(Model);
            _db.Orders.Add(order);
            _db.SaveChanges();

        }
    }
}
