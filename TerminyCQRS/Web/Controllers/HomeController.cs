using CQRS.Commands;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private ICommandBus commandBus;

        public HomeController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}