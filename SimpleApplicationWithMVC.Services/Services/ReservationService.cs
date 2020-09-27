using AutoMapper;
using SimpleApplicationWithMVC.Database;
using SimpleApplicationWithMVC.Database.Model;
using SimpleApplicationWithMVC.Services.DTO;
using SimpleApplicationWithMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SimpleApplicationWithMVC.Services.Services
{
    public class ReservationService : IReservationService
    {
        public ReservationService(DatabaseContext databaseContext, IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;

        }

        private DatabaseContext databaseContext;
        private IMapper mapper;

        public int AddReservation(ReservationDTO reservationDTO)
        {
            Reservation reservation = mapper.Map<Reservation>(reservationDTO);
            reservation.Date = DateTime.Now;
            reservation = databaseContext.Reservations.Add(reservation);
            databaseContext.SaveChanges();
            return reservation.Id;
        }

        public List<Reservation> GetReservationByBook(int bookId)
        {
            return databaseContext.Reservations.Where(x => x.BookId == bookId).Include(x => x.User).ToList();
        }
    }
}
