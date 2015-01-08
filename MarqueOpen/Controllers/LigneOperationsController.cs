using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarqueOpen;

namespace MarqueOpen.Controllers
{
    public class LigneOperationsController : Controller
    {
        static decimal idDevis;

        private MarqueOpenEntities db = new MarqueOpenEntities();

        // GET: LigneOperations
        public ActionResult Index()
        {
            var ligneOperation = db.LigneOperation.Include(l => l.Ligne).Include(l => l.Operation);
            return View(ligneOperation.ToList());
        }

        // GET: LigneOperations/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneOperation ligneOperation = db.LigneOperation.Find(id);
            if (ligneOperation == null)
            {
                return HttpNotFound();
            }
            return View(ligneOperation);
        }

        // GET: LigneOperations/Create
        public ActionResult Create(decimal id)
        {
            idDevis = id;
            ViewBag.IdDevis = id;

            //ViewBag.IdLigne = new SelectList(db.Ligne, "IdLigne", "TypeLigne");
            ViewBag.IdOperation = new SelectList(db.Operation, "IdOperation", "Descriptif");
            return View();
        }

        // POST: LigneOperations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Temps,CoutHoraire,IdOperation")] LigneOperation ligneOperation)
        {
            if (ModelState.IsValid)
            {
                Ligne ligne = new Ligne();

                ligne.TypeLigne = "o";
                ligne.IdDevis = idDevis;
                db.Ligne.Add(ligne);
                db.SaveChanges();

                ligne = db.Ligne.OrderByDescending(l => l.IdLigne).First();
                ligneOperation.IdLigne = ligne.IdLigne;
                db.LigneOperation.Add(ligneOperation);
                db.SaveChanges();
                return RedirectToAction("Details", "Devis", new { id = idDevis });
            }

            //ViewBag.IdLigne = new SelectList(db.Ligne, "IdLigne", "TypeLigne", ligneOperation.IdLigne);
            ViewBag.IdOperation = new SelectList(db.Operation, "IdOperation", "Descriptif", ligneOperation.IdOperation);
            return View(ligneOperation);
        }

        // GET: LigneOperations/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneOperation ligneOperation = db.LigneOperation.Find(id);
            if (ligneOperation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLigne = new SelectList(db.Ligne, "IdLigne", "TypeLigne", ligneOperation.IdLigne);
            ViewBag.IdOperation = new SelectList(db.Operation, "IdOperation", "Descriptif", ligneOperation.IdOperation);
            return View(ligneOperation);
        }

        // POST: LigneOperations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLigne,Temps,CoutHoraire,IdOperation")] LigneOperation ligneOperation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ligneOperation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLigne = new SelectList(db.Ligne, "IdLigne", "TypeLigne", ligneOperation.IdLigne);
            ViewBag.IdOperation = new SelectList(db.Operation, "IdOperation", "Descriptif", ligneOperation.IdOperation);
            return View(ligneOperation);
        }

        // GET: LigneOperations/Delete/5
        public ActionResult Delete(decimal id)
        {
            decimal numDevis;
            Ligne ligne = db.Ligne.Find(id);
            numDevis = ligne.IdDevis;
            ViewBag.IdDevis = numDevis;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneOperation ligneOperation = db.LigneOperation.Find(id);
            if (ligneOperation == null)
            {
                return HttpNotFound();
            }
            return View(ligneOperation);
        }

        // POST: LigneOperations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            decimal numDevis;

            LigneOperation ligneOperation = db.LigneOperation.Find(id);
            Ligne ligne = db.Ligne.Find(id);
            numDevis = ligne.IdDevis;
            db.LigneOperation.Remove(ligneOperation);
            db.Ligne.Remove(ligne);
            db.SaveChanges();
            return RedirectToAction("Details", "Devis", new { id = numDevis });
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
