using MovieStore.Business.Validation.Director;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.DirectorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.DirectorOperations.Command.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public int DirectorId { get; set; }

        public UpdateDirectorViewModel Model { get; set; }

        private readonly IMovieStoreDb _db;


        public UpdateDirectorCommand(IMovieStoreDb db)
        {
            _db = db;
        }

        public void Handler()
        {
            Director director = _db.Directors.SingleOrDefault(x=>x.Id==DirectorId);
            if (director == null)
                throw new InvalidOperationException("Yönetmen Bulunamdı");

            director.Name= Model.Name !=default ? Model.Name : director.Name;
            director.Surname= Model.Surname !=default ? Model.Surname : director.Surname;

            _db.SaveChanges();

        }
    }
}
