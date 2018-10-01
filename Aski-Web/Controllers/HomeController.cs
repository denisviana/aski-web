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

        private HttpClient client = RestClient.getInstance();

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

                return View(user);
            }

            return View();
        }
    }
}