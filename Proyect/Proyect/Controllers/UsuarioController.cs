using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyect.Models;
using Newtonsoft.Json;

namespace Proyect.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly sistemaventasContext context;

        public UsuarioController(sistemaventasContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            
            var ObjSesion = HttpContext.Session.GetString("sadmin");
            if(ObjSesion != null)
            {
                
                var Obj = JsonConvert.DeserializeObject<Admin>
                    (HttpContext.Session.GetString("sadmin"));
                ViewBag.adm = Obj.IdAdmin + "" + Obj.Nombre;
                return View();
            }
            else
            {
                System.Environment.Exit(1);
                return RedirectToAction("Index", "Boss");
            }
        }

        public IActionResult Registro()
        {
            var list = context.Users;
            return View(list);
        }

        public IActionResult RegistroProducto()
        {
            var list = context.Products;
            return View(list);
        }
        public IActionResult Ventas()
        {
            var list = context.Ventas;
            return View(list);

        }
        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult CreateUsuario(User objUs)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(objUs);

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create");
            }
        }
        [Route("Usuario/DeleteU/{Cod}")] //Delete Usuario
        public IActionResult DeleteU(int Cod) //aqui recibe el codigo del id
        {
            /*LINQ * lambda*/
            var objUsu = (from Talu in context.Users
                          where Talu.Id == Cod
                          select Talu).Single();
            context.Users.Remove(objUsu);
            context.SaveChanges();

            return RedirectToAction("Registro");
        }
        //EDIT USUARIO

        [Route("Usuario/EditU/{Codigo}")]
        public IActionResult EditU(int Codigo)
        {
            var objProd = (from Talu in context.Users
                           where Talu.Id == Codigo
                           select Talu
                                 ).Single();

            ViewData["id"] = objProd.Id;
            ViewData["nom"] = objProd.Name;
            ViewData["user"] = objProd.Username;
            ViewData["pass"] = objProd.Password;

            return View();
        }
        public IActionResult EditUser(User ObjNew)
        {
            if (ModelState.IsValid)
            {
                var ObjOld = (from Talu in context.Users
                              where Talu.Id == ObjNew.Id
                              select Talu
                                     ).Single();

                ObjOld.Name = ObjNew.Name;
                ObjOld.Username = ObjNew.Username;
                ObjOld.Password = ObjNew.Password;
                

                context.SaveChanges();

                return RedirectToAction("Registro");
            }
            else
            {
                return View("Edit");
            }
        }

        public IActionResult Create2()
        {
            return View();
        }

        public IActionResult CreateProducto(Product objProd)  
        {
            if(ModelState.IsValid)
            {
                context.Products.Add(objProd);
                context.SaveChanges();

                return RedirectToAction("RegistroProducto"); //aqui te devuelve a donde redirecciona
            }
            else
            {
               
                return View("Create2");
            }
        }
        public IActionResult Create3()
        {

            //var ObjProd =
            //    (from Tprod in context.Products
            //    select Tprod.Nombre).First();

            //ViewData["producto"]=ObjProd;

            var list = context.Products;
            return View(list);
            //ViewBag.Prod = context.Products;
            //return View();
        }

        //CREAR VENTA
        public IActionResult CreateVenta(Venta objVenta)
        {
            if (ModelState.IsValid)
            {
                context.Ventas.Add(objVenta);
                context.SaveChanges();

                return RedirectToAction("Ventas"); //aqui te devuelve a donde redirecciona
            }
            else
            {

                return View("Create3");
            }
        }
        //CREAR DETALLE DE VENTA
        public IActionResult CreateVentaDetalle(VentaDetalle objVentaDetalle)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("holiii");
                Console.WriteLine(objVentaDetalle);
                Console.WriteLine("holiii");
                context.VentaDetalles.Add(objVentaDetalle);
                context.SaveChanges();

                return RedirectToAction("Create3"); //aqui te devuelve a donde redirecciona
            }
            else
            {

                return View("Ventas");
            }
        }
        //BORRAR USUARIO
        [Route("Usuario/Delete/{Codigo}")]
        public IActionResult Delete(int Codigo) //aqui recibe el codigo del id
        {
            /*LINQ * lambda*/
            var objAlu = (from Talu in context.Products
                          where Talu.IdProducto == Codigo
                          select Talu).Single();
            context.Products.Remove(objAlu);
            context.SaveChanges();

            return RedirectToAction("RegistroProducto");
        }

        [Route("Usuario/Edit/{Codigo}")]
        public IActionResult Edit(int Codigo)
        {
            var objProd = (from Talu in context.Products
                          where Talu.IdProducto == Codigo
                          select Talu
                                 ).Single();

            ViewData["id"] = objProd.IdProducto;
            ViewData["nom"] = objProd.Nombre;
            ViewData["cant"] = objProd.Cantidad;
            ViewData["pcom"] = objProd.PrecioCompra;
            ViewData["pven"] = objProd.PrecioVenta;
            
            return View();
        }
        public IActionResult EditProducto(Product ObjNew)
        {
            if (ModelState.IsValid)
            {
                var ObjOld = (from Talu in context.Products
                              where Talu.IdProducto == ObjNew.IdProducto
                              select Talu
                                     ).Single();

                ObjOld.Nombre = ObjNew.Nombre;
                ObjOld.Cantidad = ObjNew.Cantidad;
                ObjOld.PrecioCompra = ObjNew.PrecioCompra;
                ObjOld.PrecioVenta = ObjNew.PrecioVenta;

                context.SaveChanges();

                return RedirectToAction("RegistroProducto");
            }
            else
            {
                return View("Edit");
            }
        }
    }

}
