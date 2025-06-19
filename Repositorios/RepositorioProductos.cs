using Microsoft.Data.Sqlite;
namespace Productos.Repositorios
{
    internal class RepositorioProductos
    {
        private SqliteConnection conexion;

        public RepositorioProductos(SqliteConnection conexion)
        {
            this.conexion = conexion;
        }

        public List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
            using var comando = conexion.CreateCommand();
            comando.CommandText = @"
                SELECT id, nombre, descripcion, precio, cantidad, fecha_ingreso, disponible 
                FROM productos 
            ";
            using var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                long id = (long)(reader["id"]);
                string nombre = reader["nombre"]?.ToString() ?? string.Empty;
                string descripcion = reader["descripcion"]?.ToString() ?? string.Empty;
                double precio = double.Parse(reader["precio"].ToString());
                int cantidad = int.Parse(reader["cantidad"].ToString());
                string fechaStr = reader["fecha_ingreso"]?.ToString() ?? DateTime.Now.ToString("yyyy-MM-dd");
                DateTime fechaIngreso = DateTime.Parse(fechaStr);
                bool disponible = int.Parse(reader["disponible"].ToString()) == 1;
                productos.Add(new Producto(id, nombre, descripcion, precio, cantidad, fechaIngreso, disponible));

            }
            return productos;
        }

        public void Crear(Producto producto)
        {
            using var comando = conexion.CreateCommand();
            comando.CommandText = @"
                INSERT INTO productos (nombre, descripcion, precio, cantidad, fecha_ingreso, disponible)
                VALUES (@nombre, @descripcion, @precio, @cantidad, @fecha_ingreso, @disponible)
            ";
            comando.Parameters.AddWithValue("@nombre", producto.Nombre);
            comando.Parameters.AddWithValue("@descripcion", producto.Descripcion);
            comando.Parameters.AddWithValue("@precio", producto.Precio);
            comando.Parameters.AddWithValue("@cantidad", producto.Cantidad);
            comando.Parameters.AddWithValue("@fecha_ingreso", producto.FechaIngreso.ToString("yyyy-MM-dd"));
            comando.Parameters.AddWithValue("@disponible", producto.Disponible ? 1 : 0);

            comando.ExecuteNonQuery();
            using var cmdId = conexion.CreateCommand();

            cmdId.CommandText = "SELECT last_insert_rowid();";
            var result = cmdId.ExecuteScalar();
            producto.Id = int.Parse(result.ToString());
        }

        public bool Actualizar(Producto producto)
        {
            using var comando = conexion.CreateCommand();
            comando.CommandText = @"
                UPDATE productos SET
                    nombre = @nombre,
                    descripcion = @descripcion,
                    precio = @precio,
                    cantidad = @cantidad,
                    fecha_ingreso = @fecha_ingreso,
                    disponible = @disponible
                WHERE id = @id;
            ";

            comando.Parameters.AddWithValue("@nombre", producto.Nombre);
            comando.Parameters.AddWithValue("@descripcion", producto.Descripcion);
            comando.Parameters.AddWithValue("@precio", producto.Precio);
            comando.Parameters.AddWithValue("@cantidad", producto.Cantidad);
            comando.Parameters.AddWithValue("@fecha_ingreso", producto.FechaIngreso.ToString("yyyy-MM-dd"));
            comando.Parameters.AddWithValue("@disponible", producto.Disponible ? 1 : 0);
            comando.Parameters.AddWithValue("@id", producto.Id);
            return comando.ExecuteNonQuery() == 1;
        }

        public bool Eliminar(long id)
        {
            using var comando = conexion.CreateCommand();
            comando.CommandText = @"
                DELETE FROM productos 
                WHERE id = @id;
            ";
            comando.Parameters.AddWithValue("@id", id);
            return comando.ExecuteNonQuery() == 1;
        }
    }
}