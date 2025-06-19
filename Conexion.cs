using Microsoft.Data.Sqlite;

namespace Productos
{
    internal class Conexion
    {
        private static SqliteConnection? conexion;

        private Conexion() { }
        public static SqliteConnection GetConexion()
        {
            if (conexion == null)
            {
                conexion = new SqliteConnection("Data Source=productos.db");
                conexion.Open();
                using var comandoCrearTabla = conexion.CreateCommand();
                comandoCrearTabla.CommandText = @"
                    CREATE TABLE IF NOT EXISTS productos(
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nombre TEXT NOT NULL,
                        descripcion TEXT,
                        precio REAL NOT NULL,
                        cantidad INTEGER NOT NULL,
                        fecha_ingreso TEXT NOT NULL,
                        disponible INTEGER NOT NULL
                    );
                ";
                comandoCrearTabla.ExecuteNonQuery();
            }

            return conexion;
        }
    }
}
