using System;
using System.Collections.Generic;
using Servicios.Interfaces;
using Servicios.Formato;

namespace appAlcancia.Dominio
{
    public class clsAhorrador:clsUsuario,iPatronIDO<string>
    {
        #region Atributos
        #region Propios
        #region PatronIDO
        private string atrPID; 
        #endregion
        private string atrNombreCompleto;

        #endregion
        #region Asociativos
        private List<clsMoneda> atrMonedas;
        private List<clsBillete> atrBilletes;

        #endregion
        #region Derivables
        private int atrSaldoTotal;
        private int atrSaldoMonedas;
        private int atrSaldoBilletes;
        #endregion
        #endregion
        #region Operaciones
        #region Constructor
        /// <summary>
        /// Constructor del objeto ahorrador 
        /// </summary>
        /// <param name="prmPID">Numero de identificación del ahorrador</param>
        /// <param name="prmNombreUsuario"></param>
        /// <param name="prmClave"></param>
        public clsAhorrador(string prmPID, string prmNombreUsuario, string prmNombreCompleto,string prmClave) : base(prmNombreUsuario, prmClave)
        {
            atrPID = prmPID;
            atrNombreCompleto = prmNombreCompleto;
            atrMonedas = new List<clsMoneda>();
            atrBilletes = new List<clsBillete>();
        }
        #endregion
        #region Accesores
        /// <summary>
        /// Método accesor que retorna el PID del ahorrador
        /// </summary>
        /// <returns>atrPID</returns>
        public string darIDO()
        {
            return atrPID;
        }
        /// <summary>
        /// Método accesor que retorna el saldo total del ahorrador
        /// </summary>
        /// <returns>atrSaldoTotal</returns>
        public int darSaldoTotal()
        {
            atrSaldoTotal = darSaldoMonedas() + darSaldoBilletes();
            return atrSaldoTotal;
        }
        /// <summary>
        /// Método accesor que retorna la suma de  
        /// </summary>
        /// <returns></returns>
        public int darSaldoMonedas()
        {
            int varSaldo = 0;
            for(int i=0;i<atrMonedas.Count;i++)
            {
                varSaldo = varSaldo + atrMonedas[i].darDenominacion();
            }
            atrSaldoMonedas = varSaldo;
            return atrSaldoMonedas;
        }
        public int darSaldoBilletes()
        {
            int varSaldo = 0;
            for (int i = 0; i < atrBilletes.Count; i++)
            {
                varSaldo = varSaldo + atrBilletes[i].darDenominacion();
            }
            atrSaldoBilletes = varSaldo;
            return atrSaldoBilletes;
        }
        public List<clsMoneda> darMonedas()
        {
            return atrMonedas;
        }
        public List<clsBillete> darBilletes()
        {
            return atrBilletes;
        }
        public string darNombreCompleto()
        {
            return atrNombreCompleto;
        }
        #endregion
        #region Mutadores
        public bool ponerMonedas(List<clsMoneda> prmColeccion)
        {
            atrMonedas = prmColeccion;
            return true;
        }
        public bool ponerBilletes(List<clsBillete> prmColeccion)
        {
            atrBilletes = prmColeccion;
            return true;
        }
        public bool ponerNombreCompleto(string prmNombreCompleto)
        {
            atrNombreCompleto = prmNombreCompleto;
            return true;
        }
        #endregion
        #region CRUDs
        public bool modificar(string prmNombreCompleto, string prmClave)
        {
            atrNombreCompleto = prmNombreCompleto;
            atrClave = prmClave;
            return true;
        }
        #endregion
        #region Destructor
        public bool finalizar()
        {
            bool varBandera = true;
            for(int i=0;i<atrMonedas.Count;i++)
            {
                if (atrMonedas[i].darAlcancia() != null)
                    varBandera = false;
            }
            for (int i = 0; i < atrBilletes.Count; i++)
            {
                if (atrBilletes[i].darAlcancia() != null)
                    varBandera = false;
            }
            return varBandera;
        }
        #endregion
        #region Consultores
        public override int CompareTo(object prmObjeto)
        {
            if (base.CompareTo(prmObjeto) == 0)
            {
                clsAhorrador varObjeto = clsFormateador.cambiarTipo<clsAhorrador>(prmObjeto);
                if (atrPID == varObjeto.atrPID && atrNombreCompleto == varObjeto.atrNombreCompleto
                    && atrMonedas.Equals(varObjeto.atrMonedas) && atrBilletes.Equals(varObjeto.atrBilletes) &&
                    atrSaldoTotal == varObjeto.atrSaldoTotal && atrSaldoMonedas == varObjeto.atrSaldoMonedas
                    && atrSaldoBilletes == varObjeto.atrSaldoBilletes)
                    return 0;
            }
            return -99;
        }
        #endregion
        #region Metodos Personalizados
        public int darConteoMonedasBolsillo()
        {
            int varConteo = 0;
            for (int i = 0; i < atrMonedas.Count; i++)
            {
                if (atrMonedas[i].darAlcancia() == null)
                    varConteo = varConteo + 1;
            }
            return varConteo;
        }
        public int darConteoBilletesBolsillo()
        {
            int varConteo = 0;
            for (int i = 0; i < atrBilletes.Count; i++)
            {
                if (atrBilletes[i].darAlcancia() == null)
                    varConteo = varConteo + 1;
            }
            return varConteo;
        }

        public int darSaldoTotalAlcancia()
        {
            int varSaldo = 0;
            for(int i=0;i<atrMonedas.Count;i++)
            {
                if (atrMonedas[i].darAlcancia() != null)
                    varSaldo = varSaldo + atrMonedas[i].darDenominacion();
            }
            for (int i = 0; i < atrBilletes.Count; i++)
            {
                if (atrBilletes[i].darAlcancia() != null)
                    varSaldo = varSaldo + atrBilletes[i].darDenominacion();
            }
            return varSaldo;
        }
        public int darSaldoMonedasAlcancia()
        {
            int varSaldo = 0;
            for (int i = 0; i < atrMonedas.Count; i++)
            {
                if (atrMonedas[i].darAlcancia() != null)
                    varSaldo = varSaldo + atrMonedas[i].darDenominacion();
            }
            return varSaldo;
        }
        public int darSaldoBilletesAlcancia()
        {
            int varSaldo = 0;
            for (int i = 0; i < atrBilletes.Count; i++)
            {
                if (atrBilletes[i].darAlcancia() != null)
                    varSaldo = varSaldo + atrBilletes[i].darDenominacion();
            }
            return varSaldo;
        }
        public int darConteoMonedasAlcancia()
        {
            int varSaldo = 0;
            for (int i = 0; i < atrMonedas.Count; i++)
            {
                if (atrMonedas[i].darAlcancia() != null)
                    varSaldo = varSaldo + 1;
            }
            return varSaldo;
        }
        public int darConteoBilletesAlcancia()
        {
            int varSaldo = 0;
            for (int i = 0; i < atrBilletes.Count; i++)
            {
                if (atrBilletes[i].darAlcancia() != null)
                    varSaldo = varSaldo + 1;
            }
            return varSaldo;
        }
        #endregion
    }

        #endregion
}
