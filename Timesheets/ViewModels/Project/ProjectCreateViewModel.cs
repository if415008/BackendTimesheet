using System;
using System.ComponentModel.DataAnnotations;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Project
{
    public class ProjectCreateViewModel
    {
        [Display(Name = "Project Name")]
        [Required()]
        public string ProjectName { get; set; }

        [Display(Name = "Client Name")]
        [Required()]
        public string ClientName { get; set; }

        [Display(Name = "Project Status")]
        [Required()]
        public string ProjectStatus { get; set; }

        internal Data.Entities.Project ToEntity()
        {
            return new Data.Entities.Project
            {
                ProjectName = this.ProjectName,
                ClientName = this.ClientName,
                ProjectStatus = this.ProjectStatus
            };
        }
    }
}
