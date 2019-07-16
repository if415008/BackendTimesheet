using System;
using Timesheets.Data.Abstractions;
using ExtCore.Data.Abstractions;

namespace Timesheets.ViewModels.Sprint
{
    internal class SprintModelFactory
    {
        public SprintModelFactory()
        {
        }

        internal SprintIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var sprintRepo = storage.GetRepository<ISprintRepository>();

            return new SprintIndexViewModel(sprintRepo.All(page, size));
        }
    }
}
