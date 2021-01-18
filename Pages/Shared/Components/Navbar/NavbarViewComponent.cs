using Microsoft.AspNetCore.Mvc;

namespace AssignmentWebApp.Pages.Shared.Components.Navbar
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("LoggedIn");
            }
            else
            {
                return View("LoggedOut");
            }
        }
    }
}
