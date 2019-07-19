using System;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.EmployeeDetail
{
    public class EmployeeDetailUpdateViewModel
    {
        public EmployeeDetailUpdateViewModel() { }

        private readonly Data.Entities.EmployeeDetail _entity;

        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        internal Data.Entities.EmployeeDetail ToEntity(Data.Entities.EmployeeDetail entity, string username)
        {
            //entity.EmployeeId = this.EmployeeId;
            //entity.ProjectId = this.ProjectId;
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
