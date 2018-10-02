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

            if (response.IsSuccessStatusCode)
            {
                var disciplines = response.Content.ReadAsAsync<List<Discipline>>().Result;
                var user = new User
                {
                    HasDomainIn = disciplines,
                    HasDificultyIn = disciplines
                };

                var homeViewModel = new HomeViewModel
                {
                    User = user
                };

                return View(homeViewModel);
            }

            return View();
        }


        [HttpPost]
        public JsonResult SaveUser(HomeViewModel homeViewModel){

            var hasDificultyInIds = new List<Discipline>();
            var hasDomainInIds = new List<Discipline>();

            for(int i=0; i<homeViewModel.HasDificultyIn.Count; i++)
            {
                hasDificultyInIds.Add(new Discipline {
                    Id = homeViewModel.HasDificultyIn[i]
                });
            }

            for(int i=0; i<homeViewModel.HasDomainIn.Count; i++)
            {
                hasDomainInIds.Add(new Discipline
                {
                    Id = homeViewModel.HasDomainIn[i]
                });
            }

            var user = homeViewModel.User;
            user.HasDificultyIn = hasDificultyInIds;
            user.HasDomainIn = hasDomainInIds;

            var response = client.PostAsJsonAsync("api/user", user).Result;

            if (response.IsSuccessStatusCode)
            {

            }

            return Json(homeViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}