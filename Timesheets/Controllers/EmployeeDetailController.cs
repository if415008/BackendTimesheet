using Timesheets.Data.Abstractions;
using Timesheets.Data.Entities;
using Timesheets.ViewModels.EmployeeDetail;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Timesheets.Controllers
{
    //[Authorize]
    public class EmployeeDetailController : Barebone.Controllers.ControllerBase
    {
        public EmployeeDetailController(IStorage storage) : base(storage)
        {
        }

        public ActionResult Index(int page = 0, int size = 25)
        {
            return View(new EmployeeDetailModelFactory().LoadAll(this.Storage, page, size));
        }

        public ActionResult Create()
        {
            var model = new EmployeeDetailCreateViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeDetailCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                EmployeeDetail employeeDetail = model.ToEntity();
                this.Storage.GetRepository<IEmployeeDetailRepository>().Create(employeeDetail, this.GetCurrentUserName());
                this.Storage.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
