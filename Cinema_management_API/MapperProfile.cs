using AutoMapper;
using Microsoft.AspNetCore.Identity;
using DataAccess.Entities;
using Cinema_management_API.Models;

namespace Cinema_management_API
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<CreateHallModel, Hall>();

            CreateMap<EditMovieModel, Movie>();
            CreateMap<EditHallModel, Hall>();

            CreateMap<CreateSessionModel, Session>();

            CreateMap<EditSessionModel, Session>();

            CreateMap<Session, ResponseSessionModel>()
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name))
                .ForMember(dest => dest.HallId, opt => opt.MapFrom(src => src.Hall.Id));

        }
    }
}
