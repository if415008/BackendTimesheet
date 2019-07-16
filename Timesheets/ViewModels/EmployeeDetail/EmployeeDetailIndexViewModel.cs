using System.Collections.Generic;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.EmployeeDetail
{
    public class EmployeeDetailIndexViewModel
    {
        public EmployeeDetailIndexViewModel(IEnumerable<Data.Entities.EmployeeDetail> data)
        {
            EmployeeDetails = data ?? new List<Data.Entities.EmployeeDetail>();
        }

        public IEnumerable<Data.Entities.EmployeeDetail> EmployeeDetails { get; }
    }
}
