using AutoMapper;
using SimpleApplicationWithMVC.Database;
using SimpleApplicationWithMVC.Services.Interfaces;
using SimpleApplicationWithMVC.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApplicationWithMVC.Services
{
    public class ServiceProvider
    {
        private DatabaseContext databaseContext;
        private IMapper mapper;
        private IUserServices userServices;
        private IReservationService reservationService;
        private IBookServices bookServices;

        public IUserServices UserServices { get { return userServices; } }
        public IReservationService ReservationService { get { return reservationService; } }
        public IBookServices BookServices { get { return bookServices; } }
        public  IMapper Mapper { get { return mapper; } }

        private static ServiceProvider instance = new ServiceProvider();
        public static ServiceProvider Instance
        { get { return instance; } }

        private ServiceProvider()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            config.CreateMapper();
            mapper = config.CreateMapper();

            databaseContext = new DatabaseContext();
            userServices = new UserServices(databaseContext);
            reservationService = new ReservationService(databaseContext, mapper);
            bookServices = new BookServices(databaseContext, mapper);
        }
    }
}
