using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Entidades;

namespace WinFormsApp1.AccecoDatos
{
    class HelperDao
    {
        private static HelperDao instancia;
        private string cadenaConexion;
        SqlConnection cnn;
        SqlCommand cmd;
        private HelperDao()
        {
            cadenaConexion = Properties.Resources.strConexion;
            cnn = new SqlConnection(cadenaConexion);
            cmd = new SqlCommand();
        }



        public static HelperDao ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperDao();
            }
            return instancia;
        }
        public DataTable ConsultarSql(string query)
        {

            DataTable tabla = new DataTable();
            try
            {
                cmd.Parameters.Clear();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                tabla.Load(cmd.ExecuteReader());
                return tabla;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();

            }

        }

        internal int EditarTelefono(string query, telefono oTelefono)
        {
            int filasAfectadas = 0;
            try
            {
                cmd.Parameters.Clear();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@codigo", oTelefono.codigo);
                cmd.Parameters.AddWithValue("@nombre", oTelefono.nombre);
                cmd.Parameters.AddWithValue("@marca", oTelefono.marca);
                cmd.Parameters.AddWithValue("@precio", oTelefono.precio);

                filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                filasAfectadas = 0;

            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }

            return filasAfectadas;
        }

        internal int EliminarTelefono(string query, int  codigo)
        {
            int filasAfectadas = 0;
            try
            {
                cmd.Parameters.Clear();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@codigo", codigo);

                filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                filasAfectadas = 0;

            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }

            return filasAfectadas;
        

    }

    public int GrabarNuevoTelefono(string query,telefono oTelefono)
        {
            int filasAfectadas = 0;
            try
            {
                cmd.Parameters.Clear();
                cnn.Open();
                cmd.Connection= cnn;
                cmd.CommandText = query;
                cmd.CommandType= CommandType.Text;

                cmd.Parameters.AddWithValue("@codigo", oTelefono.codigo);
                cmd.Parameters.AddWithValue("@nombre", oTelefono.nombre);
                cmd.Parameters.AddWithValue("@marca", oTelefono.marca);
                cmd.Parameters.AddWithValue("@precio", oTelefono.precio);

                filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                filasAfectadas = 0;

            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }

            return filasAfectadas;
        }

    }
}
