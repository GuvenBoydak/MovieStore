using AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.DirectorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Operations.DirectorOperations.Query.GetDetailDirector
{
    public class GetDetailDirectorQuery
    {
        public int DirectorId { get; set; }

        public GetDetailDirectorViewModel Model { get; set; }
        private readonly IMovieStoreDb _db;
        private readonly IMapper _mapper;

        public GetDetailDirectorQuery(IMovieStoreDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public GetDetailDirectorViewModel Handler()
        {
            Director director = _db.Directors.SingleOrDefault(x=>x.Id==DirectorId);
            if (director == null)
                throw new InvalidOperationException("Yönetmen bulunamadı");

            GetDetailDirectorViewModel vm = _mapper.Map<GetDetailDirectorViewModel>(director);
            return vm;
        }
    }
}
