using ApiExamen;

namespace BansiExamen
{
    public partial class FrmExamen : Form
    {

        private bool modoEdicion = false;

        public FrmExamen()
        {
            InitializeComponent();
        }

        private async void FrmExamen_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

            await CargarDatos();
        }

        private bool ValidarFormulario()
        {
            if (!int.TryParse(txtId.Text, out _))
            {
                MessageBox.Show("El Id debe ser numérico");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria");
                return false;
            }

            return true;
        }

        private TipoConexion ObtenerTipoConexion()
        {
            if (chkWebApi.Checked)
            {
                return TipoConexion.WebService;
            }
            else
            {
                return TipoConexion.StoredProcedure;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            var tipo = ObtenerTipoConexion();

            clsExamen examen = new clsExamen(tipo);

            int id = int.Parse(txtId.Text);

            if (!modoEdicion)
            {
                var resultado = await examen.AgregarExamen(
                    id,
                    txtNombre.Text,
                    txtDescripcion.Text
                );

                MessageBox.Show(resultado.Item2);
            }
            else
            {
                var resultado = await examen.ActualizarExamen(
                    id,
                    txtNombre.Text,
                    txtDescripcion.Text
                );

                MessageBox.Show(resultado.Item2);

                btnGuardar.Text = "Guardar";
                modoEdicion = false;
            }

            LimpiarFormulario();
            await CargarDatos();
        }

        // =========================
        // CONSULTAR
        // =========================

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            await CargarDatos();
        }

        private async Task CargarDatos()
        {
            var tipo = ObtenerTipoConexion();

            clsExamen examen = new clsExamen(tipo);

            dataGridView1.DataSource =
                await examen.ConsultarExamen();
        }

        // =========================
        // ELIMINAR
        // =========================

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Seleccione un registro");
                return;
            }

            var tipo = ObtenerTipoConexion();

            clsExamen examen = new clsExamen(tipo);

            int id = int.Parse(txtId.Text);

            bool eliminado = await examen.EliminarExamen(id);

            if (eliminado)
                MessageBox.Show("Registro eliminado");

            LimpiarFormulario();
            await CargarDatos();
        }

        // =========================
        // CLICK SIMPLE
        // =========================

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminar.Enabled = true;
        }

        // =========================
        // DOBLE CLICK PARA EDITAR
        // =========================

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text =
                dataGridView1.CurrentRow.Cells["idExamen"].Value.ToString();

            txtNombre.Text =
                dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();

            txtDescripcion.Text =
                dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();

            btnGuardar.Text = "Actualizar";
            modoEdicion = true;
        }

        // =========================
        // LIMPIAR FORMULARIO
        // =========================

        private void LimpiarFormulario()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();

            btnEliminar.Enabled = false;

            btnGuardar.Text = "Guardar";
            modoEdicion = false;
        }
    }
}
