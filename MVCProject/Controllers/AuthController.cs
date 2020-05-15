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

namespace MVCProject.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var context = new AppPruebaContext();

            var user = context.Users.FirstOrDefault(o => o.Username == username && o.Password == password);
            
            // user => string json => para guardar => 
            // string json => user => cuando lo quiero leer

            if (user == null)
                return View();

            HttpContext.Session.Set("SessionLoggedUser", user);
           

            //HttpContext.Session.Set("SessionLoggedUserName", user.Username);
            //HttpContext.Session.Set("SessionLoggedUserId", user.Username);
            //HttpContext.Session.Set("SessionLoggedUserCompany", user.Username);
            //HttpContext.Session.Set("SessionLoggedUserRole", user.Username);
            //HttpContext.Session.Set("SessionLoggedUserN", user.Username);


            var claims = new List<Claim>() {                
                new Claim(ClaimTypes.Name, user.Username),
            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(userIdentity);

            HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Tema");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "AUth");
        }

    }
}