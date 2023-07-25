using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace PIMTool.Controllers
{
    public class LanguageController : Controller
    {

        public LanguageController()
        {
        }
        public IActionResult SetAppLanguage(string culture, string returnUrl)
        {
            var requestCulture = new RequestCulture(culture);
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(requestCulture)
            );
            return LocalRedirect(returnUrl);
        }

    }
}