using Microsoft.AspNetCore.Mvc;
using PaginaRecetas.Data;
using System.Threading.Tasks;
using static PaginaRecetas.Data.ApplicationDbContext;

namespace PaginaRecetas.Controllers
{
    public class RecetaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mostrar todas las recetas
        public IActionResult Index()
        {
            var recetas = _context.receta.ToList();
            return View(recetas);
        }

        // GET: Formulario para crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Crear receta
        [HttpPost]
        public async Task<IActionResult> Crear(recetas model)
        {
            if (ModelState.IsValid)
            {
                model.fecha_creacion = DateTime.Now;
                model.visitas = 0;
                _context.receta.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}