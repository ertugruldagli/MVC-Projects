using JobLinq.Models;
using JobLinq.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace JobLinq.Controllers
{
    public class LoginController : Controller
    {
        public DBJobLinqContext DBJobLinqContext { get; } //dbcontext sınıfını bir değişken olarak tnaımlamak gerekiyor.


        public LoginController(DBJobLinqContext dBJobLinqContext)
        {
            DBJobLinqContext = dBJobLinqContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginWM login)
        {
            var user = DBJobLinqContext.Users.Where(u=>u.UserEmail==login.UserEmail);

            if (user.Any())
            {
                if (user.Where(u=>u.UserPassword==login.UserPassword).Any())
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }


            DBJobLinqContext.Users.Add(user);
            DBJobLinqContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
