using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
    public class MachinesController : Controller
    {
        private readonly FactoryContext _db;

        public MachinesController(FactoryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            IEnumerable<Machine> sortedMachines = _db.Machines.ToList().OrderBy(machine => machine.MachineName);
            return View(sortedMachines.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Machine machine, int EngineerId)  //why int for string from drop
        {
            _db.Machines.Add(machine); //add new student btut no need to update course table - course already exists
            _db.SaveChanges();
            if (EngineerId != 0) //why?
            {
                _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = EngineerId, MachineId = machine.MachineId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Machine thisMachine = _db.Machines
              .Include(machine => machine.JoinEntities)
              .ThenInclude(join => join.Machine)
              .FirstOrDefault(machine => machine.MachineId == id);
            return View(thisMachine);
        }

        [HttpPost]
        public ActionResult DeleteEngineer(int joinId)
        {
            var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
            _db.EngineerMachine.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = joinEntry.MachineId });
        }

        public ActionResult Edit(int id)
        {
            var thisItem = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
            // ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
            ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
            return View(thisItem);
        }

        [HttpPost]
        public ActionResult Edit(Machine machine, int MachineId)
        {
            if (MachineId != 0)
            {
                _db.EngineerMachine.Add(new EngineerMachine() { MachineId = MachineId, EngineerId = machine.MachineId });
            }
            _db.Entry(machine).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
            return View(thisMachine);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
            _db.Machines.Remove(thisMachine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // public ActionResult AddEngineer(int id)
        // {
        //     var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
        //     ViewBag.EngineerInfo = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
        //     return View(thisMachine);
        // }

        // [HttpPost]
        // public ActionResult AddEngineer(Machine machine, int EngineerId)
        // {
        //     if (EngineerId != 0)
        //     {
        //         _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = EngineerId, MachineId = machine.MachineId });
        //     }
        //     _db.SaveChanges();
        //     // return RedirectToAction("Index");
        //     return RedirectToAction("Details", new { id = machine.MachineId });
        // }
    }
}