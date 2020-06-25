using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hirmudemja.Models;

namespace hirmudemja.Controllers
{
    public class hirmudemajasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Sisenes()
        {
            var model = db.hirmudemajas
             .Where(r => r.Sisenes == -1)
             .OrderBy(u => u.Eesnimi)
             .Select(u => new SisenenudLahkunud
             {
                 id = u.id,
                 Eesnimi = u.Eesnimi,
                 Sisenes = u.Sisenes == -1 ? "Ei" : "Jah",
             }).ToList();

            return View(model);
        }

        public ActionResult Lahkus()
        {
            var model = db.hirmudemajas
             .Where(r => r.Sisenes == 1 && r.Lahkus == -1)
             .OrderBy(u => u.Eesnimi)
             .Select(u => new SisenenudLahkunud
             {
                 id = u.id,
                 Eesnimi = u.Eesnimi,
                 Sisenes = u.Sisenes == -1 ? "Ei" :  "Jah",
                 Lahkus = u.Lahkus == -1 ? "Ei" :  "Jah",
             }).ToList();

            return View(model);

        }

        [Authorize]
        public ActionResult PiletiTuhistamine(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hirmudemaja hirmudemaja = db.hirmudemajas.Find(id);
            if (hirmudemaja == null)
            {
                return HttpNotFound();
            }
            return View(hirmudemaja);
        }

        // POST: hirmudemajas/Delete/5
        [HttpPost, ActionName("PiletiTuhistamine")]
        [ValidateAntiForgeryToken]
        public ActionResult PiletiTuhistamineConfirmed(int id)
        {
            hirmudemaja hirmudemaja = db.hirmudemajas.Find(id);
            db.hirmudemajas.Remove(hirmudemaja);
            db.SaveChanges();
            return RedirectToAction("Sisenes");
        }
        // GET: hirmudemajas/Create
        public ActionResult OstaPilet()
        {
            return View();
        }
        [Authorize]
        public ActionResult MargiSisenenuks(int? id)
        {
            var model = db.hirmudemajas
                .Where(r => r.Sisenes == -1)
                .ToList();

            hirmudemaja hirmudemaja = db.hirmudemajas.Find(id);

                hirmudemaja.Sisenes = 1;
                db.Entry(hirmudemaja).State = EntityState.Modified;
                db.SaveChanges();

            return RedirectToAction("Lahkus");
        }
        [Authorize]
        public ActionResult MargiValjunuks(int? id)
        {
            var model = db.hirmudemajas
                .Where(r => r.Lahkus == -1)
                .ToList();

            hirmudemaja hirmudemaja = db.hirmudemajas.Find(id);

            hirmudemaja.Lahkus = 1;
            db.Entry(hirmudemaja).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Lahkus");
        }


        // POST: hirmudemajas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OstaPilet([Bind(Include = "id,eesnimi,sisenes,lahkus")] hirmudemaja hirmudemaja)
        {
            if (ModelState.IsValid)
            {
                db.hirmudemajas.Add(hirmudemaja);
                db.SaveChanges();
                return RedirectToAction("Sisenes");
            }

            return View(hirmudemaja);
        }

        // GET: hirmudemajas
        public ActionResult Index()
        {
            return View(db.hirmudemajas.ToList());
        }

        // GET: hirmudemajas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hirmudemaja hirmudemaja = db.hirmudemajas.Find(id);
            if (hirmudemaja == null)
            {
                return HttpNotFound();
            }
            return View(hirmudemaja);
        }

        // GET: hirmudemajas/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: hirmudemajas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,eesnimi,sisenes,lahkus")] hirmudemaja hirmudemaja)
        {
            if (ModelState.IsValid)
            {
                db.hirmudemajas.Add(hirmudemaja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hirmudemaja);
        }

        // GET: hirmudemajas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hirmudemaja hirmudemaja = db.hirmudemajas.Find(id);
            if (hirmudemaja == null)
            {
                return HttpNotFound();
            }
            return View(hirmudemaja);
        }

        // POST: hirmudemajas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,eesnimi,sisenes,lahkus")] hirmudemaja hirmudemaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hirmudemaja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hirmudemaja);
        }

        // GET: hirmudemajas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hirmudemaja hirmudemaja = db.hirmudemajas.Find(id);
            if (hirmudemaja == null)
            {
                return HttpNotFound();
            }
            return View(hirmudemaja);
        }

        // POST: hirmudemajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hirmudemaja hirmudemaja = db.hirmudemajas.Find(id);
            db.hirmudemajas.Remove(hirmudemaja);
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
