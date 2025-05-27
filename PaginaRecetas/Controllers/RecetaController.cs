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

        // GET: Editar receta
        public IActionResult Editar(int id)
        {
            var receta = _context.receta.FirstOrDefault(r => r.id == id);
            if (receta == null)
            {
                return NotFound();
            }
            return View("EditarReceta", receta);
        }

        // POST: Guardar cambios
        [HttpPost]
        public async Task<IActionResult> Editar(recetas model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditarReceta", model);
            }

            var recetaExistente = await _context.receta.FindAsync(model.id);
            if (recetaExistente == null)
            {
                return NotFound();
            }

            recetaExistente.titulo = model.titulo;
            recetaExistente.descripcion = model.descripcion;
            // Agrega aquí más campos si los deseas actualizar

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Confirmar eliminación
        public IActionResult Eliminar(int id)
        {
            var receta = _context.receta.FirstOrDefault(r => r.id == id);
            if (receta == null)
            {
                return NotFound();
            }
            return View(receta);
        }

        // POST: Ejecutar eliminación
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var receta = _context.receta.FirstOrDefault(r => r.id == id);
            if (receta != null)
            {
                _context.receta.Remove(receta);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}