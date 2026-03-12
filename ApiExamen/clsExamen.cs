using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiExamen
{
    public class clsExamen
    {
        private string connectionString =
            "Server=localhost;Database=BdiExamen;Trusted_Connection=True";

        public TipoConexion TipoConexion { get; set; }

        public clsExamen(TipoConexion tipo)
        {
            TipoConexion = tipo;
        }

        // ===============================
        // AGREGAR EXAMEN
        // ===============================

        public async Task<(bool, string)> AgregarExamen(int id, string nombre, string descripcion)
        {
            if (id <= 0)
                return (false, "El Id debe ser mayor a 0");

            if (string.IsNullOrWhiteSpace(nombre))
                return (false, "El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(descripcion))
                return (false, "La descripción es obligatoria");

            if (TipoConexion == TipoConexion.StoredProcedure)
                return AgregarExamenSP(id, nombre, descripcion);

            return await AgregarExamenAPI(id, nombre, descripcion);
        }

        private (bool, string) AgregarExamenSP(int id, string nombre, string descripcion)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    using (SqlTransaction tx = cn.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand cmd =
                                new SqlCommand("spAgregar", cn, tx);

                            cmd.CommandType =
                                CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.Parameters.AddWithValue("@Nombre", nombre);
                            cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                            cmd.ExecuteNonQuery();

                            tx.Commit();

                            return (true, "Registro agregado correctamente");
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                            return (false, ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        private async Task<(bool, string)> AgregarExamenAPI(int id, string nombre, string descripcion)
        {
            using (HttpClient client = new HttpClient())
            {
                string url =
                    "https://localhost:7005/api/examen/agregar";

                var examen = new
                {
                    idExamen = id,
                    Nombre = nombre,
                    Descripcion = descripcion
                };

                var json =
                    JsonSerializer.Serialize(examen);

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");

                var response =
                    await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                    return (true, "Registro agregado correctamente");

                return (false,
                    await response.Content.ReadAsStringAsync());
            }
        }

        // ===============================
        // ACTUALIZAR
        // ===============================

        public async Task<(bool, string)> ActualizarExamen(int id, string nombre, string descripcion)
        {
            if (id <= 0)
                return (false, "Id inválido");

            if (TipoConexion == TipoConexion.StoredProcedure)
                return ActualizarExamenSP(id, nombre, descripcion);

            return await ActualizarExamenAPI(id, nombre, descripcion);
        }

        private (bool, string) ActualizarExamenSP(int id, string nombre, string descripcion)
        {
            try
            {
                using (SqlConnection cn =
                    new SqlConnection(connectionString))
                {
                    cn.Open();

                    SqlCommand cmd =
                        new SqlCommand("spActualizar", cn);

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                    cmd.ExecuteNonQuery();

                    return (true, "Registro actualizado correctamente");
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        private async Task<(bool, string)> ActualizarExamenAPI(int id, string nombre, string descripcion)
        {
            using (HttpClient client = new HttpClient())
            {
                string url =
                    "https://localhost:7005/api/examen/actualizar";

                var examen = new
                {
                    idExamen = id,
                    Nombre = nombre,
                    Descripcion = descripcion
                };

                var json =
                    JsonSerializer.Serialize(examen);

                var content =
                    new StringContent(json, Encoding.UTF8, "application/json");

                var response =
                    await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                    return (true, "Registro actualizado correctamente");

                return (false,
                    await response.Content.ReadAsStringAsync());
            }
        }

        // ===============================
        // ELIMINAR
        // ===============================

        public async Task<bool> EliminarExamen(int id)
        {
            if (id <= 0)
                return false;

            if (TipoConexion == TipoConexion.StoredProcedure)
                return EliminarExamenSP(id);

            return await EliminarExamenAPI(id);
        }

        private bool EliminarExamenSP(int id)
        {
            using (SqlConnection cn =
                new SqlConnection(connectionString))
            {
                cn.Open();

                SqlCommand cmd =
                    new SqlCommand("spEliminar", cn);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();

                return true;
            }
        }

        private async Task<bool> EliminarExamenAPI(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string url =
                    $"https://localhost:7005/api/examen/eliminar/{id}";

                var response =
                    await client.DeleteAsync(url);

                return response.IsSuccessStatusCode;
            }
        }

        // ===============================
        // CONSULTAR
        // ===============================

        public async Task<DataTable> ConsultarExamen()
        {
            if (TipoConexion == TipoConexion.StoredProcedure)
            {
                return ConsultarSP();
            }
            else
            {
                return await ConsultarAPI();
            }
        }

        private async Task<DataTable> ConsultarAPI()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idExamen");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripcion");

            using (HttpClient client = new HttpClient())
            {
                string url =
                "https://localhost:7005/api/examen/consultar";

                var response = await client.GetAsync(url);

                var json =
                await response.Content.ReadAsStringAsync();

                var lista =
                JsonSerializer.Deserialize<List<ExamenDTO>>(json);

                foreach (var item in lista)
                {
                    dt.Rows.Add(
                        item.idExamen,
                        item.Nombre,
                        item.Descripcion
                    );
                }
            }

            return dt;
        }

        private DataTable ConsultarSP()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn =
                new SqlConnection(connectionString))
            {
                cn.Open();

                SqlCommand cmd =
                    new SqlCommand("spConsultar", cn);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            return dt;
        }
    }
}