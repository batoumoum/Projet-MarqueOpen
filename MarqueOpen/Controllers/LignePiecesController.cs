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
    public class LignePiecesController : Controller
    {
        static decimal idDevis;

        private MarqueOpenEntities db = new MarqueOpenEntities();

        // GET: LignePieces
        public ActionResult Index()
        {
            var lignePiece = db.LignePiece.Include(l => l.Ligne).Include(l => l.PieceConsommable);
            return View(lignePiece.ToList());
        }

        // GET: LignePieces/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LignePiece lignePiece = db.LignePiece.Find(id);
            if (lignePiece == null)
            {
                return HttpNotFound();
            }
            return View(lignePiece);
        }

        // GET: LignePieces/Create
        public ActionResult Create(decimal id)
        {
            idDevis = id;
            ViewBag.IdDevis = id;
            //GetNextIdLigne();

            //ViewBag.IdLigne = new SelectList(db.Ligne, "IdLigne", "TypeLigne");
            ViewBag.Code = new SelectList(db.PieceConsommable, "Code", "Denomination");
            return View();
        }

        private void GetNextIdLigne()
        {
            Ligne ligne;
            decimal newNumDevis;

            ligne = db.Ligne.OrderByDescending(l => l.IdLigne).First();
            newNumDevis = ligne.IdLigne + 1;
            ViewBag.NumeroLigne = newNumDevis;
        }

        // POST: LignePieces/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Prix,Quantite,Code")] LignePiece lignePiece)
        {
            if (ModelState.IsValid)
            {
                Ligne ligne = new Ligne();

                ligne.TypeLigne = "p";
                ligne.IdDevis = idDevis;
                db.Ligne.Add(ligne);
                db.SaveChanges();

                ligne = db.Ligne.OrderByDescending(l => l.IdLigne).First();
                lignePiece.IdLigne = ligne.IdLigne;
                db.LignePiece.Add(lignePiece);
                db.SaveChanges();
                return RedirectToAction("Details", "Devis", new { id = idDevis });
            }

            //ViewBag.IdLigne = new SelectList(db.Ligne, "IdLigne", "TypeLigne", lignePiece.IdLigne);
            ViewBag.Code = new SelectList(db.PieceConsommable, "Code", "Denomination", lignePiece.Code);
            return View(lignePiece);
        }

        // GET: LignePieces/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LignePiece lignePiece = db.LignePiece.Find(id);
            if (lignePiece == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLigne = new SelectList(db.Ligne, "IdLigne", "TypeLigne", lignePiece.IdLigne);
            ViewBag.Code = new SelectList(db.PieceConsommable, "Code", "Denomination", lignePiece.Code);
            return View(lignePiece);
        }

        // POST: LignePieces/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLigne,Prix,Quantite,Code")] LignePiece lignePiece)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lignePiece).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLigne = new SelectList(db.Ligne, "IdLigne", "TypeLigne", lignePiece.IdLigne);
            ViewBag.Code = new SelectList(db.PieceConsommable, "Code", "Denomination", lignePiece.Code);
            return View(lignePiece);
        }

        // GET: LignePieces/Delete/5
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
            LignePiece lignePiece = db.LignePiece.Find(id);
            if (lignePiece == null)
            {
                return HttpNotFound();
            }
            return View(lignePiece);
        }

        // POST: LignePieces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            decimal numDevis;

            LignePiece lignePiece = db.LignePiece.Find(id);
            Ligne ligne = db.Ligne.Find(id);
            numDevis = ligne.IdDevis;
            db.LignePiece.Remove(lignePiece);
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
