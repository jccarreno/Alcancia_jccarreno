using System;
using Servicios.Interfaces;
using Servicios.Formato;

namespace appAlcancia.Dominio
{
    public class clsBillete:clsDinero,iPatronIDO<string>
    {
        #region Atributos
        #region Propios
        private string atrSerial;
        #endregion
        #endregion
        #region Operaciones
        #region Contructores
        public clsBillete(string prmSerial, int prmDenominacion, clsDivisa prmDivisa): base(prmDenominacion, prmDivisa)
        {
            atrSerial = prmSerial;
        }
        #endregion
        #region Accesores
        public string darIDO()
        {
            return atrSerial;
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
                atrAhorrador.darBilletes().Remove(this);
                atrDivisa.darBilletes().Remove(this);
                return true;
            }
            return false;
        }
        #endregion
        public override int CompareTo(object prmObjeto)
        {
            if(base.CompareTo(prmObjeto)==0)
            {
                clsBillete varObjeto = clsFormateador.cambiarTipo<clsBillete>(prmObjeto);
                if (atrSerial == varObjeto.atrSerial)
                    return 0;
            }
            return -99;
        }
        #endregion
    }
}
