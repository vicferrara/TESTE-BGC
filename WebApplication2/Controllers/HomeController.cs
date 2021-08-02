using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        private static List<Cliente> clientes;

        public ActionResult Index()
        {
            if (clientes == null)
                clientes = new Cliente().GetAll();

            return View(clientes);
        }

        public ActionResult NovoCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InserirCliente(Cliente cliente)
        {
            if (String.IsNullOrEmpty(cliente.nome))
                return View("NovoCliente", cliente);

            if (String.IsNullOrEmpty(cliente.cep))
                return View();

            if (ModelState.IsValid)
            {
                cliente.Inserir(cliente);

                return RedirectToAction("Index");
            }
            else
            {
                return View("NovoCliente", cliente);
            }

        }
        
    }
}