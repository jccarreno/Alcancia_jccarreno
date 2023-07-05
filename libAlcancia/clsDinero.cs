using System;
using System.Collections.Generic;
using System.Text;
using Servicios.Interfaces;
using Servicios.Formato;

namespace appAlcancia.Dominio
{
    public class clsDinero
    {
        #region Atributos
        protected int atrDenominacion;
        #region Asociativos
        /// <summary>
        /// Atributo que representa el propietario del dinero
        /// </summary>
        protected clsAhorrador atrAhorrador;
        /// <summary>
        /// Atributo que representa si el dinero se está almacenando y el contenedor
        /// </summary>
        protected clsAlcancia atrAlcancia;
        /// <summary>
        /// Atributo que representa la divisa del dinero
        /// </summary>
        protected clsDivisa atrDivisa;
        #endregion
        #endregion
        #region Operaciones
        #region Constructor
        public clsDinero(int prmDenominacion, clsDivisa prmDivisa)
        {
            atrDenominacion = prmDenominacion;
            atrDivisa = prmDivisa;
        }
        #endregion
        #region Accesores
        public int darDenominacion()
        {
            return atrDenominacion;
        }

        public clsAlcancia darAlcancia()
        {
            return atrAlcancia;
        }

        public clsAhorrador darAhorrador()
        {
            return atrAhorrador;
        }
        public clsDivisa darDivisa()
        {
            return atrDivisa;
        }
        #endregion
        #region Mutadores
        public bool ponerDenominacion(int prmValor)
        {
            atrDenominacion = prmValor;
            return true;
        }
        public bool ponerAlcancia(clsAlcancia prmObjeto)
        {
            atrAlcancia = prmObjeto;
            return true;
        }
        public bool ponerAhorrador(clsAhorrador prmObjeto)
        {
            atrAhorrador = prmObjeto;
            return true;
        }
        #endregion
        public virtual int CompareTo(object prmObjeto)
        {
            clsDinero varObjeto = clsFormateador.cambiarTipo<clsDinero>(prmObjeto);
            if (varObjeto == null) return -99;
            if (atrDivisa == varObjeto.atrDivisa && atrDenominacion == varObjeto.atrDenominacion
                && atrAlcancia.CompareTo(varObjeto.atrAlcancia) == 0 && atrAhorrador.CompareTo(varObjeto.atrAhorrador) == 0)
                return 0;
            return -99;
        }
        #endregion
    }
}
