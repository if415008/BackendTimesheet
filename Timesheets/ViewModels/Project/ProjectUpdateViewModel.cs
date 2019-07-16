using System;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Project
{
    public class ProjectUpdateViewModel
    {
        public ProjectUpdateViewModel() { }

        private readonly Data.Entities.Project _entity;
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string ProjectStatus { get; set; }

        internal Data.Entities.Project ToEntity(Data.Entities.Project entity, string username)
        {
            entity.ProjectName = this.ProjectName;
            entity.ClientName = this.ClientName;
            entity.ProjectStatus = this.ProjectStatus;
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
