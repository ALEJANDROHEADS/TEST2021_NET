//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogicaFuncional.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Autores
    {
        public Autores()
        {
            this.Libros = new HashSet<Libros>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
    
        public virtual ICollection<Libros> Libros { get; set; }
    }
}
