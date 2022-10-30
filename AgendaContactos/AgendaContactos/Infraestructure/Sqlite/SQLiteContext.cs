using AgendaContactos.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContactos.Infraestructure.Sqlite
{
    public class SQLiteContext
    {
        public SQLiteAsyncConnection _database;

        public SQLiteContext(string connectionString)
        {
            _database = new SQLiteAsyncConnection(connectionString);

            _database.CreateTableAsync<Usuario>().Wait();
            _database.CreateTableAsync<Contacto>().Wait();
            _database.CreateTableAsync<Categoria>().Wait();
        }

        /*** USUARIO ***/
        public Task<Usuario> ObtenerUsuarioPorNombreContrasenaAsync(string nombre, string contrasena)
        {
            return _database.Table<Usuario>()
                .Where(x => x.Nombre == nombre && x.Contrasena == contrasena)
                .FirstOrDefaultAsync();
        }

        public bool ExisteNombreUsuarioAsync(string nombre)
        {
            return _database.Table<Usuario>()
                .Where(x => x.Nombre == nombre)
                .CountAsync().Result == 1 ? true : false;
        }

        public int NuevoIdUsuarioAsync()
        {
            var usuario = _database.Table<Usuario>().OrderByDescending(x => x.Id).FirstOrDefaultAsync().Result;
            if (usuario == null)
                return 1;
            else
                return usuario.Id + 1;
        }

        public Task<int> GuardarUsuarioAsync(Usuario usuario)
        {
            usuario.Id = NuevoIdUsuarioAsync();
            return _database.InsertAsync(usuario);
        }

        /*** CONTACTO ***/
        public async Task<List<Contacto>> ObtenerContactosDeUsuarioAsync(int idUsuario)
        {
            var contactos = await _database.Table<Contacto>()
                .Where(x => x.IdUsuario == idUsuario)
                .ToListAsync();
            return contactos;
        }

        public async Task<Contacto> ObtenerContactosPorIdAsync(int idContacto)
        {
            var contacto = await _database.Table<Contacto>()
                .Where(x => x.Id == idContacto)
                .FirstOrDefaultAsync();
            return contacto;
        }

        public int NuevoIdContactoAsync()
        {
            var contacto = _database.Table<Contacto>().OrderByDescending(x => x.Id).FirstOrDefaultAsync().Result;
            if (contacto == null)
                return 1;
            else
                return contacto.Id + 1;
        }

        public Task<int> GuardarContactoAsync(Contacto contacto)
        {
            contacto.Id = NuevoIdContactoAsync();
            return _database.InsertAsync(contacto);
        }

        public Task<int> ModificarContactoAsync(Contacto contacto)
        {
            return _database.UpdateAsync(contacto);
        }

        public Task<int> EliminarContactoAsync(Contacto contacto)
        {
            return _database.DeleteAsync(contacto);
        }

        /*** CATEGORIA ***/
        public async Task<List<Categoria>> ObtenerCategoriasAsync()
        {
            var categorias = await _database.Table<Categoria>().ToListAsync();
            if (categorias.Count == 0)
                CargarCategoriasAsync();
            return categorias;
        }

        public async void CargarCategoriasAsync()
        {
            var categoria = new Categoria()
            {
                Id = 1,
                Detalle = "Movil"
            };
            await _database.InsertAsync(categoria);

            categoria = new Categoria()
            {
                Id = 2,
                Detalle = "Casa"
            };
            await _database.InsertAsync(categoria);

            categoria = new Categoria()
            {
                Id = 3,
                Detalle = "Trabajo"
            };
            await _database.InsertAsync(categoria);

            categoria = new Categoria()
            {
                Id = 4,
                Detalle = "Empresa"
            };
            await _database.InsertAsync(categoria);
        }
    }
}
