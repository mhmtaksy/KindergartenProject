using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using corekatmanproje.Models;

namespace coreModel.Model
{
    public class Employee
    {
        [Key]
        public int employeeID { get; set; }
        [Required]
        public string employeeNameSurname { get; set; }

        public string employeeGender { get; set; }

        public DateTime employeeDOS { get; set; }
        public bool employeeShift { get; set; }

        public decimal employeeWage { get; set; }
        public decimal employeeBounty { get; set; }
        [ForeignKey("dutyID")]
        public int dutyID { get; set; }
        [ForeignKey("titleID")]
        public int titleID { get; set; }

        public Duty duty { get; set; }
        public Title title { get; set; }



    }
}
