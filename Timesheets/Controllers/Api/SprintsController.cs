using Barebone.Controllers;
using Data.Entities;
using Timesheets.Data.Abstractions;
using Timesheets.Data.Entities;
using Timesheets.ViewModels.Sprint;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Timesheets.Controllers.Api
{
    //[Authorize]
    [Route("api/sprints")]
    public class SprintsController : ControllerBaseApi
    {
        public SprintsController(IStorage storage) : base(storage)
        {
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<Sprint> data = new SprintModelFactory().LoadAll(this.Storage, page, size)?.Sprints;
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
        public IActionResult Post(SprintCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Sprint sprint = model.ToEntity();
                var repo = this.Storage.GetRepository<ISprintRepository>();

                repo.Create(sprint, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<ISprintRepository>();

            Sprint sprint = repo.WithKey(id);
            if (sprint == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = sprint });
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, SprintUpdateViewModel model)
        {
            var repo = this.Storage.GetRepository<ISprintRepository>();

            Sprint sprint = repo.WithKey(id);
            if (sprint == null)
                return this.NotFound(new { success = false });

            if (this.ModelState.IsValid)
            {
                model.ToEntity(sprint, this.GetCurrentUserName());
                repo.Edit(sprint, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<ISprintRepository>();

            Sprint sprint = repo.WithKey(id);
            if (sprint == null)
                return this.NotFound(new { success = false });

            repo.Delete(sprint, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }
    }
}
