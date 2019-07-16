using System.Collections.Generic;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Sprint
{
    public class SprintIndexViewModel
    {
        public SprintIndexViewModel(IEnumerable<Data.Entities.Sprint> data)
        {
            Sprints = data ?? new List<Data.Entities.Sprint>();
        }

        public IEnumerable<Data.Entities.Sprint> Sprints { get; }
    }
}
