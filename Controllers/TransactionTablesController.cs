using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyGamesNew.Models;


namespace EasyGamesNew.Controllers
{
    public class TransactionTablesController : Controller
    {
        private EasyGamesNewString db = new EasyGamesNewString();

        // GET: TransactionTables
        public ActionResult Index()
        {
            var transactionTables = db.TransactionTables.Include(t => t.Client).Include(t => t.TransactionType);
            return View(transactionTables.ToList());
        }


    

        // GET: TransactionTables/Details/5

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionTable transactionTable = db.TransactionTables.Find(id);
            if (transactionTable == null)
            {
                return HttpNotFound();
            }
            else
            {
                
                return View(transactionTable);

            }
        }

       

        // GET: TransactionTables/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "Name");
            ViewBag.TransactionTypeID = new SelectList(db.TransactionTypes, "TransactionTypeID", "TarnsactionTypeName");
            return View();
        }

        // POST: TransactionTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionID,Amount,Comment,ClientID,TransactionTypeID")] TransactionTable transactionTable)
        {
            if (ModelState.IsValid)
            {
                transactionTable.Updated = transactionTable.BalanceUpdate(transactionTable);
                db.TransactionTables.Add(transactionTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "Name", transactionTable.ClientID);
            ViewBag.TransactionTypeID = new SelectList(db.TransactionTypes, "TransactionTypeID", "TarnsactionTypeName", transactionTable.TransactionTypeID);
            return View(transactionTable);
        }

        // GET: TransactionTables/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionTable transactionTable = db.TransactionTables.Find(id);
            
            if (transactionTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "Name", transactionTable.ClientID);
            ViewBag.TransactionTypeID = new SelectList(db.TransactionTypes, "TransactionTypeID", "TarnsactionTypeName", transactionTable.TransactionTypeID);
            return View(transactionTable);
        }

        // POST: TransactionTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionID,Amount,Comment,ClientID,TransactionTypeID")] TransactionTable transactionTable)
        {
            if (ModelState.IsValid)
            {
                var TranID = db.TransactionTables.First(x => x.TransactionID == transactionTable.TransactionID);
                TranID.Comment = transactionTable.Comment;
               


                db.Entry(TranID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "Name", transactionTable.ClientID);
            ViewBag.TransactionTypeID = new SelectList(db.TransactionTypes, "TransactionTypeID", "TarnsactionTypeName", transactionTable.TransactionTypeID);
            return View(transactionTable);
        }

        // GET: TransactionTables/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionTable transactionTable = db.TransactionTables.Find(id);
            if (transactionTable == null)
            {
                return HttpNotFound();
            }
            return View(transactionTable);
        }

        // POST: TransactionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TransactionTable transactionTable = db.TransactionTables.Find(id);
            db.TransactionTables.Remove(transactionTable);
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
