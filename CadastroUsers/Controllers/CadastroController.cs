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
    public class CadastroController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUsuario(Usuarios usuario)
        {
            try
            {
                new UsuarioNegocios().CreateUsuario(usuario);

                return new JsonResult() { Data = new { Success = true } };
            }
            catch (ValidationException ex)
            {
                return new JsonResult { Data = new { Success = false } };
            }
           
        }

        //public ActionResult ListarUsuarios()
        //{
        //    try
        //    {
        //        // Chame o método no seu negócio ou serviço que retorna a lista de usuários
        //        new UsuarioNegocios().ListarUsuarios();

        //       
        //    }
        //    catch (Exception ex)
        //    {
        //        // Se ocorrer algum erro, retorne um JSON indicando o erro
        //        return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}