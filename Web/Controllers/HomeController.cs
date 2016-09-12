using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeViewModel {PageTitle = "My Bus Schedule"};
            return View(model);
        }
    }
}