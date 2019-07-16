using Timesheets.Data.Abstractions;
using Timesheets.Data.Entities;
using Timesheets.ViewModels.Project;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Timesheets.Controllers
{
    //[Authorize]
    public class ProjectController : Barebone.Controllers.ControllerBase
    {
        public ProjectController(IStorage storage) : base(storage)
        {
        }

        public ActionResult Index(int page = 0, int size = 25)
        {
            return View(new ProjectModelFactory().LoadAll(this.Storage, page, size));
        }

        public ActionResult Create()
        {
            var model = new ProjectCreateViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProjectCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Project project = model.ToEntity();
                this.Storage.GetRepository<IProjectRepository>().Create(project, this.GetCurrentUserName());
                this.Storage.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
