using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

using Northwind.Data;

namespace Northwind.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IHostingEnvironment env)
        {
            hostingEnvironment = env;
        }

        public IActionResult Index()
        {
            // Add to the service
            var path = hostingEnvironment.ContentRootPath;
            var folderPath = Path.Combine(path, "Database");
            var filePath = Path.Combine(folderPath, "northwind.xml");

            //var data = new[] { "Foo", "Bar" };
            var data = NorthwindDb.GetRetiredEmployees(filePath);
            return View("index", data);
        }
    }
}
