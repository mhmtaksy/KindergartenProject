using coreData.Data;
using corekatmanproje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace corekatmanproje.Controllers
{
    public class TitleController : Controller
    {
        public readonly ApplicationDbContext dbContext;
        public TitleController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var result = dbContext.titles.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Title title)
        {
            dbContext.titles.Add(title);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var result = await dbContext.titles.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Title title)
        {
            dbContext.titles.Update(title);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await dbContext.titles.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await dbContext.titles.FindAsync(id);
            dbContext.titles.Remove(result);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
