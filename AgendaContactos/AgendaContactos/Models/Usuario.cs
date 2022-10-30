using SQLite;
using System.Collections.Generic;

namespace AgendaContactos.Models
{
    public class Usuario
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public int Activo { get; set; }
        //public List<Contacto> Contactos { get; set; }
    }
}
