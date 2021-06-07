using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
    public class HomeController : Controller
    {
        private readonly FactoryContext _db;  //FactoryContext is a Model file representing DB

        public HomeController(FactoryContext db)
        {
            _db = db;
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            ViewBag.EngineerInfo = new List<Engineer>(_db.Engineers.OrderBy(engineer => engineer.EngineerName));
            ViewBag.MachineInfo = new List<Machine>(_db.Machines.OrderBy(machine => machine.MachineName));
            return View();
        }
    }
}