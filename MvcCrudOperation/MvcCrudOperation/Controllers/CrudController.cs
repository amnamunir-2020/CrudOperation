using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrudOperation.Models;

namespace MvcCrudOperation.Controllers
{
    public class CrudController : Controller
    {
        CrudDBEntities db = new CrudDBEntities();
        // GET: Crud
        public ActionResult Index()
        {
            //another descending ascending
            var getAll = db.Employees.ToList().OrderByDescending(x=>x.emp_id);
            return View(getAll);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid){
                    db.Employees.Add(emp);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Error!--";
                }
            }
            catch
            {
                return View(emp);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var getID = db.Employees.SingleOrDefault(x => x.emp_id == id);
            return View(getID);
        }

        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            try
            {
                var getID = db.Employees.Find(id);
                db.Employees.Remove(getID);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
               
            }

            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var getID = db.Employees.SingleOrDefault(x => x.emp_id == id);
            return View(getID);
        }

        [HttpPost]
        public ActionResult Edit(int id,Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(emp);
                }
            }
            catch
            {
                return View(emp);
            }
            return View();
        }

    }
}