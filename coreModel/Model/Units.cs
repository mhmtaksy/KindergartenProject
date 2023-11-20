using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using coreModel.Model;

namespace corekatmanproje.Models
{
    public class Units
    {
        [Key]
        public int unitsID { get; set; }
        [Required]
        public string unitsName { get; set; }
        [Required]
        [Range(100,200,ErrorMessage ="100 ile 200 arasında değer giriniz.")]
        public int unitsNOE { get; set; }
        

        public ICollection<Duty> duty { get; set; }
    }
}
