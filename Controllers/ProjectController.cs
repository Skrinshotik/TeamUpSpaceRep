using CAMPUSproject.Areas.Identity.Data;
using CAMPUSproject.Data;
using CAMPUSproject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using TeamUpSpace.Models;

namespace CAMPUSproject.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private ProjectDbContext db;
        private readonly UserManager<MyProjectUser> manager;
        private MyIdentityDbContext identityDb;
        public ProjectController(ProjectDbContext db, UserManager<MyProjectUser> manager, MyIdentityDbContext identityDb)
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
            if(user.ProjectModelId != null)
            {
                return RedirectToAction("Index", "Home");

            }
            project.UserId = user.Id;
            user.Project = new ProjectModel();
            user.ProjectModelId = project.Id;
            project.Users.Add(user);
            db.GetProjects.Add(project);
            await db.SaveChangesAsync();
           

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ProjectDetails()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await manager.FindByIdAsync(userId);
            var project = await db.GetProjects.Where(x=>x.UserId==userId).Include(u => u.Users).FirstOrDefaultAsync();
            if(project is null)
            {
                ViewBag.Title = "У вас пока еще нет проекта";
                return View();
            }
            var users = project.Users.Where(x => x.ProjectModelId == project.Id).Select(x => x).ToList();
            project.Users = users;
            if (project.Users is null)
            {
                ViewBag.Title = "У вас пока еще нет проекта";
                return View();
            }
            
            return View(project);
        }

        public async Task<IActionResult> AddToProject(int ProjectId)
        {
            return View(await identityDb.Users.ToListAsync());
        }

        public async Task<IActionResult> FindProject()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await manager.FindByIdAsync(userId);
            if(db.GetProjects.Any(x => x.UserId == userId))
            {
                return RedirectToAction(nameof(ProjectDetails));
            }
            var projects = await db.GetProjects.Distinct().ToListAsync();
            var project = projects.First();
            List<MyProjectUser> users = new List<MyProjectUser>();
            users.Add(user);
            await db.SaveChangesAsync();
            return View(projects);
        }
    }
}