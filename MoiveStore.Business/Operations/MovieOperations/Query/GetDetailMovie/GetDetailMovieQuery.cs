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

namespace MovieStore.Business.Operations.MovieOperations.Query.GetDetailMovie
{
    public class GetDetailMovieQuery
    {
        public int MovieId { get; set; }

        public GetDetailMovieViewModel Model { get; set; }

        private readonly IMovieStoreDb _db;

        private readonly IMapper _mapper;

        public GetDetailMovieQuery(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public GetDetailMovieViewModel Handler()
        {
            Movie movie = _db.Movies.Include(x=>x.Genre).Include(x=>x.Director).Include(x => x.MovieActors).ThenInclude(x => x.Actor).SingleOrDefault(x=>x.Id==MovieId);

            if (movie == null)
                throw new InvalidOperationException("Film Bulunamadı");

            GetDetailMovieViewModel vm = _mapper.Map<GetDetailMovieViewModel>(movie);



            return vm;
        }
    }
}
