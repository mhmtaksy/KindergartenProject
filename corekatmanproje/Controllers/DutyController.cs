using coreData.Data;
using coreModel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace corekatmanproje.Controllers
{
    public class DutyController : Controller
    {
        public readonly ApplicationDbContext dbContext;

        public DutyController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var result = dbContext.dutys.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Duty duty)
        {
           dbContext.Add(duty);
           await dbContext.SaveChangesAsync();
           return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var result =await dbContext.dutys.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Duty duty)
        {
            dbContext.Update(duty);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return View();
            }
            var result = await dbContext.dutys.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await dbContext.dutys.FindAsync(id);
            dbContext.dutys.Remove(result);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
