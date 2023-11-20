using coreData.Data;
using corekatmanproje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace corekatmanproje.Controllers
{
    public class ProjectController : Controller
    {
        public readonly ApplicationDbContext dbContext;
        public ProjectController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var result = dbContext.projects.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            dbContext.projects.Add(project);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await dbContext.projects.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Project project)
        {
            dbContext.projects.Update(project);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await dbContext.projects.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {           
            var result = await dbContext.projects.FindAsync(id);
            dbContext.projects.Remove(result);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
