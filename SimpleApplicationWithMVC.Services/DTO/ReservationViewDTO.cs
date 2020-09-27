using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApplicationWithMVC.Services.DTO
{
    public  class ReservationViewDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string ReservationDate { get; set; }
    }
}
