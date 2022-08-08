using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Token") != null)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Login)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = Constrant.AppUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Account/Login", Login);
                if (response.IsSuccessStatusCode)
                {
                    var Data = await response.Content.ReadAsStringAsync();
                    var Result = JsonConvert.DeserializeObject<Response<string>>(Data);
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(Result.Data);
                    var token = jsonToken as JwtSecurityToken;
                    var payload = token.Payload;

                    HttpContext.Session.SetString("Token", Result.Data);
                    foreach (var item in payload)
                    {
                        if (item.Key =="Email")
                        {
                            HttpContext.Session.SetString("Email", item.Value.ToString());
                        }
                        if (item.Key == "FirstName")
                        {
                            HttpContext.Session.SetString("FirstName", item.Value.ToString());
                        }
                        if (item.Key == "LastName")
                        {
                            HttpContext.Session.SetString("LastName", item.Value.ToString());
                        }
                        if (item.Key == "UserId")
                        {
                            HttpContext.Session.SetString("UserId", item.Value.ToString());
                        }
                        if (item.Key == "UserRole")
                        {
                            HttpContext.Session.SetString("UserRole", item.Value.ToString());
                        }
                    }
                   return Redirect("/Portfolio/AddPortfolioDetail");

                    //var Token = HttpContext.Session.GetString("Token");
                    //var email = HttpContext.Session.GetString("Email");
                    //var FirstName = HttpContext.Session.GetString("FirstName");
                    //var LastName = HttpContext.Session.GetString("LastName");
                    //var UserId = HttpContext.Session.GetString("UserId");
                    //var UserRole = HttpContext.Session.GetString("UserRole");

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                    return View();
                }
            }
        }

    }
}
