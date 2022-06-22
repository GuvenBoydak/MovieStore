using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.DirectorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.DirectorOperations.Query.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<GetDirectorsViewModel> Handler()
        {
            List<Director> directors = _db.Directors.OrderBy(x => x.Id).ToList();
            List<GetDirectorsViewModel> models = _mapper.Map<List<GetDirectorsViewModel>>(directors);
            return models;
        }
    }
}
