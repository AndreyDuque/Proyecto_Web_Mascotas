//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class adoptante
    {
        public string id_adoptante { get; set; }
        public string nom_adoptante { get; set; }
        public string cel_adoptante { get; set; }
        public string dir_adoptante { get; set; }
        public Nullable<int> ingresos_mensuales { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}