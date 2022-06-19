using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.MovieViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.MovieOperations.Command.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieViewModel Model { get; set; }

        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public CreateMovieCommand(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public void Handler()
        {
            Movie movie = _db.Movies.SingleOrDefault(x => x.Name == Model.Name);
            if (movie != null)
                throw new InvalidOperationException("Bu Film mevcut");

            movie=_mapper.Map<Movie>(Model);
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }
    }
}
