using System;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Sprint
{
    public class SprintUpdateViewModel
    {
        public SprintUpdateViewModel() { }

        private readonly Data.Entities.Sprint _entity;

        public int SprintNumber { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        //public int ProjectId { get; set; }


        internal Data.Entities.Sprint ToEntity(Data.Entities.Sprint entity, string username)
        {
            entity.SprintNumber = this.SprintNumber;
            entity.StartDate = this.StartDate;
            //entity.ProjectId = this.ProjectId;
            entity.EndDate = DateTime.Now;
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
