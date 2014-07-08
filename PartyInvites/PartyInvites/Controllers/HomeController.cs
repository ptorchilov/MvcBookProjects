namespace PartyInvites.Controllers
{
    using System;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        // GET: /Home/
        
        public ViewResult Index()
        {
            var hour = DateTime.Now.Hour;

            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";

            return View();
        }

        public ViewResult RsvpForm()
        {
            return View();
        }
    }
}
