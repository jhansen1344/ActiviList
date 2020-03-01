using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviList.Models
{
    public class ItemListItem
    {
        public int Id { get; set; }
        
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        
        [Display(Name = "Nombre de Cosa")]
        public string Nombre { get; set; }
        [Display(Name = "Item Location")]
        public string Location { get; set; }
    }
}
