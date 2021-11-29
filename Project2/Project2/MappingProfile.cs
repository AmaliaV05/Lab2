using AutoMapper;
using Project2.Models;
using Project2.ViewModels;
using Project2.ViewModels.Reservations;

namespace Project2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Film, FilmViewModel>().ReverseMap();

            CreateMap<Comment, CommentViewModel>().ReverseMap();

            CreateMap<Film, FilmWithCommentViewModel>().ReverseMap();

            CreateMap<Reservation, ReservationForUserResponse>().ReverseMap();

            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
        }
    }
}
