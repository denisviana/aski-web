using System.Net.Http;
using System.Web.Mvc;
using Aski_Web.Network;
using System.Threading.Tasks;
using Aski_Web.Models;
using System.Collections.Generic;

namespace Aski_Web.Areas.Admin.Controllers
{
    public class DisciplinesController : Controller
    {

        private HttpClient client = RestClient.getInstance();

        public ActionResult Home()
        {
            var response = client.GetAsync("api/disciplines").Result;
            List<Discipline> disciplines = new List<Discipline>();

            if (response.IsSuccessStatusCode)
            {
                disciplines = response.Content.ReadAsAsync<List<Discipline>>().Result;
            }

            return View(disciplines);
        }

        public ActionResult Cadastrar(){
            return View();
        }

        public ActionResult Editar(string id)
        {

            var response = client.GetAsync("api/disciplines/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var discipline = response.Content.ReadAsAsync<Discipline>().Result;
                return View(discipline);
            }

            ViewBag.ToastMsg = "Falha ao recuperar os dados";
            return View();
        }


        //Save Discipline
        [HttpPost]
        public ActionResult Cadastrar(Discipline discipline){

            HttpResponseMessage response = client.PostAsJsonAsync("api/disciplines/create", discipline).Result;

            if (ModelState.IsValid)
            {
                if (response.IsSuccessStatusCode)
                {
                    ModelState.Clear();
                    ViewBag.ToastMsg = "Disciplina cadastrada com sucesso";
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                        ViewBag.ToastMsg = "Já existe uma disciplina com o mesmo nome";
                    else
                        ViewBag.ToastMsg = "Falha ao cadastrar a disciplina";

                    return View(discipline);
                }

            }

            return View();
        }

        [HttpPost]
        public ActionResult EditarDisciplina(Discipline discipline)
        {

            if (ModelState.IsValid)
            {

                var response = client.PutAsJsonAsync("api/disciplines/update/" + discipline.Id, discipline).Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.ToastMsg = "Disciplina atualizada com sucesso";
                    ModelState.Clear();
                    return RedirectToAction("Home", "Disciplines");
                }

                ViewBag.ToastMsg = "Falha ao atualizar a disciplina";
                return View("Editar",discipline);

            }
            return View("Editar",discipline);

        }


        //Get all disciplines
        public ActionResult GetAllDisciplinesAsync(){

            HttpResponseMessage response = client.GetAsync("api/disciplines").Result;
            List<Discipline> disciplines = new List<Discipline>();

            if(response.IsSuccessStatusCode){
                disciplines = response.Content.ReadAsAsync<List<Discipline>>().Result;
            }

            return View(disciplines);
        }


        //Get discipline by id
        public ActionResult GetDisciplineByIdAsync(string id)
        {

            HttpResponseMessage response = client.GetAsync("api/disciplines/"+id).Result;
            List<Discipline> disciplines = new List<Discipline>();

            if (response.IsSuccessStatusCode)
            {
                disciplines = response.Content.ReadAsAsync<List<Discipline>>().Result;
            }

            return View(disciplines);
        }        


        //Delete discipline
        public ActionResult Delete(string id)
        {

            HttpResponseMessage response = client.DeleteAsync("api/disciplines/delete/"+id).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.ToastMsg = "Disciplina removida com sucesso";
                return RedirectToAction("Home", "Disciplines");
            }

            ViewBag.TostMsg = "Falha ao remover disciplina";
            return RedirectToAction("Home", "Disciplines");
        }



    }
}
