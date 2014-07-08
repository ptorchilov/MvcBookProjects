namespace PartyInvites.Controllers
{
    using System;
    using System.Web.Mvc;
    using PartyInvites.Models;

    public class HomeController : Controller
    {
        // GET: /Home/
        
        public ViewResult Index()
        {
            var hour = DateTime.Now.Hour;

            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";

            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            //TODO: send email
            return View("Thanks", guestResponse);
        }
    }
}
