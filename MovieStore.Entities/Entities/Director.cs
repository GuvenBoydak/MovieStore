using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities.Entities
{
    public class Director:BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        //Relational Property
        public ICollection<Movie> Movies { get; set; }
    }
}
