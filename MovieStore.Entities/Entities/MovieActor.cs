using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities.Entities
{
    public class MovieActor:BaseEntity
    {
        public int MovieId { get; set; }

        public int ActorId { get; set; }

        //Relational Property
        
        public Actor Actor { get; set; }

        public Movie Movie { get; set; }


        
    }
}
