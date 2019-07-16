using System;
using System.ComponentModel.DataAnnotations;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.EmployeeDetail
{
    public class EmployeeDetailCreateViewModel
    {
        internal Data.Entities.EmployeeDetail ToEntity()
        {
            return new Data.Entities.EmployeeDetail
            {
            };
        }
    }
}
