using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimesheetApiApplication.Models
{
    public class Timesheet
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public decimal Duration { get; set; }
    }
}