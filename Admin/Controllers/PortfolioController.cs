using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Admin.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Token") == null)
            {
                return Redirect("/Account/Login");
            }
            ViewBag.Name = HttpContext.Session.GetString("FirstName") + ' ' + HttpContext.Session.GetString("LastName");
            return View();
        }

        public IActionResult AddPortfolioDetail()
        {
            if (HttpContext.Session.GetString("Token") == null)
            {
                return Redirect("/Account/Login");
            }
            ViewBag.Name = HttpContext.Session.GetString("FirstName") + ' ' + HttpContext.Session.GetString("LastName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPortfolioDetail(PersonalInfoViewModel Personalinfo)
        {
            using (HttpClient client = new HttpClient())
            {
                MultipartFormDataContent multiForm = new MultipartFormDataContent();
                IFormFile file = Personalinfo.Backgroundimg;
                if (file.Length > 0)
                {
                    ByteArrayContent bytes;
                    byte[] data;
                    using (var br = new BinaryReader(file.OpenReadStream()))
                    {
                       data = br.ReadBytes((int)file.Length);
                    }
                    bytes = new ByteArrayContent(data);
                    //multiForm.Add(bytes, "Backgroundimg",file.FileName); 
                    Personalinfo.Backgroundimgbyte = bytes;
                }
                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Portfolio/AddOrUpdatePersonalInfo", Personalinfo);
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var Result = JsonConvert.DeserializeObject<Response<string>>(Data);

                    //return Redirect("/Admin/Dashboard");
                    return View();

                }
                else
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var Result = JsonConvert.DeserializeObject<Response<string>>(Data);
                    Console.WriteLine("Internal server Error");
                    return View();
                }
            }
        }
    }
}
