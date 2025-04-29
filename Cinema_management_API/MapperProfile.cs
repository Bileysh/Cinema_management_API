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
            CreateMap<CreateSessionModel, Session>();
            CreateMap<CreateTicketModel, Ticket>();
            CreateMap<CreateDiscountModel, Discount>();
            CreateMap<CreateUserModel, User>();
            CreateMap<CreateSalesModel, Sales>();

            CreateMap<EditMovieModel, Movie>();
            CreateMap<EditHallModel, Hall>();
            CreateMap<EditTicketModel, Ticket>();
            CreateMap<EditSessionModel, Session>();
            CreateMap<EditDiscountModel, Discount>();
            CreateMap<EditUserModel, User>();
            CreateMap<EditSalesModel, Sales>();

            CreateMap<Session, ResponseSessionModel>()
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name))
                .ForMember(dest => dest.HallId, opt => opt.MapFrom(src => src.Hall.Id));

            CreateMap<Ticket, ResponseTicketModel>()
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Session.Movie.Name))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Session.Hall.Id))
                .ForMember(dest => dest.DateStart, opt => opt.MapFrom(src => src.Session.DateStart))
                .ForMember(dest => dest.TimeStart, opt => opt.MapFrom(src => src.Session.TimeStart))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Session.Price))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            CreateMap<User, ResponseUserModel>()
                .ForMember(dest => dest.PromotionalOffer, opt => opt.MapFrom(src => src.Discount.PromotionalOffer))
                .ForMember(dest => dest.DiscountForRegularCustomers, opt => opt.MapFrom(src => src.Discount.DiscountForRegularCustomers));

            CreateMap<Sales, ResponseSalesModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.AmountOfTickets, opt => opt.MapFrom(src => src.User.Tickets.Count))
                .ForMember(dest => dest.SumOfPayment, opt => opt.MapFrom(src => src.User.Tickets
                                                                                   .Where(t => t.Session != null)
                                                                                   .Sum(s => s.Session.Price)))
                .ForMember(dest => dest.DatePurchase, opt => opt.MapFrom(src => src.User.Tickets
                                                                                   .Where(t => t.Session != null)
                                                                                   .OrderByDescending(t => t.Session.DateStart)
                                                                                   .Select(t => t.Session.DateStart)
                                                                                   .FirstOrDefault()));

        }
    }
}
