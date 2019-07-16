using Barebone.Controllers;
using Data.Entities;
using Timesheets.Data.Abstractions;
using Timesheets.Data.Entities;
using Timesheets.ViewModels.Project;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Timesheets.Controllers.Api
{
    //[Authorize]
    [Route("api/projects")]
    public class ProjectsController : ControllerBaseApi
    {
        public ProjectsController(IStorage storage) : base(storage)
        {
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<Project> data = new ProjectModelFactory().LoadAll(this.Storage, page, size)?.Projects;
            int count = data.Count();

            return Ok(new
            {
                success = true,
                data,
                count,
                totalPage = ((int)count / size) + 1
            });
        }

        [HttpPost]
        public IActionResult Post(ProjectCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Project project = model.ToEntity();
                var repo = this.Storage.GetRepository<IProjectRepository>();

                repo.Create(project, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<IProjectRepository>();

            Project project = repo.WithKey(id);
            if (project == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = project });
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, ProjectUpdateViewModel model)
        {
            var repo = this.Storage.GetRepository<IProjectRepository>();

            Project project = repo.WithKey(id);
            if (project == null)
                return this.NotFound(new { success = false });

            if (this.ModelState.IsValid)
            {
                model.ToEntity(project, this.GetCurrentUserName());
                repo.Edit(project, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<IProjectRepository>();

            Project project = repo.WithKey(id);
            if (project == null)
                return this.NotFound(new { success = false });

            repo.Delete(project, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }
    }
}
