using System.ComponentModel.DataAnnotations;

namespace corekatmanproje.Models
{
    public class Title
    {
        [Key]
        public int titleID { get; set; }

        public string titleName { get; set; }
    }
}
