using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc;
using Filters.Infrastructure;


public class HomeController : Controller
{
    //[CustomAuth(false)]
    //[Authorize(Users = null, Roles = "admin")]
    public ActionResult Index()
    {
        return View();

    }
   
    [HttpPost]
    public ActionResult Index(string name, string location, string type, int? elevation, double? length, bool open)
    {
        if (elevation.HasValue)
        {
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Type = type;
            ViewBag.Elevation = elevation.Value;
            ViewBag.Length = length.HasValue ? length.Value : 0;
            ViewBag.Open = open;
            return View("Result");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
    public string RangeTest(int id)
    {
        if (id > 100)
        {
            return String.Format("The id value is: {0}", id);
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }


}
