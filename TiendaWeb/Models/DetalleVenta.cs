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
    
    public partial class DetalleVenta
    {
        public int IdDetalle { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int IdStock { get; set; }
        public int IdVenta { get; set; }
    
        public virtual Stock Stock { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
