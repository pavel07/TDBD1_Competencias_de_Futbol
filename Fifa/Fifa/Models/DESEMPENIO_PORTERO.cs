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
    
    public partial class DESEMPENIO_PORTERO
    {
        public int ID_JUGADOR { get; set; }
        public int ID_RESULTADO { get; set; }
        public Nullable<int> CAPACIDAD_ATAJAR { get; set; }
        public Nullable<int> LUCHA1_1 { get; set; }
        public Nullable<int> ANTICIPACION { get; set; }
        public Nullable<int> REFLEJOS { get; set; }
    
        public virtual RESULTADO RESULTADO { get; set; }
        public virtual JUGADOR JUGADOR { get; set; }
    }
}
