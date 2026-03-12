namespace BansiExamen
{
    partial class FrmExamen
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            btnGuardar = new Button();
            btnConsultar = new Button();
            dataGridView1 = new DataGridView();
            chkWebApi = new CheckBox();
            txtId = new TextBox();
            btnEliminar = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 22);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 0;
            label1.Text = "Examen Bansi";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(110, 78);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(241, 78);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(125, 27);
            txtDescripcion.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(405, 76);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(527, 76);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(94, 29);
            btnConsultar.TabIndex = 4;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(36, 111);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Size = new Size(739, 314);
            dataGridView1.TabIndex = 5;
            dataGridView1.DefaultCellStyleChanged += FrmExamen_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // chkWebApi
            // 
            chkWebApi.AutoSize = true;
            chkWebApi.Location = new Point(645, 18);
            chkWebApi.Name = "chkWebApi";
            chkWebApi.Size = new Size(117, 24);
            chkWebApi.TabIndex = 6;
            chkWebApi.Text = "User web api";
            chkWebApi.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            txtId.Location = new Point(36, 78);
            txtId.Name = "txtId";
            txtId.Size = new Size(69, 27);
            txtId.TabIndex = 7;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(645, 76);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 52);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 9;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 55);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 10;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(241, 55);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 11;
            label4.Text = "Descripción";
            // 
            // FrmExamen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnEliminar);
            Controls.Add(txtId);
            Controls.Add(chkWebApi);
            Controls.Add(dataGridView1);
            Controls.Add(btnConsultar);
            Controls.Add(btnGuardar);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "FrmExamen";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Button btnGuardar;
        private Button btnConsultar;
        private DataGridView dataGridView1;
        private CheckBox chkWebApi;
        private TextBox txtId;
        private Button btnEliminar;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
