using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel.Model
{
    public class TitleEmp
    {
        public int titleID { get; set; }

        public string titleName { get; set; }

        public int employeeID { get; set; }
        [Required]
        public string employeeNameSurname { get; set; }

        public string employeeGender { get; set; }

        public DateTime employeeDOS { get; set; }
        public bool employeeShift { get; set; }

        public decimal employeeWage { get; set; }
        public decimal employeeBounty { get; set; }
    }
}
