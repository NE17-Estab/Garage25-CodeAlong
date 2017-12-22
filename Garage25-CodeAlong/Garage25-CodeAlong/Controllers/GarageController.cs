using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage25_CodeAlong.DataAccess;
using Garage25_CodeAlong.Models;
using Garage25_CodeAlong.Models.ViewModels;

namespace Garage25_CodeAlong.Controllers
{
    public class GarageController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Garage
        public ActionResult Index()
        {
            var parkedVehicles = db.ParkedVehicles.Include(p => p.Member).Include(p => p.VehicleType);
            return View(parkedVehicles.ToList());
        }

        // GET: Garage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: Garage/Create
        public ActionResult Park()
        {
            ParkVehicleViewModel model = new ParkVehicleViewModel();
            model.Members = new SelectList(db.Members, "Id", "FName");
            model.Types =  new SelectList(db.VehicleTypes, "Id", "TypeName");
            //ViewBag.Id = 
            //ViewBag.TypeId =
            return View(model);
        }

        // POST: Garage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park([Bind(Include = "Id,RegNr,Color,Model,Brand,NrOfWheels,ParkingTime,TypeId,MemberId")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Members, "Id", "FName", parkedVehicle.Id);
            ViewBag.TypeId = new SelectList(db.VehicleTypes, "Id", "TypeName", parkedVehicle.TypeId);
            return View(parkedVehicle);
        }

        // GET: Garage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Members, "Id", "FName", parkedVehicle.Id);
            ViewBag.TypeId = new SelectList(db.VehicleTypes, "Id", "TypeName", parkedVehicle.TypeId);
            return View(parkedVehicle);
        }

        // POST: Garage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNr,Color,Model,Brand,NrOfWheels,ParkingTime,TypeId,MemberId")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Members, "Id", "FName", parkedVehicle.Id);
            ViewBag.TypeId = new SelectList(db.VehicleTypes, "Id", "TypeName", parkedVehicle.TypeId);
            return View(parkedVehicle);
        }

        // GET: Garage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: Garage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            db.ParkedVehicles.Remove(parkedVehicle);
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
