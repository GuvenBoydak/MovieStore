using AutoMapper;
using MovieStore.Core.Entities;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.ActorViewModel;
using MovieStore.Entities.ViewModel.CustomerViewModel;
using MovieStore.Entities.ViewModel.DirectorViewModel;
using MovieStore.Entities.ViewModel.GenreViewModel;
using MovieStore.Entities.ViewModel.MovieViewModel;
using MovieStore.Entities.ViewModel.OrderViewModel;
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
            CreateMap<Genre, GetDetailGenreViewModel>();

            CreateMap<CreateCustomerViewModel,Customer>();

            CreateMap<CreateActorViewModel, Actor>();
            CreateMap<Actor, GetActorViewModel>();
            CreateMap<Actor, GetDetailActorViewModel>();

            CreateMap<CreateDirectorViewModel, Director>();
            CreateMap<Director,GetDetailDirectorViewModel>();
            CreateMap<Director,GetDirectorsViewModel>();

            CreateMap<CreateOrderViewModel, Order>();
            CreateMap<Customer, GetOrdersViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.Name + " " + x.Surname))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(x => x.Orders.Select(x => x.movie.Name)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.Orders.Select(x => x.movie.Price)))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(m => m.Orders.Select(s => s.OrderDate))); 

            CreateMap<Customer, GetDetailOrderViewModel>()
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.Name + " " + x.Surname))
               .ForMember(dest => dest.Movies, opt => opt.MapFrom(x => x.Orders.Select(x => x.movie.Name)))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.Orders.Select(x => x.movie.Price)))
               .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(m => m.Orders.Select(s => s.OrderDate)));





        }
    }
}
