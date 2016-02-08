using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using CombiTech.Solution.DataAccess;
using CombiTech.Solution.Models;

namespace CombiTech.Solution.Controllers
{

    public class ToDoController : Controller
    {
        private readonly DefaultDataContext dataAccess = new DefaultDataContext();
        // GET: ToDo
        public ActionResult Index()
        {
            var listOfToDoItems = dataAccess.ToDos.ToList();

            return View(listOfToDoItems);
        }
        [HttpGet]
        public ActionResult New()
        {
            return View("New");
        }

        [HttpPost]
        public ActionResult New(ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                toDo.Created = DateTime.Now;
                toDo.Active = true;

                dataAccess.ToDos.Add(toDo);
                dataAccess.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("New", toDo);
        }

        public ActionResult Details(int? id)
        {
            var toDo = dataAccess.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }
        public ActionResult Edit(int? id)
        {
            var toDo = dataAccess.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }

        [HttpPost]
        public ActionResult Edit(ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                dataAccess.Entry(toDo).State = EntityState.Modified;
                dataAccess.Entry(toDo).Property(a => a.Created).IsModified = false;

                dataAccess.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(toDo);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = dataAccess.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ToDo toDo = dataAccess.ToDos.Find(id);
            if (toDo == null)
            {
                return this.HttpNotFound();
            }

            dataAccess.ToDos.Remove(toDo);
            dataAccess.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ToggleState(int? id)
        {
            var toDo = dataAccess.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }

            toDo.Active = !toDo.Active;
            dataAccess.SaveChanges();

            return Redirect("Index");
        }

    }
}
