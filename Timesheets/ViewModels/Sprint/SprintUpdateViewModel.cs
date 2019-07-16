using System;
using Timesheets.Data.Entities;

namespace Timesheets.ViewModels.Sprint
{
    public class SprintUpdateViewModel
    {
        public SprintUpdateViewModel() { }

        private readonly Data.Entities.Sprint _entity;

        public int SprintNumber { get; set; }

        internal Data.Entities.Sprint ToEntity(Data.Entities.Sprint entity, string username)
        {
            entity.SprintNumber = this.SprintNumber;
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
