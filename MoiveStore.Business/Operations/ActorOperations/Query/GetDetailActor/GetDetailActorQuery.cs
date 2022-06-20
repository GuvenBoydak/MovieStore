using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.ActorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.ActorOperations.Query.GetDetailActor
{
    public class GetDetailActorQuery
    {
        public int ActorId { get; set; }

        public GetDetailActorViewModel Model { get; set; }
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public GetDetailActorQuery(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public GetDetailActorViewModel Handlerr()
        {
            Actor actor = _db.Actors.SingleOrDefault(x=>x.Id==ActorId);
            if (actor == null)
                throw new InvalidOperationException("Oyuncu Bulunamdı");

            GetDetailActorViewModel vm = _mapper.Map<GetDetailActorViewModel>(actor);
            return vm;

        }
    }
}
