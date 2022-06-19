using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities.Entities
{
    public class Movie:BaseEntity
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int GenreId { get; set; }

        public int DirectorId { get; set; }

        //Relational Property
        public Genre Genre { get; set; }

        public Director Director { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }

        public ICollection<Order> Orders { get; set; }




    }
}
