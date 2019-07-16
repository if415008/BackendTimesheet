using System;
using System.ComponentModel.DataAnnotations;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Sprint
{
    public class SprintCreateViewModel
    {
        [Display(Name = "Sprint Number")]
        [Required()]
        public int SprintNumber { get; set; }

        internal Data.Entities.Sprint ToEntity()
        {
            return new Data.Entities.Sprint
            {
                SprintNumber = this.SprintNumber
            };
        }
    }
}
