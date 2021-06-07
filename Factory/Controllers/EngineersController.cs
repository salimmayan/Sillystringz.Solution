using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {
        private readonly FactoryContext _db;

        public EngineersController(FactoryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            IEnumerable<Engineer> sortedEngineers = _db.Engineers.OrderBy(engineer => engineer.EngineerName);
            return View(sortedEngineers.ToList());
        }

        //View needs data from Joint table (all rows in Joint table that have EnigneerID - so can tell how many Machines Engineer can operate)
        public ActionResult Details(int id)  
        {
            var thisEngineer = _db.Engineers.Include(engineer => engineer.JoinEntities).ThenInclude(join => join.Machine).FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(thisEngineer);
        }

        //View needs data from Machine table (to populate drop down) 
        public ActionResult Create()  
        {
            ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
            return View();
        }

        //Name and title submitted via form is incuded in parameter "Engineer engineer" while drop down selection is in "int MachineId"
        //Write to 2 tables: a Row is added to Engineer table and 2 foreign keys are added to Joint table.
        [HttpPost]
        public ActionResult Create(Engineer engineer, int MachineId)
        {
            _db.Engineers.Add(engineer);
            _db.SaveChanges();
            if (MachineId != 0)
            {
                _db.EngineerMachine.Add(new EngineerMachine() { MachineId = MachineId, EngineerId = engineer.EngineerId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Routes takes care of removing association b/w Engg and M/C (by clicking button inside Details page - removes row from 3rd table
        [HttpPost]
        public ActionResult DeleteMachine(int joinId)
        {
            var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
            _db.EngineerMachine.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = joinEntry.EngineerId });
        }
        
        public ActionResult Edit(int id)
        {
            var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(thisEngineer);
        }

        [HttpPost]
        public ActionResult Edit(Engineer engineer)
        {
            _db.Entry(engineer).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = engineer.EngineerId });
        }

         public ActionResult Delete(int id)
        {
            var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(thisEngineer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
            _db.Engineers.Remove(thisEngineer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // public ActionResult AddMachine(int id)
        // {
        //     var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
        //     ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
        //     return View(thisEngineer);
        // }

        // [HttpPost]
        // public ActionResult AddMachine(Engineer engineer, int MachineId)
        // {
        //     if (MachineId != 0)
        //     {
        //         if (_db.EngineerMachine.Any(join => join.MachineId == MachineId && join.EngineerId == engineer.EngineerId) == false)
        //             _db.EngineerMachine.Add(new EngineerMachine() { MachineId = MachineId, EngineerId = engineer.EngineerId });
        //     }
        //     _db.SaveChanges();
        //     return RedirectToAction("Details", new { id = engineer.EngineerId });
        // }

       



    }
}