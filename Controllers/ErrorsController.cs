using Microsoft.AspNetCore.Mvc;
using Portofolio.ViewModels;
using Microsoft.AspNetCore.Identity;
using Portofolio.Models;
namespace Portofolio.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        public ErrorsController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Error404()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                return View(new CustomErrorViewModel
                {
                    ReturnAction = nameof(DashboardController.Index),
                    ReturnController = "Dashboard"
                });
            }
            return View(new CustomErrorViewModel
            {
                ReturnAction = nameof(HomeController.Index),
                ReturnController = "Home"
            });
        }

        public IActionResult Error401()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                return View(new CustomErrorViewModel
                {
                    ReturnAction = nameof(DashboardController.Index),
                    ReturnController = "Dashboard"
                });
            }
            return View(new CustomErrorViewModel
            {
                ReturnAction = nameof(HomeController.Index),
                ReturnController = "Home"
            });
        }
    }
}