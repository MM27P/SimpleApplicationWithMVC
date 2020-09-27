using AutoMapper;
using SimpleApplicationWithMVC.Database.Model;
using SimpleApplicationWithMVC.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApplicationWithMVC.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDTO, Book>();
            CreateMap<Book, BookDTO>()
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(y => y.Author.Name));
            CreateMap<ReservationDTO, Reservation>();
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<Reservation, ReservationViewDTO>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(y => y.User.Login))
                .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.User.Id))
                .ForMember(x => x.ReservationDate, opt => opt.MapFrom(y => y.Date.ToString()));
        }
    }
}
