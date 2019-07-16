using Timesheets.Data.Abstractions;
using Timesheets.Data.Entities;
using Timesheets.ViewModels.Sprint;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Timesheets.Controllers
{
    //[Authorize]
    public class SprintController : Barebone.Controllers.ControllerBase
    {
        public SprintController(IStorage storage) : base(storage)
        {
        }

        public ActionResult Index(int page = 0, int size = 25)
        {
            return View(new SprintModelFactory().LoadAll(this.Storage, page, size));
        }

        public ActionResult Create()
        {
            var model = new SprintCreateViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(SprintCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Sprint sprint = model.ToEntity();
                this.Storage.GetRepository<ISprintRepository>().Create(sprint, this.GetCurrentUserName());
                this.Storage.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
