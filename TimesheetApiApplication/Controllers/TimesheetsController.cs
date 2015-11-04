using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using TimesheetApiApplication.DAL;
using TimesheetApiApplication.Models;

namespace TimesheetApiApplication.Controllers
{
    [EnableCors(origins:"*", headers: "*", methods: "*")]
    public class TimesheetsController : ApiController
    {
        private TimesheetContext db = new TimesheetContext();

        // GET: api/Timesheets
        public IQueryable<Timesheet> GetTimesheets()
        {
            return db.Timesheets;
        }

        // GET: api/Timesheets/5
        [ResponseType(typeof(Timesheet))]
        public IHttpActionResult GetTimesheet(int id)
        {
            Timesheet timesheet = db.Timesheets.Find(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return Ok(timesheet);
        }

        // PUT: api/Timesheets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTimesheet(int id, Timesheet timesheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timesheet.Id)
            {
                return BadRequest();
            }

            db.Entry(timesheet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimesheetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Timesheets
        [ResponseType(typeof(Timesheet))]
        public IHttpActionResult PostTimesheet(Timesheet timesheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Timesheets.Add(timesheet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = timesheet.Id }, timesheet);
        }

        // DELETE: api/Timesheets/5
        [ResponseType(typeof(Timesheet))]
        public IHttpActionResult DeleteTimesheet(int id)
        {
            Timesheet timesheet = db.Timesheets.Find(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            db.Timesheets.Remove(timesheet);
            db.SaveChanges();

            return Ok(timesheet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimesheetExists(int id)
        {
            return db.Timesheets.Count(e => e.Id == id) > 0;
        }
    }
}