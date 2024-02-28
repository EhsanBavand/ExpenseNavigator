using ExpenseNavigator.Areas.Identity.Data;
using ExpenseNavigator.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExpenseNavigator.Controllers
{
    public class FamilyConfiguration : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public FamilyConfiguration(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Household()
        {
            var userId = _userManager.GetUserId(this.User);
            if (userId != null)
            {
                var pageName = "Household";
                string url = $"api/Notification/CreateMappiningPageNotificationByUserId/{userId}/{pageName}";

                var resultApi = await APIHelper.GetData(StaticWebLinks.ExpenceNavigatorAPI, url);
                var result = JsonConvert.DeserializeObject<dynamic>(resultApi);
                ViewBag.Household = result.result;

                var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    ViewData["UserID"] = userId;
                    ViewBag.FirstName = user.FirstName;
                }
            }
            return View();        
        }
        public async Task<IActionResult> Income()
        {
            return View();
        }
        public async Task<IActionResult> FixAmount()
        {
            return View();
        }
        public async Task<IActionResult> CarInfo()
        {
            return View();
        }
    }
}
