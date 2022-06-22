using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities.ViewModel.OrderViewModel
{
    public class CreateOrderViewModel
    {
        public CreateOrderViewModel()
        {
            OrderDate = DateTime.Now;
        }

        public int MovieId { get; set; }

        public int CustomerId { get; set; }

        public decimal Price { get; set; }

        public DateTime OrderDate { get; set; }


    }
}
