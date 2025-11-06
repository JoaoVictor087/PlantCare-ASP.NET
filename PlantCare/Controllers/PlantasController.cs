using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlantCare.Models;
using PlantCare.Persistencia;

namespace PlantCare.Controllers
{
    public class PlantaController : Controller
    {
        private readonly PlantCareContext _context;

        public PlantaController(PlantCareContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult ListarPlantas()
        {
            var lista = _context.Plantas
                .Include(p => p.Usuario) 
                .ToList();

            return View(lista);
        }

        public IActionResult BuscarPlanta(string busca)
        {
            if (string.IsNullOrEmpty(busca))
            {
                return RedirectToAction("ListarPlantas");
            }

            var plantasFiltradas = _context.Plantas
                .Include(p => p.Usuario)
                .Where(p => p.NmPlanta.Contains(busca) || p.TipoPlanta.Contains(busca))
                .ToList();

            return View("ListarPlantas", plantasFiltradas);
        }

        
        [HttpGet]
        public IActionResult CadastrarPlanta()
        {
            
            ViewBag.Usuarios = _context.Usuarios
                                        .Select(u => new { u.IdUsuario, u.NmUsuario })
                                        .ToList();

            return View();
        }

        
        [HttpPost]
        public IActionResult CadastrarPlanta(Planta planta)
        {
            if (ModelState.IsValid)
            {
                _context.Plantas.Add(planta);
                _context.SaveChanges();
                return RedirectToAction("CadastrarPlanta"); 
            }

            
            ViewBag.Usuarios = new SelectList(_context.Usuarios.ToList(), "IdUsuario", "NmUsuario", planta.IdUsuario);
            return View(planta);
        }

      
        [HttpGet]
        public IActionResult EditarPlanta(int id)
        {
            var planta = _context.Plantas.Find(id);
            if (planta == null) return NotFound();

            ViewBag.Usuarios = new SelectList(_context.Usuarios.ToList(), "IdUsuario", "NmUsuario", planta.IdUsuario);
            return View(planta);
        }

        
        [HttpPost]
        public IActionResult EditarPlanta(Planta planta)
        {
            if (ModelState.IsValid)
            {
                _context.Plantas.Update(planta);
                _context.SaveChanges();
                return RedirectToAction("ListarPlantas");
            }

            ViewBag.Usuarios = new SelectList(_context.Usuarios.ToList(), "IdUsuario", "NmUsuario", planta.IdUsuario);
            return View(planta);
        }


        [HttpGet]
        public IActionResult DetalharPlanta(int id)
        {
            var planta = _context.Plantas
                                .Include(p => p.Usuario)
                                .FirstOrDefault(p => p.IdPlanta == id);

            if (planta == null)
                return NotFound();

            return View(planta);
        }

        [HttpGet]
        public IActionResult DeletarPlanta(int id)
        {
            var planta = _context.Plantas
                                 .Include(p => p.Usuario)
                                 .FirstOrDefault(p => p.IdPlanta == id);

            if (planta == null)
                return NotFound();

            return View(planta);
        }

        
        [HttpPost]
        public IActionResult DeletarConfirmado(int idPlanta)
        {
            var planta = _context.Plantas.Find(idPlanta);
            if (planta != null)
            {
                _context.Plantas.Remove(planta);
                _context.SaveChanges();
            }

            return RedirectToAction("ListarPlantas");
        }
    }
}
