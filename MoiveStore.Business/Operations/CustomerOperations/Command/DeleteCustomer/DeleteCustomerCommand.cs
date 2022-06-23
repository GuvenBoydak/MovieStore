
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.CustomerOperations.Command.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public int CustomerId { get; set; }

        private readonly IMovieStoreDb _db;

        public DeleteCustomerCommand(IMovieStoreDb db)
        {
            _db = db;
        }

        public void Handler()
        {
            Customer customer = _db.Customers.SingleOrDefault(x=>x.Id==CustomerId);
            if (customer == null)
                throw new InvalidOperationException("Müşteri Buunamadı");

            _db.Customers.Remove(customer);
            _db.SaveChanges();
        }
    }
}
