using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.AccecoDatos.interfaces;

namespace WinFormsApp1.AccecoDatos.Implentaciones
{
     class DaoFactory : AbstractDaoFactory
    {
        public override ITelefonoDao CrearTelefonoDao()
        {
            return new TelefonoDao();
        }
    }
}
