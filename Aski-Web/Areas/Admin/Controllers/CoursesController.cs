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

        public ActionResult Editar(String id){

            var response = client.GetAsync("api/courses/" + id).Result;

            if(response.IsSuccessStatusCode){
                var course = response.Content.ReadAsAsync<Course>().Result;
                return View(course);
            }
               

            ViewBag.ToastMsg = "Falha ao recuperar os dados";

            return View(new Course());

        }


        //Save course
        [HttpPost]
        public ActionResult Cadastrar(Course course)
        {

            if (ModelState.IsValid)
            {
                var response = client.PostAsJsonAsync("api/courses", course).Result;

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.ToastMsg = "Cadastro realizado com sucesso.";
                    ModelState.Clear();
                    return View();
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    ViewBag.ToastMsg = "Já existe um curso com o mesmo nome.";
                else
                    ViewBag.ToastMsg = "Falha ao cadastrar o curso.";

                return View(course);

            }
            return View(course);
        }


        [HttpPost]
        public ActionResult EditarCurso(Course course){

            if (ModelState.IsValid)
            {

                var response = client.PutAsJsonAsync("api/courses/" + course.Id, course).Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.ToastMsg = "Curso atualizado com sucesso";
                    ModelState.Clear();
                    return RedirectToAction("Home", "Courses");
                }

                ViewBag.ToastMsg = "Falha ao atualizar o curso";
                return View(course);

            }
            return View(course);

        }

        public ActionResult RemoverCurso(String id){

            var response = client.DeleteAsync("api/courses/"+id).Result;

            if (response.IsSuccessStatusCode)
                ViewBag.ToastMsg = "Curso removido com sucesso";

            else
            {
                ViewBag.ToastMsg = "Falha ao remover o curso";
                return View();
            }

            return RedirectToAction("Home","Courses");

        }
    }
}