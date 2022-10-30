using SQLite;

namespace AgendaContactos.Models
{
    public class Categoria
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Detalle { get; set; }
    }
}
