using Microsoft.AspNetCore.Mvc;

namespace VlogCMS.Api.Controllers
{
    public class BaseController : Controller
    {
        protected string CurrentUser => User?.Identity?.Name;
    }
}
