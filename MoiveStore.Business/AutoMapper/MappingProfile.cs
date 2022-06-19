using AutoMapper;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.GenreViewModel;
using MovieStore.Entities.ViewModel.MovieViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMovieViewModel, Movie>();

            CreateMap<Movie, GetDetailMovieViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
                .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src => src.MovieActors.Select(src => src.Actor.Name + " " + src.Actor.Surname)));

            CreateMap<Movie, GetMovieViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname));


            CreateMap<Genre, GetGenresViewModel>();


        }
    }
}
