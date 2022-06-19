using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.GenreViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.GenreOperations.Command.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }

        public UpdateGenreViewModel Model { get; set; }

        private readonly IMovieStoreDb _db;

        public UpdateGenreCommand(IMovieStoreDb db)
        {
            _db = db;
        }

        public void Handler()
        {
            Genre genre = _db.Genres.SingleOrDefault(x=>x.Id==GenreId);
            if (genre == null)
                throw new InvalidOperationException("Film Türü Bulunamdı");

            genre.Name = Model.Name != default ? Model.Name : genre.Name;

            _db.SaveChanges();
        }
    }
}
