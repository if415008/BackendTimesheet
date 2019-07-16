using System.Collections.Generic;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Project
{
    public class ProjectIndexViewModel
    {
        public ProjectIndexViewModel(IEnumerable<Data.Entities.Project> data)
        {
            Projects = data ?? new List<Data.Entities.Project>();
        }

        public IEnumerable<Data.Entities.Project> Projects { get; }
    }
}
