using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tasking.Models;

namespace Tasking.Controllers
{
    public class taskingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: taskings
        public ActionResult Index()
        {
            var taskings = db.taskings.Include(t => t.CoreUsers);
            return View(taskings.ToList());
        }

        // GET: taskings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tasking tasking = db.taskings.Find(id);
            if (tasking == null)
            {
                return HttpNotFound();
            }
            return View(tasking);
        }

        // GET: taskings/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.CoreUsers, "Id", "UserName");
            return View();
        }

        // POST: taskings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idd,UserId,TaskName,TaskNumber,TaskDesc,TaskComments,Id,completed")] tasking tasking)
        {
            if (ModelState.IsValid)
            {
                tasking.UserId = User.Identity.Name;

                string temp = "UD&A";
                var guid = Convert.ToString((new Random()).Next(100000));
                //string temp2 = s.IdNumber.Substring(6, 13);
                //string temp1 = "ajd";
                tasking.TaskNumber = temp + guid;
                tasking.TaskComments = "";
                tasking.completed = false;
                db.taskings.Add(tasking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.CoreUsers, "Id", "UserName", tasking.Id);
            return View(tasking);
        }

        // GET: taskings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tasking tasking = db.taskings.Find(id);
            if (tasking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.CoreUsers, "Id", "UserName", tasking.Id);
            return View(tasking);
        }

        // POST: taskings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idd,UserId,TaskName,TaskNumber,TaskDesc,TaskComments,Id,completed")] tasking tasking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.CoreUsers, "Id", "UserName", tasking.Id);
            return View(tasking);
        }

        // GET: taskings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tasking tasking = db.taskings.Find(id);
            if (tasking == null)
            {
                return HttpNotFound();
            }
            return View(tasking);
        }

        // POST: taskings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tasking tasking = db.taskings.Find(id);
            db.taskings.Remove(tasking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult MyTask()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string use = User.Identity.Name;
            List<tasking> tasks = db.taskings.Where(x => x.CoreUsers.UserName.Equals(use)).ToList();


            //ViewBag.Case = cases;

            return View(tasks);
        }


        public ActionResult Stask(string tasknumber)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var results = from t in db.taskings

                          where t.TaskNumber.Equals(tasknumber)
                          select t;

            return View(results.ToList());
        }
    }
}
