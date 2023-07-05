using System;
using Servicios.Interfaces;
using Servicios.Formato;

namespace appAlcancia.Dominio
{
    /// <summary>
    /// @brief Clase padre que se encarga de la formar la plantilla de los diferentes tipos de usuarios.
    /// </summary>
    public class clsUsuario:iNombrable
    {
        #region Atributos
        #region Propios
        /// <summary>
        /// @brief Atributo protegido que hace referencia al nombre del usuario.
        /// </summary>
        protected string atrNombreUsuario;
        /// <summary>
        /// @brief Atributo protegido que hace referencia a la contraseña cifrada del usuario.
        /// </summary>
        protected string atrClave;
        #endregion
        #endregion
        #region Operaciones
        #region Constructores
        public clsUsuario(string prmNombreUsuario, string prmClave)
        {
            atrNombreUsuario = prmNombreUsuario;
            atrClave = prmClave;
        }
        #endregion
        #region Accesores
        public string darNombre()
        {
            return atrNombreUsuario;
        }
        public string darClave()
        {
            return atrClave;
        }
        #endregion
        #region Mutadores
        public bool modificar(string prmClave)
        {
            atrClave = prmClave;
            return true;
        }
        #endregion
        public virtual int CompareTo(object prmObjeto)
        {
            clsUsuario varObjeto = clsFormateador.cambiarTipo<clsUsuario>(prmObjeto);
            if (varObjeto == null) return -99;
            if (atrNombreUsuario == varObjeto.atrNombreUsuario && atrClave == varObjeto.atrClave)
                return 0;
            return -99;
        }
        #endregion
    }
}
