using Timesheets.Data.Abstractions;
using Timesheets.Data.Entities;
using Timesheets.ViewModels.Task;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Timesheets.Controllers
{
    //[Authorize]
    public class TaskController : Barebone.Controllers.ControllerBase
    {
        public TaskController(IStorage storage) : base(storage)
        {
        }

        public ActionResult Index(int page = 0, int size = 25)
        {
            return View(new TaskModelFactory().LoadAll(this.Storage, page, size));
        }

        public ActionResult Create()
        {
            var model = new TaskCreateViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TaskCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Task task = model.ToEntity();
                this.Storage.GetRepository<ITaskRepository>().Create(task, this.GetCurrentUserName());
                this.Storage.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
