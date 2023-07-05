using System;
using System.Collections.Generic;
using System.Text;
using Servicios.Interfaces;
using Servicios.Formato;

namespace appAlcancia.Dominio
{
    public class clsMoneda: clsDinero,iPatronIDO<int>,IComparable
    {
        private int atrIDO;
        #region Operaciones
        #region Constructores
        public clsMoneda(int prmIDO, int prmDenominacion, clsDivisa prmDivisa):base(prmDenominacion, prmDivisa)
        {
            atrIDO = prmIDO;
        }
        #endregion
        #region Accesores
        public int darIDO()
        {
            return atrIDO;
        }
        #endregion
        #region CRUDs
        public bool modificar(int prmDenominacion)
        {
            atrDenominacion = prmDenominacion;
            return true;
        }
        #endregion
        #region Destructor
        public bool finalizar()
        {
            if (atrAlcancia == null)
            {
                atrAhorrador.darMonedas().Remove(this);
                atrDivisa.darMonedas().Remove(this);
                return true;
            }
            return false;
        }
        #endregion
        #region Query
        public override int CompareTo(object prmObjeto)
        {
            if(base.CompareTo(prmObjeto)==0)
            {
                clsMoneda varObjeto = clsFormateador.cambiarTipo<clsMoneda>(prmObjeto);
                if (atrIDO == varObjeto.atrIDO)
                    return 0;
            }
            return -99;
        }
        #endregion

        #endregion
    }
}
