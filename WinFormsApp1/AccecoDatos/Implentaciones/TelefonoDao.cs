using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.AccecoDatos.interfaces;
using WinFormsApp1.Entidades;

namespace WinFormsApp1.AccecoDatos.Implentaciones
{
    internal class TelefonoDao : ITelefonoDao
    {
        public DataTable CargarCombo()
        {
            DataTable tabla = new DataTable();

            string query =  "Select * From Marcas";

            tabla = HelperDao.ObtenerInstancia().ConsultarSql(query);

            return tabla;
        }
        public DataTable CargarLista()
        {
            DataTable tabla = new DataTable();

            string query = "Select distinct Convert(varchar,t.codigo) + ' - ' + t.nombre +' - '  + '$'+ Convert(varchar,t.precio)  'Lista' From telefonos t order by 1";

            tabla = HelperDao.ObtenerInstancia().ConsultarSql(query);

            return tabla;
        }

        public bool EditarTelefono(telefono oTelefono)
        {
            int filasAfectadas = 0;
            bool resultado = true;
            string query = "update telefonos set codigo = @codigo, nombre = @nombre,marca = @marca,precio = @precio where codigo = @codigo";
            filasAfectadas = HelperDao.ObtenerInstancia().EditarTelefono(query, oTelefono);
            if (filasAfectadas == 0) resultado = false;
            return resultado;
        }

        public bool EliminarTelefono(int codigo)
        {
            int filasAfectadas = 0;
            bool resultado = true;
            string query = "delete telefonos where codigo = @codigo";
            filasAfectadas = HelperDao.ObtenerInstancia().EliminarTelefono(query,codigo);
            if (filasAfectadas == 0) resultado = false;
            return resultado;
            
        }

        public bool GrabarTelefono(telefono oTelefono)
        {
            int filasAfectadas = 0;
            bool resultado = true;
            string query = "insert into telefonos values (@codigo,@nombre,@marca,@precio)";
            filasAfectadas = HelperDao.ObtenerInstancia().GrabarNuevoTelefono(query, oTelefono);
            if (filasAfectadas == 0) resultado = false;
            return resultado;
        }

        public telefono TraerDatosTelefono(int pk)
        {
            telefono oTelefono = new telefono();
            DataTable table = new DataTable();

            string query = "SELECT * FROM Telefonos WHERE codigo =" + pk;

            table = HelperDao.ObtenerInstancia().ConsultarSql(query);

            bool primerRegistro = true;

            DataTableReader reader = table.CreateDataReader();

            while (reader.Read())
            {
                if (primerRegistro)
                {
                    oTelefono.codigo = Convert.ToInt32(reader["codigo"].ToString());
                    oTelefono.nombre = reader["nombre"].ToString();
                    oTelefono.marca = Convert.ToInt32(reader["marca"].ToString());
                    oTelefono.precio = Convert.ToDouble(reader["precio"].ToString());

                }

                primerRegistro = false;


            }

            return oTelefono;
        }
    }
}
    

