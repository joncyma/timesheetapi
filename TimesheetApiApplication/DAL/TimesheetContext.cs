using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimesheetApiApplication.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TimesheetApiApplication.DAL
{
    public class TimesheetContext : DbContext
    {
        public TimesheetContext() : base("TimesheetContext")
        {
        }

        public DbSet<Timesheet> Timesheets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}