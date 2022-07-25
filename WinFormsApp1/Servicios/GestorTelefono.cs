using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.AccecoDatos.Implentaciones;
using WinFormsApp1.AccecoDatos.interfaces;
using WinFormsApp1.Entidades;

namespace WinFormsApp1.Servicios
{
    internal class GestorTelefono
    {
        private ITelefonoDao dao;

        public GestorTelefono(AbstractDaoFactory factory)
        {
            dao = factory.CrearTelefonoDao();
        }
        public telefono TraerTelefonoUnico(int pk)
        {
            return dao.TraerDatosTelefono(pk);
        }
        public DataTable CargarComboMarca()
        {
            return dao.CargarCombo();
        }

        public DataTable CargarListaTelefonos()
        {
            return dao.CargarLista();   
        }

        internal bool GrabarTelefono(telefono oTelefono)
        {
            return dao.GrabarTelefono( oTelefono);
        }

        internal bool EditarTelefono(telefono oTelefono)
        {
            return dao.EditarTelefono(oTelefono);
        }

        internal bool EliminarTelefono(int codigo)
        {
            return dao.EliminarTelefono(codigo);
        }
    }
}
