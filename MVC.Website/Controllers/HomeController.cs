using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace MVC.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetOwnerServices _petOwnerServices;

        public HomeController(IPetOwnerServices petOwnerServices)
        {
            _petOwnerServices = petOwnerServices;
        }

        public async Task<ActionResult> Index()
        {
           var owners = await _petOwnerServices.GetOwners();

            return View(owners);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}