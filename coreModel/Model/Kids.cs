using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreModel.Model
{
    public class Kids
    {
        [Key]
        public int kidID { get; set; }
        public string kidNameSurname { get; set; }
        public string kidGender { get; set; }
        public DateTime kidBirth { get; set; }

        [ForeignKey("employeeID")]
        public int employeeID { get; set; }

        public Employee employee { get; set; }
    }
}
