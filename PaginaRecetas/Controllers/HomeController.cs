using Microsoft.AspNetCore.Mvc;
using PaginaRecetas.Data;
using PaginaRecetas.Models;
using SQLitePCL;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PaginaRecetas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger; 


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       /* public HomeController(ApplicationDbContext contex)
        {
            _context = contex;
        } */

        public async Task<IActionResult> Index()
        {
            /*var recetas = _context.receta.ToList();*/
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult sobre()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}