using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage25_CodeAlong.DataAccessLayer;
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
            ParkedVehicleViewModel model = new ParkedVehicleViewModel();
            model.Members = new SelectList(db.Members, "Id", "FName");         //viewbag acts like a dictionary  and we have deleted automated generated create view to create manually to this actionresult Park instead of viewbag we have modified like dis
            model.Types = new SelectList(db.VehicleTypes, "Id", "TypeName");
            return View(model);
        }

        // POST: Garage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park(ParkedVehicleViewModel parkVehicleviewModel)          // changed code here and removed parking time property here and in park html also
        {
            if (ModelState.IsValid)
            {
                ParkedVehicle parkedVehicle = new ParkedVehicle();                                 //we have added/edited code here
                parkedVehicle.MemberId = int.Parse(parkVehicleviewModel.MemberId);                 //giving here like dis becoz we  have changed e-r diagram as 0->many(member->parkedvehicle)
                                                                                                   //bcoz its a string we are adding 
                parkedVehicle.TypeId = int.Parse(parkVehicleviewModel.TypesId);
                parkedVehicle.Brand = parkVehicleviewModel.Brand;
                parkedVehicle.Color = parkVehicleviewModel.Color;
                parkedVehicle.Model = parkVehicleviewModel.Model;
                parkedVehicle.NoOfWheels = parkVehicleviewModel.NoOfWheels;
                parkedVehicle.ParkingTime = DateTime.Now;
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            parkVehicleviewModel.Members = new SelectList(db.Members, "Id", "FName", parkVehicleviewModel.MemberId);
            parkVehicleviewModel.Types = new SelectList(db.VehicleTypes, "Id", "TypeName", parkVehicleviewModel.TypesId);         //instead of viewbag changed to selectlist
            return View(parkVehicleviewModel);
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
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FName", parkedVehicle.MemberId);
            ViewBag.TypeId = new SelectList(db.VehicleTypes, "Id", "TypeName", parkedVehicle.TypeId);
            return View(parkedVehicle);
        }

        // POST: Garage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNum,Color,Model,Brand,NoOfWheels,ParkingTime,TypeId,MemberId")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FName", parkedVehicle.MemberId);
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
