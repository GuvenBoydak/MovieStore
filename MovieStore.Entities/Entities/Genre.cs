using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities.Entities
{
    public class Genre:BaseEntity
    {
        public string Name { get; set; }

        //Relational Property
        public ICollection<Movie> Movies { get; set; }

        public ICollection<CustomerGenre> CustomerGenres { get; set; }

    }
}
