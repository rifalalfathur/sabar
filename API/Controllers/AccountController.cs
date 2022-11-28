using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using API.Context;
using Microsoft.EntityFrameworkCore;
using API.ViewModels;
using API.Handlers;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "staff, admin")]
    public class AccountController : ControllerBase
    {
        public User data1 = null; 
        private AccountRepositories _accountRepositories;
        private MyContext context;
        private IConfiguration _configuration;
        public AccountController(AccountRepositories accountRepositories, IConfiguration configuration, MyContext myContext)
        {
            _accountRepositories = accountRepositories;
            _configuration = configuration;
            context = myContext;
        }
        // Login
        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(LoginViewModels Login)
        {
            try
            {
                var data = _accountRepositories.Login(Login.Email, Login.Password);
                data1 = data;
                if (data==null)
                {
                    return Ok(new
                    {
                        Message = "Email/Password salah",
                        StatusCode = 200
                    });
                }
                else
                {
                    string token = Token(Login.Email, Login.Password);
                    return Ok(new
                    {
                        Message = "Berhasil Login",
                        StatusCode = 200,
                        Data = data ,token

                        
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    Message = e.Message,
                    StatusCode = 400
                });
            }
        }
        //Register 
        [AllowAnonymous]
        [HttpPost("Registrasi")]

        public ActionResult Register(string fullName, string email, string password, DateTime birthDate)
        {
            try
            {
                var data = _accountRepositories.Register(fullName, email, password, birthDate);
                if (data == null)
                {
                    return Ok(new
                    {
                        Message = "Email Sudah pernah digunakan",
                        StatusCode = 200
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Message = "Registrasi Berhasil",
                        StatusCode = 200,
                        Data = data
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    Message = e.Message,
                    StatusCode = 400
                });
            }
        }
        //Change Password
        
        [HttpPut("Change_Password")]
        public ActionResult ChangePassword(string email, string password, string baru)
        {
            try
            {
                var data = _accountRepositories.ChangePassword(email, password, baru);
                if (data == null)
                {
                    return Ok(new
                    {
                        Message = "Password Lama Anda Salah",
                        StatusCode = 200
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Message = "berhasil Mengganti Password",
                        StatusCode = 200,
                        Data = data
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    Message = e.Message,
                    StatusCode = 400
                });
            }
        }
        //Forgot Password
        
        [HttpPut("Forgot_Password")]
        public ActionResult ForgotPassword(string email, string password, string baru)
        {
            try
            {
                var data = _accountRepositories.ForgotPassword(email, password, baru);
                if (data == null)
                {
                    return Ok(new
                    {
                        Message = "Password tidak sama",
                        StatusCode = 200
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Message = "Berhasil Mengganti Password",
                        StatusCode = 200,
                        Data = data
                    });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new
                {
                    Message = e.Message,
                    StatusCode = 400
                });
            }
        }
        private string Token(string email, string password)
        {
            var data = context.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email) );

            //Hashing.validatePassword(password, data.Password)
            bool validate = Hashing.validatePassword(password, data.Password);
            if (validate) { 
                var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("fullName", data.Employee.FullName),
                            new Claim("email", data.Employee.Email),
                           //new Claim("id",data.),
                            //new Claim("role", data.Role.Name)
                        };
                 var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);
            var tokenCode = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenCode;
                 }
            return null;
        }

    }
}
