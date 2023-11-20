using coreData.Data;
using coreModel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace corekatmanproje.Controllers
{
    public class KidsController : Controller
    {
        public readonly ApplicationDbContext dbContext;
        public KidsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var result = dbContext.kids.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Kids kid)
        {
            dbContext.Add(kid);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return View();
            }
            var result = await dbContext.kids.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Kids kid)
        {
            dbContext.Update(kid);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await dbContext.kids.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await dbContext.kids.FindAsync(id);
            dbContext.kids.Remove(result);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
