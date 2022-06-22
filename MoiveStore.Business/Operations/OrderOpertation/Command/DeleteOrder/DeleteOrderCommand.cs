using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.OrderOpertation.Command.DeleteOrder
{
    public class DeleteOrderCommand
    {
        public int OrderId { get; set; }
        private readonly IMovieStoreDb _db;

        public DeleteOrderCommand(IMovieStoreDb db)
        {
            _db = db;
        }

        public void Handler()
        {
            Order order = _db.Orders.SingleOrDefault(x=>x.Id==OrderId);
            if (order == null)
                throw new InvalidOperationException("Siparis Bulunamadı");

            order.IsActive = false;
            _db.SaveChanges();
        }
    }
}
