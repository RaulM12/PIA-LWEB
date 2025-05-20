using Microsoft.AspNetCore.Mvc;

namespace PaginaRecetas.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Cuenta()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult signin()
        {
            return View();
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