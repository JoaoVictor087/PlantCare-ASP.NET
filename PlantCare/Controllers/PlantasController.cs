using Microsoft.AspNetCore.Mvc;
using PlantCare.Models;


namespace PlantCare.Controllers
{
    public class PlantasController : Controller
    {
        private static List<Usuario> usuarios = new()
        {
            new Usuario { IdUsuario = 1, Nome = "Vinicius", Email = "vinicius@plantcare.com", Senha = "1234" },
            new Usuario { IdUsuario = 2, Nome = "Joao", Email = "joao@plantcare.com", Senha = "abcd" },
            new Usuario { IdUsuario = 3, Nome = "Marcel", Email = "marcel@plantcare.com", Senha = "1a2b" }
        };

        private static List<Planta> plantas = new();
        private static int contador = 1;

        public IActionResult ListarPlantas(string busca)
        {
            var lista = string.IsNullOrEmpty(busca)
                ? plantas
                : plantas.Where(p => p.Nome.Contains(busca, StringComparison.OrdinalIgnoreCase)).ToList();
            ViewBag.Usuarios = usuarios;
            return View(lista);
        }

        public IActionResult CadastrarPlanta()
        {
            ViewBag.Usuarios = usuarios;
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarPlanta(Planta planta)
        {
            planta.IdPlanta = contador++;
            planta.DataCadastro = DateTime.Now;
            planta.IdUsuario = planta.IdUsuario;
            plantas.Add(planta);
            return RedirectToAction("ListarPlantas");
        }

        public IActionResult EditarPlanta(int id)
        {
            var planta = plantas.FirstOrDefault(p => p.IdPlanta == id);
            ViewBag.Usuarios = usuarios;
            return View(planta);
        }

        [HttpPost]
        public IActionResult EditarPlanta(Planta planta)
        {
            var p = plantas.FirstOrDefault(x => x.IdPlanta == planta.IdPlanta);
            p.Nome = planta.Nome;
            p.TipoPlanta = planta.TipoPlanta;
            p.IdUsuario = planta.IdUsuario;
            p.IdUsuario = planta.IdUsuario;
            return RedirectToAction("ListarPlantas");
        }

        public IActionResult DetalharPlanta(int id)
        {
            var planta = plantas.FirstOrDefault(p => p.IdPlanta == id);
            ViewBag.Usuarios = usuarios;
            return View(planta);
        }

        public IActionResult DeletarPlanta(int id)
        {
            var planta = plantas.FirstOrDefault(p => p.IdPlanta == id);
            return View(planta);
        }

        [HttpPost, ActionName("DeletarPlanta")]
        public IActionResult ConfirmarDelete(int id)
        {
            plantas.RemoveAll(p => p.IdPlanta == id);
            return RedirectToAction("ListarPlantas");
        }
    }
}