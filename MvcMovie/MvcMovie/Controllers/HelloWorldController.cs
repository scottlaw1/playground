using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /HelloWorld/Welcome

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = string.Format("Hello {0}", name);
            ViewBag.NumTimes = numTimes;

            return View();
        }
    }
}
