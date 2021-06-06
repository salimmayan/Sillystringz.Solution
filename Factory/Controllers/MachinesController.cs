using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;

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

  //   public ActionResult Details(int id)
  //   {
  //     var thisStudent = _db.Students
  //         .Include(student => student.JoinEntities)
  //         .ThenInclude(join => join.Course)
  //         .FirstOrDefault(student => student.StudentId == id);    //entire student table; "include" - is like "foreach" - runs thru each student and grabs jointentity of that student
  //         //ThenInclude goes and grabs the course.  ("ThenInclude" is an extention for ... these are all LINQ - look up)
  //         // now we have course attached to student - #51 is about filtering    
  //         Console.WriteLine(" this is the student " + thisStudent);
  //         // Debug.WriteLine(" this is the salim" + "Salim");
  //         // Debug.WriteLine(" this is the student" + thisStudent);
  //     return View(thisStudent); //read this (JE has 3rd table)
  //   }

//     public ActionResult Edit(int id)
//     {
//       var thisItem = _db.Items.FirstOrDefault(item => item.StudentId == id);
//       ViewBag.CourseId = new SelectList(_db.Categories, "CourseId", "Name");
//       return View(thisItem);
//     }

//     [HttpPost]
//     public ActionResult Edit(Item item, int CourseId)
//     {
//       if (CourseId != 0)
//       {
//         _db.CategoryItem.Add(new CategoryItem() { CourseId = CourseId, StudentId = item.StudentId });
//       }
//       _db.Entry(item).State = EntityState.Modified;
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult AddCategory(int id)
//     {
//       var thisItem = _db.Items.FirstOrDefault(item => item.StudentId == id);
//       ViewBag.CourseId = new SelectList(_db.Categories, "CourseId", "Name");
//       return View(thisItem);
//     }

//     [HttpPost]
//     public ActionResult AddCategory(Item item, int CourseId)
//     {
//       if (CourseId != 0)
//       {
//       _db.CategoryItem.Add(new CategoryItem() { CourseId = CourseId, StudentId = item.StudentId});
//       }
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Delete(int id)
//     {
//       var thisItem = _db.Items.FirstOrDefault(item => item.StudentId == id);
//       return View(thisItem);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//       var thisItem = _db.Items.FirstOrDefault(item => item.StudentId == id);
//       _db.Items.Remove(thisItem);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     [HttpPost]
//     public ActionResult DeleteCategory(int joinId)
//     {
//       var joinEntry = _db.CategoryItem.FirstOrDefault(entry => entry.CourseStudentId == joinId);
//       _db.CategoryItem.Remove(joinEntry);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
  }
}