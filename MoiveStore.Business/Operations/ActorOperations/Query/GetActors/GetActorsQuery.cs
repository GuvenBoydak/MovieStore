using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.ActorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.ActorOperations.Query.GetActors
{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<GetActorViewModel> Handler()
        {
            List<Actor> actors = _db.Actors.OrderBy(x => x.Id).ToList();

            List<GetActorViewModel> vm = _mapper.Map<List<GetActorViewModel>>(actors);
            return vm;

        }
    }
}
