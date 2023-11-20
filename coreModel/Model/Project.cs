using coreModel.Model;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace corekatmanproje.Models
{
    public class Project
    {
        public int projectID { get; set; }
        public string projectName { get; set; }

        public DateTime projectDOS { get; set; }
        public DateTime projectDOE { get; set; }
        [ForeignKey("dutyID")]
        public int dutyID { get; set; }
        public Duty duty { get; set; }
    }
}
