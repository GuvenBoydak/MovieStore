using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.GenreViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.GenreOperations.Query.GetGenres
{
    public class GetGenresQuery
    {

        public GetGenresViewModel Model { get; set; }

        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public GetGenresQuery(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<GetGenresViewModel> Handler()
        {
            List<Genre> genre = _db.Genres.OrderBy(x => x.Id).ToList();

            List<GetGenresViewModel> vm = _mapper.Map<List<GetGenresViewModel>>(genre);

            return vm;

        }
    }
}
