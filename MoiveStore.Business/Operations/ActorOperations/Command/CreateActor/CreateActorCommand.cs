using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.ActorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.ActorOperations.Command.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorViewModel Model { get; set; }
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public CreateActorCommand(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void Handler()
        {
            Actor actor = _db.Actors.SingleOrDefault(x=>x.Name + x.Surname ==Model.Name + Model.Surname);
            if (actor != null)
                throw new InvalidOperationException("Bu isim ve soyisimli Oyuncu mevcut");

            actor = _mapper.Map<Actor>(Model);

            _db.Actors.Add(actor);
            _db.SaveChanges();
        }
    }
}
