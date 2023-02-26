using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeartDisease.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

/* deleting data page */
namespace HeartDiseaseWebApp.Pages.Hearts
{
    public class DeleetModel : PageModel
    {
        public Heart heart = new();
        public string errorMessage = "";
        public string successMessage = "";
        public async void OnGet()
        {
            string id = Request.Query["id"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/");
                //HTTP GET
                var responseTask = client.GetAsync("Heart/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    heart = JsonConvert.DeserializeObject<Heart>(readTask);
                }
            }
        }

        public async void OnPost()
        {
            bool isDeleted = false;
            int id = int.Parse(Request.Form["id"]);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281");

                var response = await client.DeleteAsync("/Heart/" + id);
                if (response.IsSuccessStatusCode)
                {
                    isDeleted = true;
                }
            }

            if (isDeleted)
            {
                successMessage = "Successfully deleted";
            }
            else
            {
                errorMessage = "Error deleted";
            }
        }
    }
}
