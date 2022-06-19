using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.MovieViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.MovieOperations.Command.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public int MovieId { get; set; }

        public UpdateMovieViewModel Model { get; set; }

        private readonly IMovieStoreDb _db;

        public UpdateMovieCommand(IMovieStoreDb db)
        {
            _db = db;
        }

        public void Handler()
        {
            Movie movie = _db.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie == null)
                throw new InvalidOperationException("Film Bulunamadı");

            movie.Name = Model.Name !=default ? Model.Name : movie.Name;
            movie.Price = Model.Price != default ? Model.Price : movie.Price;
            movie.Year = Model.Year != default ? Model.Year : movie.Year;
            movie.GenreId = Model.GenreId != default ? Model.GenreId : movie.GenreId;
            movie.DirectorId = Model.DirectorId != default ? Model.DirectorId : movie.DirectorId;

            _db.SaveChanges();

        }
    }
}
