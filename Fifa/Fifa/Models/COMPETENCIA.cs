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
    
    public partial class COMPETENCIA
    {
        public COMPETENCIA()
        {
            this.PARTIDO = new HashSet<PARTIDO>();
            this.EQUIPO_COMPETENCIA = new HashSet<EQUIPO_COMPETENCIA>();
            this.ESTADIO = new HashSet<ESTADIO>();
            this.PAIS = new HashSet<PAIS>();
        }
    
        public decimal ID_COMPETENCIA { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<System.DateTime> FECHA_INICIO { get; set; }
        public Nullable<System.DateTime> FECHA_FIN { get; set; }
        public Nullable<decimal> ESTADO_ACTUAL { get; set; }
    
        public virtual ICollection<PARTIDO> PARTIDO { get; set; }
        public virtual ICollection<EQUIPO_COMPETENCIA> EQUIPO_COMPETENCIA { get; set; }
        public virtual ICollection<ESTADIO> ESTADIO { get; set; }
        public virtual ICollection<PAIS> PAIS { get; set; }
    }
}