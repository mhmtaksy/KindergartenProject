using coreData.Data;
using coreModel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace corekatmanproje.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var result = dbContext.employees.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            dbContext.Add(employee);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var result = await dbContext.employees.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            dbContext.Update(employee);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await dbContext.employees.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await dbContext.employees.FindAsync(id);
            dbContext.employees.Remove(result);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
