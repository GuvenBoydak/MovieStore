using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.DirectorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.DirectorOperations.Command.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorViewModel Model { get; set; }

        private readonly IMovieStoreDb _db;

        private readonly IMapper _mapper;

        public CreateDirectorCommand(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void Handler()
        {
            Director director = _db.Directors.SingleOrDefault(x=>x.Name + x.Surname ==Model.Name +Model.Surname);
            if (director != null)
                throw new InvalidOperationException("Bu İsim Soyisimli Yönetmen Mevcut");

            director = _mapper.Map<Director>(Model);

            _db.Directors.Add(director);
            _db.SaveChanges();
        }
    }
}
