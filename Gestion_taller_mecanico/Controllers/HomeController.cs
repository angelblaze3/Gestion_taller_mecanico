using Microsoft.AspNetCore.Mvc;

namespace Gestion_taller_mecanico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Por ahora los contadores están en cero.
            // Cuando existan los módulos, aquí se consultará MongoDB.
            ViewData["TotalClientes"] = 0;
            ViewData["VehiculosEnTaller"] = 0;
            ViewData["OrdenesAbiertas"] = 0;
            ViewData["RefaccionesBajoStock"] = 0;

            return View();
        }

        // Requerido por Program.cs para los errores en producción
        public IActionResult Error()
        {
            return Content("Ocurrió un error.");
        }
    }
}