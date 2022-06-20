using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.ActorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.ActorOperations.Command.UpdateActor
{
    public class UpdateActorCommand
    {
        public int ActorId { get; set; }
        public UpdateActorViewModel Model { get; set; }
        private readonly IMovieStoreDb _db;


        public UpdateActorCommand(IMovieStoreDb db)
        {
            _db = db;
        }

        public void Handler()
        {
            Actor actor = _db.Actors.SingleOrDefault(x=>x.Id==ActorId);
            if (actor == null)
                throw new InvalidOperationException("Oyuncu Bulunamadı");

            actor.Name = actor.Name != default ? Model.Name : actor.Name;
            actor.Surname = actor.Surname != default ? Model.Surname : actor.Surname;

            _db.SaveChanges();
        }
    }
}
