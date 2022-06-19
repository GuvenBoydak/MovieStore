using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities.Entities
{
    public class CustomerGenre:BaseEntity
    {
        public int CustomerId { get; set; }

        public int GenreId { get; set; }

        //Relational Property
        public Customer Customer { get; set; }

        public Genre Genre { get; set; }

    }
}
