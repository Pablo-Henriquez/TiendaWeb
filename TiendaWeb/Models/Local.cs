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

    public partial class Local
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Local()
        {
            this.OrdenCompra = new HashSet<OrdenCompra>();
            this.Stock = new HashSet<Stock>();
        }
        [Key]
        public int IdLocal { get; set; }
        [Display(Name = "Local")]
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El mombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Direción")]
        [MaxLength(100, ErrorMessage = "La dirección no puede tener más de 100 caracteres")]
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenCompra> OrdenCompra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
