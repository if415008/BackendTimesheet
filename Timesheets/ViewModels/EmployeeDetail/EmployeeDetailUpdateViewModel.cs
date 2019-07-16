using System;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.EmployeeDetail
{
    public class EmployeeDetailUpdateViewModel
    {
        public EmployeeDetailUpdateViewModel() { }

        private readonly Data.Entities.EmployeeDetail _entity;

        internal Data.Entities.EmployeeDetail ToEntity(Data.Entities.EmployeeDetail entity, string username)
        {
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
