using System;
using Timesheets.Data.Abstractions;
using ExtCore.Data.Abstractions;

namespace Timesheets.ViewModels.EmployeeDetail
{
    internal class EmployeeDetailModelFactory
    {
        public EmployeeDetailModelFactory()
        {
        }

        internal EmployeeDetailIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var employeeDetailRepo = storage.GetRepository<IEmployeeDetailRepository>();

            return new EmployeeDetailIndexViewModel(employeeDetailRepo.All(page, size));
        }
    }
}
