using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeartDisease.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

/* Analysis data page */
namespace HeartDiseaseWebApp.Pages.Hearts
{
    public class AnalysisModel : PageModel
    {
        public Heart heart = new();
        public async void OnGet()
        {
            string age = Request.Form["age"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7281/");
                //HTTP GET
                var responseTask = client.GetAsync("Heart/" + age);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    heart = JsonConvert.DeserializeObject<Heart>(readTask);
                }
            }
        }
    }
}
