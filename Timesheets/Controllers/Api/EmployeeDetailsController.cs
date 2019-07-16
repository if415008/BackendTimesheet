using Barebone.Controllers;
using Data.Entities;
using Timesheets.Data.Abstractions;
using Timesheets.Data.Entities;
using Timesheets.ViewModels.EmployeeDetail;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Timesheets.Controllers.Api
{
    //[Authorize]
    [Route("api/employeeDetails")]
    public class EmployeeDetailsController : ControllerBaseApi
    {
        public EmployeeDetailsController(IStorage storage) : base(storage)
        {
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<EmployeeDetail> data = new EmployeeDetailModelFactory().LoadAll(this.Storage, page, size)?.EmployeeDetails;
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
        public IActionResult Post(EmployeeDetailCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                EmployeeDetail employeeDetail = model.ToEntity();
                var repo = this.Storage.GetRepository<IEmployeeDetailRepository>();

                repo.Create(employeeDetail, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<IEmployeeDetailRepository>();

            EmployeeDetail employeeDetail = repo.WithKey(id);
            if (employeeDetail == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = employeeDetail });
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, EmployeeDetailUpdateViewModel model)
        {
            var repo = this.Storage.GetRepository<IEmployeeDetailRepository>();

            EmployeeDetail employeeDetail = repo.WithKey(id);
            if (employeeDetail == null)
                return this.NotFound(new { success = false });

            if (this.ModelState.IsValid)
            {
                model.ToEntity(employeeDetail, this.GetCurrentUserName());
                repo.Edit(employeeDetail, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<IEmployeeDetailRepository>();

            EmployeeDetail employeeDetail = repo.WithKey(id);
            if (employeeDetail == null)
                return this.NotFound(new { success = false });

            repo.Delete(employeeDetail, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }
    }
}
