using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.MovieViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.MovieOperations.Query.GetMovies
{
    public class GetMoviesQuery
    {
        public GetMovieViewModel Model { get; set; }

        private readonly IMovieStoreDb _db;

        private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<GetMovieViewModel> Handler()
        {
            List<Movie> movie = _db.Movies.Include(x => x.Genre).Include(x => x.Director).OrderBy(x => x.Id).ToList();

            List<GetMovieViewModel> vm = _mapper.Map<List<GetMovieViewModel>>(movie);

            return vm;
        }
    }
}
