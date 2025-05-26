using Microsoft.AspNetCore.Mvc;
using PaginaRecetas.Data;
using PaginaRecetas.Models;
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

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                _context.usuario.Add(usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(usuario);
        }

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
