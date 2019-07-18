using System;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Task
{
    public class TaskUpdateViewModel
    {
        public TaskUpdateViewModel() { }

        private readonly Data.Entities.Timesheet _entity;

        public string TaskName { get; set; }
        //public int SprintId { get; set; }

        internal Data.Entities.Task ToEntity(Data.Entities.Task entity, string username)
        {
            entity.TaskName = this.TaskName;
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;
            //entity.SprintId = SprintId;

            return entity;
        }
    }
}
