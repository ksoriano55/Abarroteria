//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Abarroteria.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Factura
    {
        public int FacturaID { get; set; }
        public string CodigoFactura { get; set; }
        public int ClienteId { get; set; }
        public string TipoFactura { get; set; }
        public System.DateTime FechaFactura { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public Nullable<decimal> ValorFactura { get; set; }
        public Nullable<decimal> SaldoPendiente { get; set; }
    
        public virtual Cliente Cliente { get; set; }
    }
}