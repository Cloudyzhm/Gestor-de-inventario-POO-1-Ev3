namespace Productos
{
    internal class Producto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Disponible { get; set; }

        public Producto(string nombre, string descripcion, double precio, int cantidad, DateTime fechaIngreso, bool disponible)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Cantidad = cantidad;
            FechaIngreso = fechaIngreso;
            Disponible = disponible;
        }

        public Producto(long id, string nombre, string descripcion, double precio, int cantidad, DateTime fechaIngreso, bool disponible)
        : this(nombre, descripcion, precio, cantidad, fechaIngreso, disponible)
        {
            Id = id;
        }
    }
}
