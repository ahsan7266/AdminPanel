using Admin.Models;
using Admin.Models.Portfolio;
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
                    ViewBag.personalid = Result.Data;
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

        [HttpPost]
        public async Task<IActionResult> AddOtherDetail(OtherViewModel model)
        {
            using (HttpClient client = new HttpClient())
            {               
                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Portfolio/SkillServiceTool", model);
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var Result = JsonConvert.DeserializeObject<Response<string>>(Data);
                    ViewBag.personalid = Result.Data;
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

        [HttpPost]
        public async Task<IActionResult> ProjectInfo(ProjectViewModel project)
        {
            using (HttpClient client = new HttpClient())
            {
                if (project.Img is not null)
                {
                    using (var ms = new MemoryStream())
                    {
                        project.Img.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        project.ImgBase64 = Convert.ToBase64String(fileBytes);
                    }
                }

                if (project.ProjectFile is not null)
                {
                    using (var ms = new MemoryStream())
                    {
                        project.ProjectFile.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        project.ProjectFileBase64 = Convert.ToBase64String(fileBytes);
                    }
                }

                ProjectViewModel model = new ProjectViewModel();
                model.ProjectId = project.ProjectId;
                model.Name = project.Name;
                model.ImgBase64 = project.ImgBase64;
                model.ImgName = project.Img.Name;
                model.ImgFileName = project.Img.FileName;
                model.ProjectFileBase64 = project.ProjectFileBase64;
                model.ProjectFName = project.ProjectFile.Name;
                model.ProjectFileName = project.ProjectFile.FileName;
                model.Type = project.Type;
                model.PeronalinfoId = project.PeronalinfoId;

                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Portfolio/AddOrUpdateProject", model);
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var Result = JsonConvert.DeserializeObject<Response<string>>(Data);
                    return Redirect("/Admin/Dashboard");
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
