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


        }
    }
}
