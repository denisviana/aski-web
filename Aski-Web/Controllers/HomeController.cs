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
    public class HomeController : Controller
    {

        HttpClient client = RestClient.getInstance();

        public ActionResult Index()
        {

            var response = client.GetAsync("api/disciplines").Result;
            var disciplines = new List<Discipline>();

            if (response.IsSuccessStatusCode)
            {
                disciplines = response.Content.ReadAsAsync<List<Discipline>>().Result;
            }

            var homeViewModel = new HomeViewModel
            {
                Disciplines = disciplines
            };

            return View (homeViewModel);
        }

        [HttpPost]
        public ActionResult GetSpecialistUsers(string data)
        {

            var response = client.GetAsync("api/users/specialistsusers/"+ data).Result;

            var users = new List<User>();

            if (response.IsSuccessStatusCode)
            {
                users = response.Content.ReadAsAsync<List<User>>().Result;
            }

            return Json(users, JsonRequestBehavior.AllowGet);
        }

    }


}
