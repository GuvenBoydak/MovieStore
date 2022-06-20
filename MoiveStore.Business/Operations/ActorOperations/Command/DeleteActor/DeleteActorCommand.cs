using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.ActorOperations.Command.DeleteActor
{
    public class DeleteActorCommand
    {
        public int ActorId { get; set; }

        private readonly IMovieStoreDb _db;

        public DeleteActorCommand(IMovieStoreDb db)
        {
            _db = db;
        }

        public void Handler()
        {
            Actor actor = _db.Actors.SingleOrDefault(x=>x.Id==ActorId);
            if (actor == null)
                throw new InvalidOperationException("Oyuncu Bulunamadı");

            _db.Actors.Remove(actor);
            _db.SaveChanges();
        }
    }
}
