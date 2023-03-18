using CAMPUSproject.Areas.Identity.Data;
using CAMPUSproject.Data;
using CAMPUSproject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using TeamUpSpace.Models;

namespace CAMPUSproject.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDbContext db;
        private readonly UserManager<MyProjectUser> manager;
        private IdentityDbContext identityDb;
        public ProjectController(ProjectDbContext db, UserManager<MyProjectUser> manager, IdentityDbContext identityDb)
        {
            this.db = db;
            this.manager = manager;
            this.identityDb = identityDb;
        }

        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectModel? project)
        {
            var Userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await manager.FindByIdAsync(Userid);

            db.Projects.Add(project);
            await db.SaveChangesAsync();
            //var id = await db.Projects
            //    .Where(x => x.ProjectName == project.ProjectName)
            //    .Where(x => x.Category == project.Description)
            //    .Select(x => x.Id)
            //    .FirstOrDefaultAsync();
            user.Project = project;
            identityDb.Users.Update(user);
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ProjectDetails()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await manager.FindByIdAsync(userId);
            var project = await db.Projects.Include(u => u.Users).FirstOrDefaultAsync();
            if (project.Users is null)
            {
                ViewBag.Title = "У вас пока еще нет проекта";
                return View();
            }

            return View();
        }
    }
}