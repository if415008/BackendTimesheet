using System;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Timesheet
{
    public class TimesheetUpdateViewModel
    {
        public TimesheetUpdateViewModel() { }

        private readonly Data.Entities.Timesheet _entity;

        public DateTimeOffset TimesheetDate { get; set; }

        internal Data.Entities.Timesheet ToEntity(Data.Entities.Timesheet entity, string username)
        {
            entity.TimesheetDate = this.TimesheetDate;
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
