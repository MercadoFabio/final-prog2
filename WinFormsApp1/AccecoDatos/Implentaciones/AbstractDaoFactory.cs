using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.AccecoDatos.interfaces;

namespace WinFormsApp1.AccecoDatos.Implentaciones
{
      abstract class AbstractDaoFactory
    {
        public abstract ITelefonoDao CrearTelefonoDao();
    }
}
