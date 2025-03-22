using BoniboNews.Data;
using BoniboNews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BoniboNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("Index")]
        [Route("Home")]
        [Route("")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            var results = _context.Items.ToList();
            return View("Index",results);
        }

        [Route("AllItem")]
        [Route("Items")]
        public IActionResult GetAllItems()
        {
            var results = _context.Items
                .ToList();
            return View("AllItems", results);
        }

        public IActionResult Details(int id)
        {
            var items = _context.Items
                .FirstOrDefault(c => c.Id == id);

            if (items == null)
                return NotFound();

            var detailsViewModel = new DetailsViewModel()
            {
                Items = items
            };

            return View(detailsViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}