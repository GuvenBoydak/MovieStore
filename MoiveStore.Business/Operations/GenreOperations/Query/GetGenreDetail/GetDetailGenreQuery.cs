using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.GenreViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.GenreOperations.Query.GetGenreDetail
{
    public class GetDetailGenreQuery
    {
        public int GenreId { get; set; }

        public GetDetailGenreViewModel Model { get; set; }

        private readonly IMovieStoreDb _db;

        private readonly IMapper _mapper;

        public GetDetailGenreQuery(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public GetDetailGenreViewModel Handler()
        {
            Genre genre = _db.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
                throw new InvalidOperationException("Film türü Bulunamadı");

            return _mapper.Map<GetDetailGenreViewModel>(genre);

        }
    }
}
