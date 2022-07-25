using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Entidades;

namespace WinFormsApp1.AccecoDatos.interfaces
{
    internal interface ITelefonoDao
    {
        DataTable CargarCombo();
        DataTable CargarLista();
        bool GrabarTelefono(telefono oTelefono);
        bool EditarTelefono(telefono oTelefono);
        bool EliminarTelefono(int codigo);

        telefono TraerDatosTelefono(int pk);
    }
}
