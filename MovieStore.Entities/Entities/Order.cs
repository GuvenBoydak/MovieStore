using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities.Entities
{
    public class Order:BaseEntity
    {
        public int MovieId { get; set; }

        public int CustomerId { get; set; }

        public decimal Price { get; set; }

        public DateTime OrderDate { get; set; }

        //Relational Property
        public Movie movie { get; set; }

        public Customer Customer { get; set; }

    }
}
