using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.GenreViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.GenreOperations.Command.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreViewModel Model { get; set; }

        private readonly IMovieStoreDb _db;

        public CreateGenreCommand(IMovieStoreDb db)
        {
            _db = db;
        }


        public void Handler()
        {
            Genre genre = _db.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre != null)
                throw new InvalidOperationException("Film Türü Mevcut");

            genre = new Genre();
            genre.Name = Model.Name;

            _db.Genres.Add(genre);
            _db.SaveChanges();
        }
    }
}
