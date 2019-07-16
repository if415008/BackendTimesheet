using System;
using Timesheets.Data.Abstractions;
using ExtCore.Data.Abstractions;

namespace Timesheets.ViewModels.Project
{
    internal class ProjectModelFactory
    {
        public ProjectModelFactory()
        {
        }

        internal ProjectIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var projectRepo = storage.GetRepository<IProjectRepository>();

            return new ProjectIndexViewModel(projectRepo.All(page, size));
        }
    }
}
