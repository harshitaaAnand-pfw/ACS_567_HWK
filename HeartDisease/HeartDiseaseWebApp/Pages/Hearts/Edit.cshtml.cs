using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HeartDisease.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

/* Editing the existing data page */
namespace HeartDiseaseWebApp.Pages.Hearts
{
    public class EditModel : PageModel
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
                    heart = JsonConvert.DeserializeObject<Heart>(readTask); }
            }
        }


        public async void OnPost()
        {
            heart.Id = int.Parse(Request.Form["id"]);
            heart.Description = Request.Form["description"];
            heart.age = int.Parse(Request.Form["age"]);
            heart.IsCompleted = Request.Form["isCompleted"] == "on";

            if(heart.Description.Length == 0)
            {
                errorMessage = "description is required";
            }
            else
            {
                var opt = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };
                string json = System.Text.Json.JsonSerializer.Serialize<Heart>(heart, opt);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5288");
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("Heart", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);

                    if (!result.IsSuccessStatusCode)
                    {
                        errorMessage = "Error editing";
                    }
                    else
                    {
                        successMessage = "Successfully edited";
                    }

                }
            }
        }
    }
}
