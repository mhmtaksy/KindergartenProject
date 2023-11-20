using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using corekatmanproje.Models;

namespace coreModel.Model
{
    public class Duty
    {
        [Key]
        public int dutyID { get; set; }

        public string dutyDefinition { get; set; }
        public string dutyName { get; set; }
        public int dutyPoint { get; set; }

        public ICollection<Units> units { get; set; }
    }
}
