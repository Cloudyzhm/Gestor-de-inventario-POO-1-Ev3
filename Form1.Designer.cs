namespace Productos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nombreLabel = new Label();
            descripcionLabel = new Label();
            precioLabel = new Label();
            cantidadLabel = new Label();
            fechaIngresoLabel = new Label();
            disponibleLabel = new Label();
            nombreTextBox = new TextBox();
            descripcionTextBox = new TextBox();
            precioTextBox = new TextBox();
            cantidadTextBox = new TextBox();
            fechaIngresoPicker = new DateTimePicker();
            disponibleCheckBox = new CheckBox();
            guardarButton = new Button();
            borrarButton = new Button();
            productosDataGridView = new DataGridView();
            filtroLabel = new Label();
            filtroTextBox = new TextBox();
            filtrarButton = new Button();
            actualizarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)productosDataGridView).BeginInit();
            SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(37, 20);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(51, 15);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new Point(37, 60);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(67, 15);
            descripcionLabel.TabIndex = 1;
            descripcionLabel.Text = "Descripción";
            // 
            // precioLabel
            // 
            precioLabel.AutoSize = true;
            precioLabel.Location = new Point(350, 20);
            precioLabel.Name = "precioLabel";
            precioLabel.Size = new Size(40, 15);
            precioLabel.TabIndex = 2;
            precioLabel.Text = "Precio";
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Location = new Point(350, 60);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new Size(55, 15);
            cantidadLabel.TabIndex = 3;
            cantidadLabel.Text = "Cantidad";
            // 
            // fechaIngresoLabel
            // 
            fechaIngresoLabel.AutoSize = true;
            fechaIngresoLabel.Location = new Point(37, 100);
            fechaIngresoLabel.Name = "fechaIngresoLabel";
            fechaIngresoLabel.Size = new Size(87, 15);
            fechaIngresoLabel.TabIndex = 4;
            fechaIngresoLabel.Text = "Fecha Ingreso";
            // 
            // disponibleLabel
            // 
            disponibleLabel.AutoSize = true;
            disponibleLabel.Location = new Point(350, 100);
            disponibleLabel.Name = "disponibleLabel";
            disponibleLabel.Size = new Size(62, 15);
            disponibleLabel.TabIndex = 5;
            disponibleLabel.Text = "Disponible";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(120, 17);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(200, 23);
            nombreTextBox.TabIndex = 6;
            // 
            // descripcionTextBox
            // 
            descripcionTextBox.Location = new Point(120, 57);
            descripcionTextBox.Name = "descripcionTextBox";
            descripcionTextBox.Size = new Size(200, 23);
            descripcionTextBox.TabIndex = 7;
            // 
            // precioTextBox
            // 
            precioTextBox.Location = new Point(420, 17);
            precioTextBox.Name = "precioTextBox";
            precioTextBox.Size = new Size(200, 23);
            precioTextBox.TabIndex = 8;
            // 
            // cantidadTextBox
            // 
            cantidadTextBox.Location = new Point(420, 57);
            cantidadTextBox.Name = "cantidadTextBox";
            cantidadTextBox.Size = new Size(200, 23);
            cantidadTextBox.TabIndex = 9;
            // 
            // fechaIngresoPicker
            // 
            fechaIngresoPicker.Location = new Point(120, 97);
            fechaIngresoPicker.Name = "fechaIngresoPicker";
            fechaIngresoPicker.Size = new Size(200, 23);
            fechaIngresoPicker.TabIndex = 10;
            // 
            // disponibleCheckBox
            // 
            disponibleCheckBox.Location = new Point(420, 97);
            disponibleCheckBox.Name = "disponibleCheckBox";
            disponibleCheckBox.Size = new Size(20, 20);
            disponibleCheckBox.TabIndex = 11;
            // 
            // guardarButton
            // 
            guardarButton.Location = new Point(120, 140);
            guardarButton.Name = "guardarButton";
            guardarButton.Size = new Size(75, 23);
            guardarButton.TabIndex = 12;
            guardarButton.Text = "Guardar";
            guardarButton.UseVisualStyleBackColor = true;
            guardarButton.Click += guardarButton_Click;
            // 
            // borrarButton
            // 
            borrarButton.Location = new Point(220, 140);
            borrarButton.Name = "borrarButton";
            borrarButton.Size = new Size(75, 23);
            borrarButton.TabIndex = 17;
            borrarButton.Text = "Borrar";
            borrarButton.UseVisualStyleBackColor = true;
            borrarButton.Click += borrarButton_Click;
            // 
            // productosDataGridView
            // 
            productosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productosDataGridView.Location = new Point(37, 220);
            productosDataGridView.Name = "productosDataGridView";
            productosDataGridView.Size = new Size(720, 250);
            productosDataGridView.TabIndex = 13;
            productosDataGridView.UserDeletingRow += productosDataGridView_UserDeletingRow;
            productosDataGridView.CellEndEdit += productosDataGridView_CellEndEdit;
            productosDataGridView.AutoGenerateColumns = true;
            // 
            // filtroLabel
            // 
            filtroLabel.AutoSize = true;
            filtroLabel.Location = new Point(37, 180);
            filtroLabel.Name = "filtroLabel";
            filtroLabel.Size = new Size(80, 15);
            filtroLabel.TabIndex = 14;
            filtroLabel.Text = "Buscar/Filtro";
            // 
            // filtroTextBox
            // 
            filtroTextBox.Location = new Point(120, 177);
            filtroTextBox.Name = "filtroTextBox";
            filtroTextBox.Size = new Size(300, 23);
            filtroTextBox.TabIndex = 15;
            // 
            // filtrarButton
            // 
            filtrarButton.Location = new Point(670, 17);
            filtrarButton.Name = "filtrarButton";
            filtrarButton.Size = new Size(75, 23);
            filtrarButton.TabIndex = 16;
            filtrarButton.Text = "Filtrar";
            filtrarButton.UseVisualStyleBackColor = true;
            filtrarButton.Visible = false;
            // 
            // actualizarButton
            // 
            actualizarButton.Location = new Point(670, 50);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(75, 23);
            actualizarButton.TabIndex = 18;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(nombreLabel);
            Controls.Add(descripcionLabel);
            Controls.Add(precioLabel);
            Controls.Add(cantidadLabel);
            Controls.Add(fechaIngresoLabel);
            Controls.Add(disponibleLabel);
            Controls.Add(nombreTextBox);
            Controls.Add(descripcionTextBox);
            Controls.Add(precioTextBox);
            Controls.Add(cantidadTextBox);
            Controls.Add(fechaIngresoPicker);
            Controls.Add(disponibleCheckBox);
            Controls.Add(guardarButton);
            Controls.Add(borrarButton);
            Controls.Add(productosDataGridView);
            Controls.Add(filtroLabel);
            Controls.Add(filtroTextBox);
            Controls.Add(filtrarButton);
            Controls.Add(actualizarButton);
            Name = "Form1";
            Text = "Inventario de Productos";
            ((System.ComponentModel.ISupportInitialize)productosDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nombreLabel;
        private Label descripcionLabel;
        private Label precioLabel;
        private Label cantidadLabel;
        private Label fechaIngresoLabel;
        private Label disponibleLabel;
        private TextBox nombreTextBox;
        private TextBox descripcionTextBox;
        private TextBox precioTextBox;
        private TextBox cantidadTextBox;
        private DateTimePicker fechaIngresoPicker;
        private CheckBox disponibleCheckBox;
        private Button guardarButton;
        private Button borrarButton;
        private DataGridView productosDataGridView;
        private Label filtroLabel;
        private TextBox filtroTextBox;
        private Button filtrarButton;
        private Button actualizarButton;
    }
}
