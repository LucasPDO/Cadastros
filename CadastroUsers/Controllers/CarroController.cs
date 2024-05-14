using ProjetoUsuariosClassLibrary.Entidade;
using ProjetoUsuariosClassLibrary.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroUsers.Controllers
{
    public class CarroController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateCarro(Carro carro)
        {
            try
            {
                new CarroNegocios().CreateCarro(carro);
                return new JsonResult() { Data = new { Success = true } };
            }
            catch (ValidationException ex)
            {
                return new JsonResult { Data = new { Success = false } };
            }

        }
    }
}