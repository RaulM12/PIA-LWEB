using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PaginaRecetas.Models;

namespace PaginaRecetas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class UsuariosController : Controller
{
    private readonly ConexionMySQL _conexion;

    public UsuariosController(ConexionMySQL conexion)
    {
        _conexion = conexion;
    }

    public async Task<IActionResult> Index()
    {
        var listaUsuarios = await _conexion.ObtenerUsuarios();
        return View(listaUsuarios);
    }
}

