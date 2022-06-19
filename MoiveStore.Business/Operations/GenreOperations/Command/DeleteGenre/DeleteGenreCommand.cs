using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.GenreOperations.Command.DeleteGenre
{
    public class DeleteGenreCommand
    {

        public int GenreId { get; set; }

        private readonly IMovieStoreDb _db;

        public DeleteGenreCommand(IMovieStoreDb db)
        {
            _db = db;
        }


        public void Handler()
        {
            Genre genre = _db.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
                throw new InvalidOperationException("Film Türü Bulunamdı");

            _db.Genres.Remove(genre);
            _db.SaveChanges();
        }
    }
}
