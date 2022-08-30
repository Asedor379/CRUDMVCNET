using Microsoft.AspNetCore.Mvc;
using CRUDMVCNET.Data;
using CRUDMVCNET.Models;

namespace CRUDMVCNET.Controllers
{
    public class PrincipalController : Controller
    {
        ContactoDatos _contactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            //mostrar la lista de los contactos 
            var oLista = _contactoDatos.Listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //metodo que devuelve solo la vista de los datos 
            return View();
        }

        [HttpPost]

        public IActionResult Guardar(ContactoModel oContacto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            //metodo que se encargara de almacenarlos en la bd
            var resp = _contactoDatos.Guardar(oContacto);

            if (resp)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Editar(int IdContacto)
        {
            //metodo que devuelve solo la vista de los datos 
            var oContacto = _contactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            //metodo que se encargara de almacenarlos en la bd
            var resp = _contactoDatos.Editar(oContacto);

            if (resp)
                return RedirectToAction("Listar");
            else
                return View();

        }

        public IActionResult Eliminar(int IdContacto)
        {
            //metodo que devuelve solo la vista de los datos 
            var oContacto = _contactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
            
            //metodo que se encargara de almacenarlos en la bd
            var resp = _contactoDatos.Eliminar(oContacto.IdContacto);

            if (resp)
                return RedirectToAction("Listar");
            else
                return View();

        }
    }
}
