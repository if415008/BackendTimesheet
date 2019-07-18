using System;
using System.ComponentModel.DataAnnotations;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Timesheet
{
    public class TimesheetCreateViewModel
    {
        public DateTimeOffset TimesheetDate { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public int TotalTimeByTask { get; set; }
        public int TotalTimeToday { get; set; }

        internal Data.Entities.Timesheet ToEntity()
        {
            return new Data.Entities.Timesheet
            {
                TimesheetDate = this.TimesheetDate,
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                TotalTimeByTask = this.TotalTimeByTask,
                TotalTimeToday = this.TotalTimeToday
            };
        }
    }
}
