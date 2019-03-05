using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConsumeAPI.Models;
using ConsumeAPI.Utils;
using System.Net.Http;

namespace ConsumeAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
           

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Users()
        {
            try
            {
                ApisHelper api = new ApisHelper("http://localhost:2213");
                List<UsuariosModel> ObjValResponse = new List<UsuariosModel>();

                var res = Task.Run(async () => await api.ConsumirApiGet("api/user", "9")).Result;
                if (res.IsSuccessStatusCode)
                {
                    ObjValResponse = res.Content.ReadAsAsync<List<UsuariosModel>>().Result;

                }
                else
                {
                    var status = (int)res.StatusCode;
                }
                return View(ObjValResponse);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
