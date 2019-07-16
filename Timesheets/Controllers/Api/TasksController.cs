using Barebone.Controllers;
using Data.Entities;
using Timesheets.Data.Abstractions;
using Timesheets.Data.Entities;
using Timesheets.ViewModels.Task;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Timesheets.Controllers.Api
{
    //[Authorize]
    [Route("api/tasks")]
    public class TasksController : ControllerBaseApi
    {
        public TasksController(IStorage storage) : base(storage)
        {
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<Task> data = new TaskModelFactory().LoadAll(this.Storage, page, size)?.Tasks;
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
        public IActionResult Post(TaskCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Task task = model.ToEntity();
                var repo = this.Storage.GetRepository<ITaskRepository>();

                repo.Create(task, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<ITaskRepository>();

            Task task = repo.WithKey(id);
            if (task == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = task });
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, TaskUpdateViewModel model)
        {
            var repo = this.Storage.GetRepository<ITaskRepository>();

            Task task = repo.WithKey(id);
            if (task == null)
                return this.NotFound(new { success = false });

            if (this.ModelState.IsValid)
            {
                model.ToEntity(task, this.GetCurrentUserName());
                repo.Edit(task, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<ITaskRepository>();

            Task task = repo.WithKey(id);
            if (task == null)
                return this.NotFound(new { success = false });

            repo.Delete(task, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }
    }
}
