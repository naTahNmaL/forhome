using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Middlewares.ErrorMessageHandles;

namespace PIMTool.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(controllerName: "Project", actionName: "Index");
        }

        public IActionResult UnexpectedError()
        {
            ViewData["ErrorMessage"] = ErrorMessageHandle.MessageDisplay;
            ErrorMessageHandle.MessageDisplay = string.Empty;
            return View("Error");
        }
    }
}
