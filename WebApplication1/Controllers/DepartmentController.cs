using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET BY ID - GET
        public IActionResult Details(int id)
        {
            return View();
        }

        // Insert - GET POST
        public IActionResult Create()
        {
            // get data disini
            //dropdown  data di dapat dari database
            return View();
        }



        // Update - GET POST
        public IActionResult Edit()
        {

            return View();
        }



        // DELETE - GET POST
        public IActionResult Delete()
        {

            return View();
        }

    }
}
