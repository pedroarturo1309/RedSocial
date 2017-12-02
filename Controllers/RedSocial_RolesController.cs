using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RedSocial.Models;
using RedSocial.Models.Roles;

namespace RedSocial.Controllers
{
    public class RedSocial_RolesController : Controller
    {
        private RedSocialDB db = new RedSocialDB();

        // GET: RedSocial_Roles
        public ActionResult Index()
        {
            return View(db.RedSocial_Roles.ToList());
        }

        // GET: RedSocial_Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedSocial_Roles redSocial_Roles = db.RedSocial_Roles.Find(id);
            if (redSocial_Roles == null)
            {
                return HttpNotFound();
            }
            return View(redSocial_Roles);
        }

        // GET: RedSocial_Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RedSocial_Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Descripcion,Titulo,Estado")] RedSocial_Roles redSocial_Roles)
        {
            if (ModelState.IsValid)
            {
                db.RedSocial_Roles.Add(redSocial_Roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(redSocial_Roles);
        }

        // GET: RedSocial_Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedSocial_Roles redSocial_Roles = db.RedSocial_Roles.Find(id);
            if (redSocial_Roles == null)
            {
                return HttpNotFound();
            }
            return View(redSocial_Roles);
        }

        // POST: RedSocial_Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Descripcion,Titulo,Estado")] RedSocial_Roles redSocial_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(redSocial_Roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(redSocial_Roles);
        }

        // GET: RedSocial_Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedSocial_Roles redSocial_Roles = db.RedSocial_Roles.Find(id);
            if (redSocial_Roles == null)
            {
                return HttpNotFound();
            }
            return View(redSocial_Roles);
        }

        // POST: RedSocial_Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RedSocial_Roles redSocial_Roles = db.RedSocial_Roles.Find(id);
            db.RedSocial_Roles.Remove(redSocial_Roles);
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
    }
}
