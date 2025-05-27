using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaginaRecetas.Data;

namespace PaginaRecetas.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminController
        public ActionResult Estadisticas()
        {
            return View();
        }
        public ActionResult GestionUsuarios()
        {
            var usuarios = _context.usuario.ToList();
            return View(usuarios);
        }
        public ActionResult GestionFiltros()
        {
            return View();
        }
        public ActionResult GestionElementosDestacados()
        {
            return View();
        }
        public ActionResult Reportes()
        {
            var reportes_recetas = _context.reporte_Recetas.ToList();
            return View(reportes_recetas);
        }
        public ActionResult RecetasNuevas()
        {
            var recetas = _context.receta.ToList();
            return View(recetas);
        }

        public ActionResult FiltroTipo()
        {
            var tipo = _context.tipos.ToList();
            return View(tipo);
        }

        public ActionResult FiltroComplejidad()
        {
            var complejidad = _context.complejidades.ToList();
            return View(complejidad);
        }

        public ActionResult FiltroTiempo()
        {
            var tiempo = _context.tiempos.ToList();
            return View(tiempo);
        }

        public ActionResult FiltroRegion()
        {
            var region = _context.regiones.ToList();
            return View(region);
        }


        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}