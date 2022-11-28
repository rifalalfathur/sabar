using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DivisionController : Controller
    {

        //GET ALL - GET
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
