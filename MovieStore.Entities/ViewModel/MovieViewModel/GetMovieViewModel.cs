using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities.ViewModel.MovieViewModel
{
    public class GetMovieViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }
    }
}
