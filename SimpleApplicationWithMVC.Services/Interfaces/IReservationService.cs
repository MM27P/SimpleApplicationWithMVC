using SimpleApplicationWithMVC.Database.Model;
using SimpleApplicationWithMVC.Services.DTO;
using System.Collections.Generic;

namespace SimpleApplicationWithMVC.Services.Interfaces
{
    public interface IReservationService
    {
        int AddReservation(ReservationDTO reservation);

        List<Reservation> GetReservationByBook(int bookId);
    }
}
