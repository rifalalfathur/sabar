using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Handlers;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        MyContext myContext;
        public LoginController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //Login
        //Get
        public IActionResult Login()
        {

            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .Include(x=> x.Role )
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            var has=Hasing.validatePassword(password, data.Password);
            if (data != null && has)
            {
                HttpContext.Session.SetInt32("Id", data.Id);
                HttpContext.Session.SetString("FullName", data.Employee.FullName);
                HttpContext.Session.SetString("Email", data.Employee.Email);
                HttpContext.Session.SetString("Role", data.Role.Name);
                return RedirectToAction("Index","Division");

            }
            return View();
        }


        // register
        //Get
        public IActionResult Register()
        {
            return View();
        }

        //Post
        [HttpPost]
        
        public IActionResult Register(string fullName, string email, string password, DateTime birthDate)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            if (data != null)
            {
                return View();
            }
            else 
            {
                Employee employee = new Employee()
                {
                    FullName = fullName,
                    Email = email,
                    BirthDate = birthDate,

                };
                myContext.Employees.Add(employee);
                var result = myContext.SaveChanges();
                if (result > 0 && data == null)
                {
                    var id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(email)).Id;
                    User user = new User()
                    {
                        Id = id,
                        Password = Hasing.HashPassword(password),
                        RoleId = 1
                    };
                    myContext.Users.Add(user);
                    var resultUser = myContext.SaveChanges();
                    if (resultUser > 0)
                        return RedirectToAction("Login", "Login");
                }
            }
            return View();
        }

        //Change pasword
        //Get
        public IActionResult ChangePassword()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult ChangePassword(string email, string password, string baru)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            var has = Hasing.validatePassword(password, data.Password);

            if (data != null && has)
            {
                data.Password = Hasing.HashPassword(baru);
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Login", "Login");
            }
            return View();
        }

        //Forgot Password
        //Get
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult ForgotPassword(string email, string password, string baru)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            
            if (data != null)
            {
                if (password == baru )
                {
                    data.Password = Hasing.HashPassword(password);
                    myContext.Entry(data).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if (result > 0)
                        return RedirectToAction("Login", "Login");
                }
                
            }
            return View();
        }


    }
}
