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
    public class DevisController : Controller
    {
        private MarqueOpenEntities db = new MarqueOpenEntities();

        // GET: Devis
        public ActionResult Index()
        {
            var devis = db.Devis.Include(d => d.Possession);
            return View(devis.ToList());
        }

        // GET: Devis/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devis devis = db.Devis.Find(id);
            if (devis == null)
            {
                return HttpNotFound();
            }
            return View(devis);
        }

        // GET: Devis/Create
        public ActionResult Create()
        {
            GetNextNumDevis();

            //ViewBag.DefaultDate = DateTime.Now.Date;
            //ViewBag.IdPossession = new SelectList(db.Possession, "IdPossession", "NumMineralogique");
            return View();
        }

        private void GetNextNumDevis()
        {
            Devis devis;
            int lastNumNumDevis;
            string newNumDevis;
            
            devis = db.Devis.OrderByDescending(l => l.NumDevis).First();
            lastNumNumDevis = Convert.ToInt32(devis.NumDevis.Substring(5));
            newNumDevis = DateTime.Now.Year + "-" + (lastNumNumDevis + 1).ToString();
            ViewBag.NumeroDevis = newNumDevis;
        }

        // POST: Devis/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDevis,NumDevis,Date,Descriptif,IdPossession")] Devis devis)
        {
            if (ModelState.IsValid)
            {
                db.Devis.Add(devis);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = devis.IdDevis });
            }

            //ViewBag.IdPossession = new SelectList(db.Possession, "IdPossession", "NumMineralogique", devis.IdPossession);
            return View(devis);
        }

        // GET: Devis/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devis devis = db.Devis.Find(id);
            if (devis == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPossession = new SelectList(db.Possession, "IdPossession", "NumMineralogique", devis.IdPossession);
            return View(devis);
        }

        // POST: Devis/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDevis,NumDevis,Date,Descriptif,IdPossession")] Devis devis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPossession = new SelectList(db.Possession, "IdPossession", "NumMineralogique", devis.IdPossession);
            return View(devis);
        }

        // GET: Devis/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devis devis = db.Devis.Find(id);
            if (devis == null)
            {
                return HttpNotFound();
            }
            return View(devis);
        }

        // POST: Devis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Devis devis = db.Devis.Find(id);
            foreach (Ligne ligne in db.Ligne.Where(p => p.IdDevis == id))
            {
                if (ligne.TypeLigne == "o")
                {
                    LigneOperation ligneOp = db.LigneOperation.Find(ligne.IdLigne);
                    db.LigneOperation.Remove(ligneOp);
                }
                else
                {
                    LignePiece ligneP = db.LignePiece.Find(ligne.IdLigne);
                    db.LignePiece.Remove(ligneP);
                }
                db.Ligne.Remove(ligne);
            }
            db.Devis.Remove(devis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult Autocomplete(string term)
        {
            Proprietaire[] matching = string.IsNullOrWhiteSpace(term) ?
            db.Proprietaire.ToArray() :
            db.Proprietaire.Where(p => p.NomProprio.ToUpper().StartsWith(term.ToUpper())).ToArray();

            return Json(matching.Select(m => new
            {
                id = m.IdProprietaire,
                value = m.NomProprio + " " + m.PrenomProprio,
                label = m.NomProprio + " " + m.PrenomProprio
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNumMin(decimal id)
        {
            List<SelectListItem> plaques = new List<SelectListItem>();
            foreach (var poss in db.Possession.Where(p => p.IdProprietaire == id))
            {
                plaques.Add(new SelectListItem { Text = poss.NumMineralogique, Value = poss.IdPossession.ToString() });
            }

            if (plaques.Count() != 0)
                return Json(new SelectList(plaques, "Value", "Text"));
            else
                plaques.Add(new SelectListItem { Text = "Pas de correspondance.", Value = "" });
            return Json(new SelectList(plaques, "Value", "Text"));
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
