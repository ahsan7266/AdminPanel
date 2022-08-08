using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

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
                if (Personalinfo.Backgroundimg is not null)
                {
                    using (var ms = new MemoryStream())
                    {
                        Personalinfo.Backgroundimg.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        Personalinfo.BackgroundBas64 = Convert.ToBase64String(fileBytes);

                        byte[] bytes = Convert.FromBase64String(Personalinfo.BackgroundBas64);
                        MemoryStream stream = new MemoryStream(bytes);
                        IFormFile file = new FormFile(stream, 0, bytes.Length, Personalinfo.Backgroundimg.Name, Personalinfo.Backgroundimg.FileName);
                    }
                }

                if (Personalinfo.Profileimg is not null)
                {
                    using (var ms = new MemoryStream())
                    {
                        Personalinfo.Profileimg.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        Personalinfo.ProfileBas64 = Convert.ToBase64String(fileBytes);
                    }
                }

                if (Personalinfo.Cv is not null)
                {
                    using (var ms = new MemoryStream())
                    {
                        Personalinfo.Cv.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        Personalinfo.CvBas64 = Convert.ToBase64String(fileBytes);
                    }
                }

                PersonalInfoViewModel model = new PersonalInfoViewModel();
                model.PeronalInfoId = Personalinfo.PeronalInfoId;
                model.BackgroundBas64 = Personalinfo.BackgroundBas64;
                model.BackgroundName = Personalinfo.Backgroundimg.Name;
                model.BackgroundFileName = Personalinfo.Backgroundimg.FileName;
                model.ProfileBas64 = Personalinfo.ProfileBas64;
                model.ProfileName = Personalinfo.Profileimg.Name;
                model.ProfileFileName = Personalinfo.Profileimg.FileName;
                model.CvBas64 = Personalinfo.CvBas64;
                model.CvName = Personalinfo.Cv.Name;
                model.CvFileName = Personalinfo.Cv.FileName;
                model.FirstName = Personalinfo.FirstName;
                model.LastName = Personalinfo.LastName;
                model.Email = Personalinfo.Email;
                model.PhoneNumber = Personalinfo.PhoneNumber;
                model.Country = Personalinfo.Country;
                model.City = Personalinfo.City;
                model.Age = Personalinfo.Age;
                model.Detail = Personalinfo.Detail;
                model.Experience = Personalinfo.Experience;

                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Portfolio/AddOrUpdatePersonalInfo", model);
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
