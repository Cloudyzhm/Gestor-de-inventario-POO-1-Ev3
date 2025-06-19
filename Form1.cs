using System.ComponentModel;
using Productos.Repositorios;

namespace Productos
{
    public partial class Form1 : Form
    {
        private RepositorioProductos repositorioProductos;
        private BindingList<Producto> productos;
        public Form1()
        {
            InitializeComponent();
            repositorioProductos = new RepositorioProductos(Conexion.GetConexion());
            productos = new BindingList<Producto>(repositorioProductos.GetProductos());
            productosDataGridView.DataSource = productos;
            productosDataGridView.Columns["Id"].ReadOnly = true;
            productosDataGridView.CellValidating += productosDataGridView_CellValidating;
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = nombreTextBox.Text.Trim();
                string descripcion = descripcionTextBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!double.TryParse(precioTextBox.Text, out double precio) || precio < 0)
                {
                    MessageBox.Show("Precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(cantidadTextBox.Text, out int cantidad) || cantidad < 0)
                {
                    MessageBox.Show("Cantidad inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DateTime fechaIngreso = fechaIngresoPicker.Value.Date;
                bool disponible = disponibleCheckBox.Checked;

                var producto = new Producto(nombre, descripcion, precio, cantidad, fechaIngreso, disponible);
                repositorioProductos.Crear(producto);
                productos.Add(producto);

                nombreTextBox.Clear();
                descripcionTextBox.Clear();
                precioTextBox.Clear();
                cantidadTextBox.Clear();
                disponibleCheckBox.Checked = false;
                fechaIngresoPicker.Value = DateTime.Now;
                nombreTextBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void productosDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (e.Row?.DataBoundItem is Producto producto)
                {
                    // Validación previa a la eliminación
                    var confirm = MessageBox.Show($"¿Está seguro de eliminar el producto '{producto.Nombre}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm != DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                    repositorioProductos.Eliminar(producto.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void productosDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                var columnName = productosDataGridView.Columns[e.ColumnIndex].Name;
                var value = e.FormattedValue?.ToString() ?? string.Empty;
                if (columnName == "Nombre" && string.IsNullOrWhiteSpace(value))
                {
                    MessageBox.Show("El nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                if (columnName == "Precio" && (!double.TryParse(value, out double precio) || precio < 0))
                {
                    MessageBox.Show("Precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                if (columnName == "Cantidad" && (!int.TryParse(value, out int cantidad) || cantidad < 0))
                {
                    MessageBox.Show("Cantidad inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de validación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void productosDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (productosDataGridView.Rows[e.RowIndex].DataBoundItem is Producto producto)
            {
                if (string.IsNullOrWhiteSpace(producto.Nombre))
                {
                    MessageBox.Show("El nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (producto.Precio < 0)
                {
                    MessageBox.Show("Precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (producto.Cantidad < 0)
                {
                    MessageBox.Show("Cantidad inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                repositorioProductos.Actualizar(producto);
            }
            
        }

        private void filtroTextBox_TextChanged(object sender, EventArgs e)
        {
            string filtro = filtroTextBox.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(filtro))
            {
                productosDataGridView.DataSource = productos;
                return;
            }
            var filtrados = new BindingList<Producto>(productos.Where(p =>
                p.Nombre.ToLower().Contains(filtro) ||
                p.Descripcion.ToLower().Contains(filtro)
            ).ToList());
            productosDataGridView.DataSource = filtrados;
        }

        private void borrarButton_Click(object sender, EventArgs e)
        {
            if (productosDataGridView.CurrentRow?.DataBoundItem is Producto producto)
            {
                var confirm = MessageBox.Show($"¿Seguro que deseas borrar el producto '{producto.Nombre}'?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    repositorioProductos.Eliminar(producto.Id);
                    productos.Remove(producto);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para borrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void actualizarButton_Click(object sender, EventArgs e)
        {
            try
            {
                productos = new BindingList<Producto>(repositorioProductos.GetProductos());
                productosDataGridView.DataSource = productos;
                productosDataGridView.Columns["Id"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
