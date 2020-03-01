using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviList.Data
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name="Item Name")]
        public string Name { get; set; }
        [Display(Name = "Item Location")]
        public string Location { get; set; }

    }
}
