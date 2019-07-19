using System;
using System.ComponentModel.DataAnnotations;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Task
{
    public class TaskCreateViewModel
    {
        [Display(Name = "Task Name")]
        [Required()]
        public string TaskName { get; set; }
        public int SprintId { get; set; }

        internal Data.Entities.Task ToEntity()
        {
            return new Data.Entities.Task
            {
                TaskName = this.TaskName,
                SprintId = this.SprintId
            };
        }
    }
}
