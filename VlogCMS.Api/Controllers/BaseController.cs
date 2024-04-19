using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VlogCMS.Api.Controllers
{
    public class BaseController(UserManager<IdentityUser> userManager) : Controller
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        protected string CurrentUserId => _userManager.GetUserId(User) ?? string.Empty;
    }
}
