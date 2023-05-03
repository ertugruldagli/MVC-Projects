using Microsoft.AspNetCore.Mvc;
using JobLinq.Models;
using Microsoft.AspNetCore.Identity;
using JobLinq.ViewModels;

namespace JobLinq.Controllers
{
    public class RegisterController1 : Controller
    {
        public DBJobLinqContext DBJobLinqContext { get; } //dbcontext sınıfını bir değişken olarak tnaımlamak gerekiyor.


        public RegisterController1(DBJobLinqContext dBJobLinqContext)
        {
            DBJobLinqContext=dBJobLinqContext;
        }

        

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM register)
        {
            var data = new User()
            {
                UserEmail = register.UserEmail,
                UserPassword = register.UserPassword,
                UserType = register.UserType

            };


            DBJobLinqContext.Users.Add(data);
            DBJobLinqContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}
