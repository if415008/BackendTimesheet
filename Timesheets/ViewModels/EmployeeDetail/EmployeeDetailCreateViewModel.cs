using System;
using System.ComponentModel.DataAnnotations;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.EmployeeDetail
{
    public class EmployeeDetailCreateViewModel
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        internal Data.Entities.EmployeeDetail ToEntity()
        {
            return new Data.Entities.EmployeeDetail
            {
                EmployeeId = this.EmployeeId,
                ProjectId = this.ProjectId
            };
        }
    }
}
