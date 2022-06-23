using MovieStore.Core.Entities;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities.Entities
{
    public class Customer:BaseEntity
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpireDate { get; set; }

        //Relational Property
        public List<CustomerGenre> CustomerGenres { get; set; }

        public List<Order> Orders { get; set; }


    }
}
