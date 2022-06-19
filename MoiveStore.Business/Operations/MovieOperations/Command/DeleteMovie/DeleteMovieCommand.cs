using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.MovieOperations.Command.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }

        private readonly IMovieStoreDb _db;


        public DeleteMovieCommand(IMovieStoreDb db)
        {
            _db = db;
        }

        public void Handler()
        {
            Movie movie = _db.Movies.SingleOrDefault(x=>x.Id==MovieId);
            if (movie == null)
                throw new InvalidOperationException("Film Bulunamadı");

            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }
    }
}
