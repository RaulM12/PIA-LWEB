using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginaRecetas.Data;
using PaginaRecetas.Models;
using System.Security.Claims;
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
            var email = User.Identity.Name; // Asegúrate de que el usuario ha iniciado sesión
            var usuario = _context.usuario.FirstOrDefault(u => u.email == email);
            return View();
        }


        public IActionResult login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> login(usuarios usuario)
        {
            // Buscar al usuario por correo y contraseña
            var userInDb = await _context.usuario
                .FirstOrDefaultAsync(u => u.email == usuario.email && u.contraseña == usuario.contraseña);

            if (userInDb != null)
            {
                // Autenticar al usuario (simplificado)
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userInDb.email)
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("index", "home","Mi Cuenta"); 
            }

            // Si no coincide el usuario, mostrar error
            ModelState.AddModelError("", "Correo o contraseña incorrectos.");
            return View(usuario);
        }

        public IActionResult signin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> signin(usuarios usuario)
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
