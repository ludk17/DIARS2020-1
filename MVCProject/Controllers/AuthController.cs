using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCProject.DB;
using MVCProject.Models;
using MVCProject.Extensions;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace MVCProject.Controllers
{
    public class AuthController : Controller
    {
        private AppPruebaContext context;
        private IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            context = new AppPruebaContext();
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {           

            var user = context.Users
                .FirstOrDefault(o => o.Username == username && o.Password == GetHashedPassword(password));
                
            if (user == null)
                return View();

            HttpContext.Session.Set("SessionLoggedUser", user);


            var claims = new List<Claim>() {                
                new Claim(ClaimTypes.Name, user.Username),
            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(userIdentity);

            HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Tema");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                user.Password = GetHashedPassword(user.Password);
                context.Users.Add(user);
                context.SaveChanges();
            }

            return RedirectToAction("Login");
        }

        private string GetHashedPassword(string input)
        {
            string token = configuration.GetValue<string>("Token");
            input = input + token;
            var sha = SHA256.Create();
            var hashData = sha.ComputeHash(Encoding.Default.GetBytes(input));
            return Convert.ToBase64String(hashData);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "AUth");
        }

    }
}