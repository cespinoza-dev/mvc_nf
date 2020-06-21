using Business_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_NF.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        [HttpPost]
        public ActionResult Insert(ClienteBO dto)
        {
            NegCliente obj = new NegCliente();
            obj.Insertar(dto);
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Update(ClienteBO dto)
        {
            NegCliente obj = new NegCliente();
            obj.Actualizar(dto);
            return RedirectToAction("Listar");
        }
        public ActionResult Delete(string DNI)
        {
            NegCliente obj = new NegCliente();
            obj.Eliminar(DNI);
            return RedirectToAction("Listar");
        }
        public ActionResult Listar()
        {
            NegCliente obj = new NegCliente();
            return View(obj.Listar());
        }

        [HttpGet]
        public ActionResult Update(string DNI) {
            NegCliente obj = new NegCliente();
            ClienteBO dto = obj.Listar().FirstOrDefault(a => a.DNI == DNI);
            return View ("Update",dto);
        }

        public ActionResult Insert()
        {
            return View("Insert",new ClienteBO());
        }
    }
}