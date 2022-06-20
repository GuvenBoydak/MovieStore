using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.CustomerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.CustomerOperations.Command.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerViewModel Model { get; set; }
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void Handler()
        {
            Customer customer = _db.Customers.SingleOrDefault(x=>x.Name + x.Surname ==Model.Name + Model.Surname);
            if (customer != null)
                throw new InvalidOperationException("Bu İsim ve soyisimli Müşteri Mevcut");

            customer = _mapper.Map<Customer>(Model);

            _db.Customers.Add(customer);
            _db.SaveChanges();           
        }

    }
}
