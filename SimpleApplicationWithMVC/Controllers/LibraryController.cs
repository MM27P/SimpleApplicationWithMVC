using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using SimpleApplicationWithMVC.Database.Model;
using SimpleApplicationWithMVC.Models;
using SimpleApplicationWithMVC.Services;
using SimpleApplicationWithMVC.Services.DTO;
using SimpleApplicationWithMVC.Services.Interfaces;

namespace SimpleApplicationWithMVC.Controllers
{
    [RoutePrefix("Library")]
    [Route("{action}/{id}")]
    public class LibraryController : Controller
    {
        IUserServices userServices = ServiceProvider.Instance.UserServices;
        IReservationService reservationService = ServiceProvider.Instance.ReservationService;
        IBookServices bookServices = ServiceProvider.Instance.BookServices;
        IMapper mapper = ServiceProvider.Instance.Mapper;

        // GET: Library/Create
        [Route("Logg")]
        public ActionResult Logg()
        {
            return View();
        }

        [HttpPost]
        [Route("Logg")]
        [ValidateAntiForgeryToken]
        public ActionResult Logg([Bind(Include = "Login,Password")] UserDTO userDTO)
        {
            int CurrentUserId = -1;
            if (ModelState.IsValid)
            {
                CurrentUserId = userServices.AuthorizateUser(userDTO);
            }

            if (CurrentUserId !=-1)
            {
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("WrongUser");
        }

        // GET: Library
        [Route]
        public ActionResult Index()
        {
            var books = bookServices.GetAll();

            return View(new IndexModelView() { books = books, UserName = userServices.GetCurrentUser().Login });
        }

        [Route]
        public ActionResult WrongUser()
        {
            return View();
        }

        // GET: Library/Details/5
        public ActionResult Details(int id)
        {
            Book book = bookServices.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Library/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("Reserve")]
        public ActionResult Reserve(int id)
        {
            reservationService.AddReservation(new ReservationDTO() { UserId = userServices.GetCurrentUser().Id, BookId = id });
            return View();
        }

        [Route("Reservations")]
        public ActionResult Reservations(int id)
        {
            var reservations = reservationService.GetReservationByBook(id);
            var reservationsDTO = mapper.Map<List<Reservation>, List<ReservationViewDTO>>(reservations);
            return View(reservationsDTO);
        }

        // POST: Library/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,AuthorName,ReleaseDate,Description")] BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                bookServices.AddBook(bookDTO);
            }
            return RedirectToAction("Index");
        }

        // GET: Library/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = bookServices.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(mapper.Map<BookDTO>(book));
        }

        // POST: Library/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,AuthorName,ReleaseDate,Description")] BookDTO book, int id)
        {
            if (ModelState.IsValid)
            {
                bookServices.UpdateBook(book, id);
            }
            return RedirectToAction("Index");
        }
    }
}
