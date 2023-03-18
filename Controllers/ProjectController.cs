using CAMPUSproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;
using TeamUpSpace.Models;

namespace  CAMPUSproject.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDbContext db;

        public ProjectController(ProjectDbContext db)
        {
            this.db = db;
        }

        public IActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProject(ProjectModel? project) 
        {
            if (project is not null) 
            {
                db.Add(project);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ProjectDetails(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var project = await db.Projects.Select(p => p).FirstOrDefaultAsync(i=>i.Id == id);

            return View();
        }
    }
}