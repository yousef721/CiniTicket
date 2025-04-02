using CineTicket.Core.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CineTicket.Web.Areas.Customer.Controllers
{
    [Area(nameof(Customer))]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var movies = _unitOfWork.MovieRepository.Read().ToList();
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
