using Microsoft.AspNetCore.Mvc;
using MyVirtualStore.Models;
using System.Diagnostics;

namespace MyVirtualStore.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

    }
}