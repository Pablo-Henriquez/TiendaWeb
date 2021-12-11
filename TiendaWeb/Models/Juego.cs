//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Juego
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Juego()
        {
            this.Stock = new HashSet<Stock>();
        }
        [Key]
        public int IdJuego { get; set; }
        [Display(Name ="Código")]
        [Required(ErrorMessage = "Código es obligatorio")]
        [MaxLength(50, ErrorMessage = "Código no puede tener más de 50 caracteres")]
        public string Codigo { get; set; }
        [Display(Name = "Juego")]
        [Required(ErrorMessage = "NOmbre del juego es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name ="Precio")]
        [Required(ErrorMessage = "El precio es obligatorio")]
        public int Precio { get; set; }
        [Display(Name = "Descipción")]
        public string Descripcion { get; set; }
        public int IdCompania { get; set; }
        public int IdCategoria { get; set; }
        public int Idplataforma { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Compania Compania { get; set; }
        public virtual Plataforma Plataforma { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
