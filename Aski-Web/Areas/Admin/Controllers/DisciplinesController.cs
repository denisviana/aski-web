using System.Net.Http;
using System.Web.Mvc;
using Aski_Web.Network;
using System.Threading.Tasks;
using Aski_Web.Models;
using System.Collections;
using System.Collections.Generic;

namespace Aski_Web.Areas.Admin.Controllers
{
    public class DisciplinesController : Controller
    {

        private HttpClient client = RestClient.getInstance();

        public async Task<ActionResult> Home()
        {
            HttpResponseMessage response = await client.GetAsync("api/disciplines");
            List<Discipline> disciplines = new List<Discipline>();

            if (response.IsSuccessStatusCode)
            {
                disciplines = response.Content.ReadAsAsync<List<Discipline>>().Result;
            }

            return View();
        }


        //Save Discipline
        public async Task<ActionResult> SaveDisciplineAsync(Discipline discipline){

            HttpResponseMessage response = await client.PostAsJsonAsync("", discipline);

            if(response.IsSuccessStatusCode){

                return View();

            }

            return View();
        }


        //Get all disciplines
        public async Task<ActionResult> GetAllDisciplinesAsync(){

            HttpResponseMessage response = await client.GetAsync("api/disciplines");
            List<Discipline> disciplines = new List<Discipline>();

            if(response.IsSuccessStatusCode){
                disciplines = response.Content.ReadAsAsync<List<Discipline>>().Result;
            }

            return View(disciplines);
        }


        //Get discipline by id
        public async Task<ActionResult> GetDisciplineByIdAsync(string id)
        {

            HttpResponseMessage response = await client.GetAsync("api/disciplines/{id}");
            List<Discipline> disciplines = new List<Discipline>();

            if (response.IsSuccessStatusCode)
            {
                disciplines = response.Content.ReadAsAsync<List<Discipline>>().Result;
            }

            return View(disciplines);
        }


        //Update discipline
        public async Task<ActionResult> UpdateDisciplineAsync(Discipline discipline)
        {

            HttpResponseMessage response = await client.PutAsJsonAsync("$api/disciplines/{discipline.Id}", discipline);

            if (response.IsSuccessStatusCode)
            {

                return View();

            }

            return View();
        }


        //Delete discipline
        public async Task<ActionResult> UpdateDisciplineAsync(string id)
        {

            HttpResponseMessage response = await client.DeleteAsync("$api/disciplines/{id}");

            if (response.IsSuccessStatusCode)
            {

                return View();

            }

            return View();
        }



    }
}
