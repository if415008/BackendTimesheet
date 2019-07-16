using System.Collections.Generic;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Task
{
    public class TaskIndexViewModel
    {
        public TaskIndexViewModel(IEnumerable<Data.Entities.Task> data)
        {
            Tasks = data ?? new List<Data.Entities.Task>();
        }

        public IEnumerable<Data.Entities.Task> Tasks { get; }
    }
}
