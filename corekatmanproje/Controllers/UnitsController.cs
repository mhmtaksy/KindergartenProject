using coreData.Data;
using corekatmanproje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace corekatmanproje.Controllers
{
    public class UnitsController : Controller
    {
        public readonly ApplicationDbContext dbContext;
        public UnitsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var result = dbContext.units.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(Units units)
        {
            dbContext.Add(units);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result =await dbContext.projects.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Units units)
        {
            dbContext.Update(units);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await dbContext.projects.FindAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await dbContext.units.FindAsync(id);
            dbContext.units.Remove(result);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
