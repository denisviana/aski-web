using Aski_Web.Models;
using Aski_Web.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Aski_Web.Areas.Admin.Controllers
{
    public class CoursesController : Controller
    {

        private HttpClient client = RestClient.getInstance();

        // GET: Admin/Courses
        public ActionResult Home()
        {
            var response = client.GetAsync("api/courses").Result;
            List<Course> courses = new List<Course>();

            if (response.IsSuccessStatusCode)
            {
                courses = response.Content.ReadAsAsync<List<Course>>().Result;
            }

            return View(courses);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }


        //Save course
        [HttpPost]
        public ActionResult Cadastrar(Course course)
        {

            var response = client.PostAsJsonAsync("api/courses", course).Result;

            if (response.IsSuccessStatusCode)
            {

                return View();

            }

            return View();
        }
    }
}