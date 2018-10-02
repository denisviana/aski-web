using Aski_Web.Models;
using Aski_Web.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Aski_Web.Controllers
{
    public class CadastrarUsuarioController : Controller
    {

        HttpClient client = RestClient.getInstance();

        public ActionResult Index()
        {
            var response = client.GetAsync("api/disciplines").Result;           

            if (response.IsSuccessStatusCode)
            {
                var disciplines = response.Content.ReadAsAsync<List<Discipline>>().Result;
                var user = new User
                {
                    HasDomainIn = disciplines,
                    HasDificultyIn = disciplines
                };

                var usuarioViewModel = new UsuarioViewModel
                {
                    User = user
                };

                return View(usuarioViewModel);
            }

            return View();
        }


        [HttpPost]
        public JsonResult SaveUser(UsuarioViewModel usuarioViewModel){

            var hasDificultyInIds = new List<Discipline>();
            var hasDomainInIds = new List<Discipline>();

            for(int i=0; i<usuarioViewModel.HasDificultyIn.Count; i++)
            {
                hasDificultyInIds.Add(new Discipline {
                    Id = usuarioViewModel.HasDificultyIn[i]
                });
            }

            for(int i=0; i<usuarioViewModel.HasDomainIn.Count; i++)
            {
                hasDomainInIds.Add(new Discipline
                {
                    Id = usuarioViewModel.HasDomainIn[i]
                });
            }

            var user = usuarioViewModel.User;
            user.HasDificultyIn = hasDificultyInIds;
            user.HasDomainIn = hasDomainInIds;

            var response = client.PostAsJsonAsync("api/user", user).Result;

            if (response.IsSuccessStatusCode)
            {

            }

            return Json(usuarioViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}