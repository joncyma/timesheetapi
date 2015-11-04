using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TimesheetApiApplication.Models;

namespace TimesheetApiApplication.DAL
{
    public class TimesheetInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<TimesheetContext>
    {
        protected override void Seed(TimesheetContext context)
        {
            var timesheets = new List<Timesheet>
            {
                new Timesheet {Id = 0, Date = new DateTime(2015, 10, 26), Duration = 1.5M, User = "Jon" },
                new Timesheet {Id = 1, Date = new DateTime(2015, 10, 27), Duration = 7.5M, User = "Jon" },
                new Timesheet {Id = 2, Date = new DateTime(2015, 10, 28), Duration = 8M, User = "Jon" },
                new Timesheet {Id = 3, Date = new DateTime(2015, 10, 29), Duration = 2.5M, User = "Jon" },
                new Timesheet {Id = 4, Date = new DateTime(2015, 10, 30), Duration = 4M, User = "Jon" }
            };

            timesheets.ForEach(t => context.Timesheets.Add(t));
            context.SaveChanges();

        }
    }
}