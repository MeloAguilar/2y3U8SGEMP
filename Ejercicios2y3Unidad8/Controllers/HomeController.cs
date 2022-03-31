using Ejercicios2y3Unidad8.Models;
using Ejercicios2y3Unidad8.Models.Entities;
using Ejercicios2y3Unidad8.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicios2y3Unidad8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PersonasViewModel personasVm = new PersonasViewModel();
        private List<clsPersona> personas = new List<clsPersona>();
        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
            personas = personasVm.personas;

        }

        public IActionResult Index()
        {
            return View(personas);
        }

        [HttpPost]
        public IActionResult Index(string nombre, string apellidos)
        {
            @ViewBag.nombre = nombre;
            @ViewBag.apellidos = apellidos;
            return View("Saludo");
        }

        public IActionResult Editar(int Id)
        {
            return View(personasVm.SeleccionarPersona(Id));
        }

        [HttpPost]
        public IActionResult Editar(clsPersona persona)
        {
            foreach (clsPersona item in personas)
            {
                if (item.Id == persona.Id)
                {
                    item.Nombre = persona.Nombre;
                    item.Apellidos = persona.Apellidos;
                    item.FechaNac = persona.FechaNac;
                }

            }
            return View("PersonaModificada", persona);
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
}