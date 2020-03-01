using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviList.Data
{
    public class SubActivity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name = "Acitvity Name")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "Demasiado Letras")]
        [Display(Name = "Nombre de Actividad")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Item List /Lista de Articulos")]
        public List<Item> Items { get; set; }

    }
}
