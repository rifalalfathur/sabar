using API.Context;
using API.Handlers;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Repository.Data
{
    public class AccountRepositories : IAccountRepositories
    {
        
        private MyContext myContext;
        public IConfiguration _configuration;
        public AccountRepositories(MyContext mycontext, IConfiguration config)
        {
            myContext = mycontext;
            _configuration = config;
            
        }

        public int ChangePassword(string email, string password, string baru)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            var has = Hashing.validatePassword(password, data.Password);
            if (data !=null)
            {
                data.Password = Hashing.HashPassword(baru);
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result;
            }
            return 0;
        }

        public int ForgotPassword(string email, string password, string baru)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));

            if (data != null && password == baru)
            {
                    data.Password = Hashing.HashPassword(password);
                    myContext.Entry(data).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    return result;
            }
            return 0;
        }

        public User  Login(string email, string password)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            
            if (data != null && Hashing.validatePassword(password, data.Password))
            {
                return data;                
            }
            return null;
        }

        public int Register(string fullName, string email, string password, DateTime birthDate)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            if (data == null)
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
                    var id = myContext.Employees.FirstOrDefault (x => x.Email.Equals(email)).Id;
                    User user = new User()
                    {
                        //Id = id,
                        Password = Hashing.HashPassword(password),
                        RoleId = 2
                    };
                    myContext.Users.Add(user);
                    var resultUser = myContext.SaveChanges();
                    return resultUser;
                }
                return result;
            }
            return 0;
        }


    }
}
