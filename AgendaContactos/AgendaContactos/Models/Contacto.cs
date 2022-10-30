using SQLite;

namespace AgendaContactos.Models
{
    public class Contacto
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Numero { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int IdUsuario { get; set; }
        public string Categoria { get; set; }
    }
}
