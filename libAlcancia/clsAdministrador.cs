using System;
using System.Collections.Generic;
using System.Text;

namespace appAlcancia.Dominio
{
    public class clsAdministrador : clsUsuario
    {
        #region Operaciones
        #region Constructor
        public clsAdministrador(string prmClave) : base("Admin", prmClave)
        {}
        #endregion
        #endregion
    }
}
