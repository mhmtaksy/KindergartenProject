using coreData.Data;
using coreModel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace corekatmanproje.Controllers
{
    public class TitleEmpController : Controller
    {
        public readonly ApplicationDbContext dbContext;
        public TitleEmpController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var sonuc = (from c in dbContext.titles
                         join u in dbContext.employees
                         on c.titleID equals u.titleID
                         select new TitleEmp
                         {
                             titleID = c.titleID,
                             titleName = c.titleName,                             
                             employeeID = u.employeeID,
                             employeeNameSurname = u.employeeNameSurname,
                             employeeShift = u.employeeShift

                         }).ToList();

            return View(sonuc);
        }
    }
}
