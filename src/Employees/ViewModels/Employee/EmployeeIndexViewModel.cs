using System.Collections.Generic;
using Employees.Data.Entities;

namespace Employees.ViewModels.Employee
{
    public class EmployeeIndexViewModel
    {
        public EmployeeIndexViewModel(IEnumerable<Data.Entities.Employee> data)
        {
            Employees = data ?? new List<Data.Entities.Employee>();
        }

        public IEnumerable<Data.Entities.Employee> Employees { get; }
    }
}