using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.DirectorOperations.Command.DeleteDirector
{
    public class DeleteDirectorCommand
    {

        public int DirectorId { get; set; }

        private readonly IMovieStoreDb _db;

        public DeleteDirectorCommand(IMovieStoreDb db)
        {
            _db = db;
        }

        public void Handler()
        {
            Director director = _db.Directors.SingleOrDefault(x=>x.Id==DirectorId);
            if (director == null)
                throw new InvalidOperationException("Yönetmen bulunamadı");

            _db.Directors.Remove(director);
            _db.SaveChanges();
        }
    }
}
