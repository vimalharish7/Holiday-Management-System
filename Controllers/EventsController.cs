using FIT5032_Assignment_Portfolio_Final.Models;
using System;
using FIT5032_Assignment_Portfolio_Final.Utils;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using System.Net.Mail;

namespace FIT5032_Assignment_Portfolio_Final.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private EventSystemModelContainer db = new EventSystemModelContainer();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.Include(c => c.Customer);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.CustomerCustId = new SelectList(db.Customers, "CustId", "Name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventName,Description,Date,Rating,Price,Latitude,Longitude,CustomerCustId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerCustId = new SelectList(db.Customers, "CustId", "Name", @event.CustomerCustId);
            return View(@event);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerCustId = new SelectList(db.Customers, "CustId", "Name", @event.CustomerCustId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventName,Description,Date,Rating,Price,Latitude,Longitude,CustomerCustId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerCustId = new SelectList(db.Customers, "CustId", "Name", @event.CustomerCustId);
            return View(@event);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Book(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        public ActionResult EventList()
        {
            return View(db.Events.ToList());
        }

        public ActionResult Reports(string ReportType)
        {
            LocalReport reporting = new LocalReport();
            
            reporting.ReportPath = Server.MapPath("~/Reports/EventReport.rdlc");
            ReportDataSource reportDS = new ReportDataSource();
            reportDS.Name = "EventDataSet";
            reportDS.Value = db.Events.ToList();
            reporting.DataSources.Add(reportDS);
            string reportType = ReportType;
            string FileNameExtension;
            if (reportType == "PDF")
            {             
                FileNameExtension = "pdf";
            }
            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            string mimeType;
            string encoding;
            renderedByte = reporting.Render(reportType, "", out mimeType, out encoding, out FileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition","attachment;filename= event_report." + FileNameExtension);
            return File(renderedByte,FileNameExtension);
            
        }

        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
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
