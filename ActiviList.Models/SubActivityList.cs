using ActiviList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviList.Models
{
    public class SubActivityList
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name = "Acitvity Name")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "Demasiado Letras")]
        [Display(Name = "Nombre de Actividad")]
        public string Nombre { get; set; }
        [Display(Name = "Item List /Lista de Articulos")]
        public List<Item> Items { get; set; }
    }
}
