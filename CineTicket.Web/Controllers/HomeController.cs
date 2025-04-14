using CineTicket.Core.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CineTicket.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;


    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        this._unitOfWork = unitOfWork;
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
