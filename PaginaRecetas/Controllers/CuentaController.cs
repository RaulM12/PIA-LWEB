using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using PaginaRecetas.Data;
using PaginaRecetas.Models;
using SQLitePCL;
using static PaginaRecetas.Data.ApplicationDbContext;


namespace PaginaRecetas.Controllers
{
    public class CuentaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Cuenta()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }
        // registro base de datos//

        /* [HttpGet] */
        public IActionResult Signin()
        {
            return View();
        }

        // Registro de usuario
        /* [HttpPost]
        public async Task<IActionResult> Signin(usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                // checar este error

                /*_context.usuarios.Add(usuario);
                await _context.SaveChangesAsync();  // <- Guarda en la base de datos

                return RedirectToAction("Index", "Home"); // <- Redirige después del registro
            }

            return View(usuario); 
        }*/
     

        public IActionResult RecetasPublicadas()
        {
            return View();
        }

        public IActionResult CrearReceta()
        {
            return View();
        }

        public IActionResult EditarCrear()
        {
            return View();
        }
    }
}