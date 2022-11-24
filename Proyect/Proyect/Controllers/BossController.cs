using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Proyect.Controllers
{
    public class BossController : Controller
    {
        private readonly sistemaventasContext context;

        public BossController(sistemaventasContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Validar(Admin boss)
        {            
            if (ModelState.IsValid)
            {
                var ObjEncontrado = 
                    (from TAdmin in context.Admins
                     where TAdmin.Nombre == boss.Nombre && 
                     TAdmin.Password == boss.Password
                     select TAdmin).FirstOrDefault();
                if (ObjEncontrado == null)
                {
                
                    return View("Index");
                }
                else
                {
                    HttpContext.Session.SetString("sadmin", JsonConvert.SerializeObject(ObjEncontrado));
                    return RedirectToAction("Index", "Usuario");
                }
            }
            else
            {
                Console.WriteLine("Llego acaaaaaaaaaaaa");

                return View("Index");
            }
        }
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Boss");
        }
    }
}
