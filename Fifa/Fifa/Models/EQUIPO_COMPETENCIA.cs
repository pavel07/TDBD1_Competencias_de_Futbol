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
    
    public partial class EQUIPO_COMPETENCIA
    {
        public int ID_EQUIPO { get; set; }
        public int ID_COMPETENCIA { get; set; }
        public Nullable<int> PUNTOS { get; set; }
        public Nullable<int> POSICION { get; set; }
    
        public virtual COMPETENCIA COMPETENCIA { get; set; }
        public virtual EQUIPO EQUIPO { get; set; }
    }
}
