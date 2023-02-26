using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeartDisease.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

/* Display all data page */
namespace HeartDiseaseWebApp.Pages.Hearts
{
    public class IndexModel : PageModel
    {
            public List<Heart> Hearts = new();
            public async void OnGet()
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7281/");
                    //HTTP GET
                    var responseTask = client.GetAsync("Heart");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        Hearts = JsonConvert.DeserializeObject<List<Heart>>(readTask);

                    }
                }
            }
        }
}
