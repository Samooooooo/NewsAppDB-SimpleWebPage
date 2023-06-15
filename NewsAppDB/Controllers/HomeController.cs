using Microsoft.AspNetCore.Mvc;
using NewsAppDB.Models;
using System.Linq;

namespace NewsAppDB.Controllers
{
  public class HomeController : Controller
  {
    private NewsAppDBContext dBContext;

    public HomeController(NewsAppDBContext dBContext)
    {
      this.dBContext = dBContext;
    }
    public IActionResult Index()
    {
      return View(dBContext.Articles.ToList());
    }
  }
}
