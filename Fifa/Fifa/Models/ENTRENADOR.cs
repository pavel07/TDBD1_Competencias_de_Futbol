//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fifa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ENTRENADOR
    {
        public ENTRENADOR()
        {
            this.EQUIPO = new HashSet<EQUIPO>();
        }
    
        public decimal ID_ENTRENADOR { get; set; }
        public decimal ID_PAIS { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<decimal> EDAD { get; set; }
        public Nullable<decimal> CEDULA_IDENTIDAD { get; set; }
        public string BIOGRAFIA { get; set; }
        public byte[] FOTO { get; set; }
    
        public virtual PAIS PAIS { get; set; }
        public virtual ICollection<EQUIPO> EQUIPO { get; set; }
    }
}
