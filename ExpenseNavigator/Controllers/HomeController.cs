using ExpenseNavigator.Areas.Identity.Data;
using ExpenseNavigator.Helper;
using ExpenseNavigator.Models;
using ExpenseNavigator.Models.Dbo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ExpenseNavigator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //var userId = _userManager.GetUserId(this.User);
            //var pageName = "Dashboard";

            //string url = $"api/Notification/CreateMappiningPageNotificationByUserId/{userId}/{pageName}";

            //var resultApi = await APIHelper.GetData(StaticWebLinks.ExpenceNavigatorAPI, url);
            //var result = JsonConvert.DeserializeObject<bool>(resultApi);
            //ViewBag.Dashboard = result;


           


            var userId = _userManager.GetUserId(this.User);

            if (userId != null)
            {
                var pageName = "Dashboard";
                string url = $"api/Notification/CreateMappiningPageNotificationByUserId/{userId}/{pageName}";

                var resultApi = await APIHelper.GetData(StaticWebLinks.ExpenceNavigatorAPI, url);
                //var resultApi = await APIHelper.PostData(StaticWebLinks.ExpenceNavigatorAPI, url, null);
                var result = JsonConvert.DeserializeObject<dynamic>(resultApi);
                var isSuccess = result.result;

                var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    ViewData["UserID"] = userId;
                    ViewBag.FirstName = user.FirstName;
                }
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
