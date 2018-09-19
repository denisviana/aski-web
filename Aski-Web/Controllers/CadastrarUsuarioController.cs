using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aski_Web.Controllers
{
    public class CadastrarUsuarioController : Controller
    {

        public ActionResult CadastrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult _PartialStepOne()
        {
            return PartialView("~/Views/CadastrarUsuario/_PartialCadastrarUsuarioStep2.cshtml");
        }

        [HttpPost]
        public PartialViewResult _PartialStepTwo()
        {
            return PartialView("~/Views/CadastrarUsuario/_PartialCadastrarUsuarioStep3.cshtml");
        }

    }
}