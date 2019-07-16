using System;
using Timesheets.Data.Abstractions;
using ExtCore.Data.Abstractions;

namespace Timesheets.ViewModels.Task
{
    internal class TaskModelFactory
    {
        public TaskModelFactory()
        {
        }

        internal TaskIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var taskRepo = storage.GetRepository<ITaskRepository>();

            return new TaskIndexViewModel(taskRepo.All(page, size));
        }
    }
}
