using System;
using System.ComponentModel.DataAnnotations;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Timesheet
{
    public class TimesheetCreateViewModel
    {
        [Display(Name = "Timesheet Date")]
        [Required()]
        public DateTimeOffset TimesheetDate { get; set; }

        internal Data.Entities.Timesheet ToEntity()
        {
            return new Data.Entities.Timesheet
            {
                TimesheetDate = this.TimesheetDate
            };
        }
    }
}
