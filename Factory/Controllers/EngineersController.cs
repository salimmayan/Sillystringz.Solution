using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
//     private readonly FactoryContext _db;

//     public CoursesController(FactoryContext db)
//     {
//       _db = db;
//     }

//     public ActionResult Index()
//     {
//       List<Course> model = _db.Courses.ToList();
//       return View(model);
//     }

//     public ActionResult Create()
//     {
//       return View();
//     }

//     [HttpPost]
//     public ActionResult Create(Course course)
//     {
//       _db.Courses.Add(course);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Details(int id)
//     {
//       var thisCourse = _db.Courses
//           .Include(course => course.JoinEntities)
//           .ThenInclude(join => join.Student)
//           .FirstOrDefault(course => course.CourseId == id);
//       return View(thisCourse);
//     }
// //     public ActionResult Edit(int id)
// //     {
// //       var thisCourse = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
// //       return View(thisCourse);
// //     }

// //     [HttpPost]
// //     public ActionResult Edit(Category category)
// //     {
// //       _db.Entry(category).State = EntityState.Modified;
// //       _db.SaveChanges();
// //       return RedirectToAction("Index");
// //     }

// //     public ActionResult Delete(int id)
// //     {
// //       var thisCourse = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
// //       return View(thisCourse);
// //     }

// //     [HttpPost, ActionName("Delete")]
// //     public ActionResult DeleteConfirmed(int id)
// //     {
// //       var thisCourse = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
// //       _db.Categories.Remove(thisCourse);
// //       _db.SaveChanges();
// //       return RedirectToAction("Index");
// //     }
  }
}