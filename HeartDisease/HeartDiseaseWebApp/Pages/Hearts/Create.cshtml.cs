using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HeartDisease.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

/* adding and saving data page */
namespace HeartDiseaseWebApp.Pages.Hearts
{
    public class CreateModel : PageModel
    {
        public Heart heart = new();
        public string errorMessage = "";
        public string successMessage = "";

        public async void OnPost()
        {
            heart.Description = Request.Form["description"];
            heart.age = int.Parse(Request.Form["age"]);

            if (heart.Description.Length == 0)
            {
                errorMessage = "Description is required";
            }
            else
            {
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize<Heart>(heart, opt);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7281/");
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("Heart", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);

                    if (!result.IsSuccessStatusCode)
                    {
                        errorMessage = "Error adding";
                    }
                    else
                    {
                        successMessage = "Successfully added";
                    }
                }
            }
        }
    }
}
