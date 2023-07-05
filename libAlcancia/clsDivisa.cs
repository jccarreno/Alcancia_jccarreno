using System;
using System.Collections.Generic;
using System.Text;
using Servicios.Interfaces;

namespace appAlcancia.Dominio
{
    public class clsDivisa:iPatronIDO<int>,iNombrable,IComparable
    {
        #region Atributos
        #region Propios
        private int atrIDO;
        private string atrNombre;
        private List<int> atrDenominaciones;
        #endregion
        #region Asociativos
        private clsAlcancia atrAlcancia;
        private List<clsMoneda> atrMonedas;
        private List<clsBillete> atrBilletes;
        #endregion
        #endregion
        #region Operaciones
        #region Constructor
        public clsDivisa(int prmIDO, string prmNombre, List<int> prmDenominacion)
        {
            atrIDO = prmIDO;
            atrNombre = prmNombre;
            atrDenominaciones = prmDenominacion;
            atrMonedas = new List<clsMoneda>();
            atrBilletes = new List<clsBillete>();
        }
        #endregion
        #region Accesores
        public int darIDO()
        {
            return atrIDO;
        }
        public string darNombre()
        {
            return atrNombre;
        }
        public List<clsMoneda> darMonedas()
        {
            return atrMonedas;
        }
        public List<clsBillete> darBilletes()
        {
            return atrBilletes;
        }
        public List<int> darDenominaciones()
        {
            return atrDenominaciones;
        }
        public clsAlcancia darAlcancia()
        {
            return atrAlcancia;
        }
        #endregion
        #region Mutadores
        public bool ponerNombre(string prmValor)
        {
            atrNombre = prmValor;
            return true;
        }
        public bool ponerDenominaciones(List<int> prmColeccion)
        {
            atrDenominaciones = prmColeccion;
            return true;
        }
        public bool ponerAlcancia(clsAlcancia prmAlcancia)
        {
            atrAlcancia = prmAlcancia;
            return true;
        }
        #endregion
        #region Consultores
        public bool esValida(int prmDenominacion)
        {
            return atrDenominaciones.Contains(prmDenominacion);
        }
        #endregion
        #region Crud
        public bool modificar(string prmNombre, List<int> prmDenominaciones)
        {
            for(int i=0;i<atrMonedas.Count;i++)
            {
                if (!prmDenominaciones.Contains(atrMonedas[i].darDenominacion()))
                    return false;
            }
            for (int i = 0; i < atrBilletes.Count; i++)
            {
                if (!prmDenominaciones.Contains(atrBilletes[i].darDenominacion()))
                    return false;
            }
            atrNombre = prmNombre;
            atrDenominaciones = prmDenominaciones;
            return true;
        }
        #endregion
        #region Destructor
        public bool finalizar()
        {
            return (atrMonedas.Count == 0 && atrBilletes.Count == 0 && atrAlcancia == null);
        }
        #endregion
        #region Query
        public int CompareTo(object prmObjeto)
        {
            clsDivisa varObjDivisa = (clsDivisa)Convert.ChangeType(prmObjeto, typeof(clsDivisa));
            if (varObjDivisa==null)
                return -99;
            if (this.atrIDO == varObjDivisa.darIDO() && this.atrNombre==varObjDivisa.atrNombre && this.atrDenominaciones.Equals(varObjDivisa.atrDenominaciones))
                return 0;
            return -99;
        }
        public string toStringDivisas()
        {
            string varDivisas="";
            for (int i = 0; i < atrDenominaciones.Count; i++)
                varDivisas = varDivisas +"  "+ atrDenominaciones[i];
            return varDivisas;
        }
        #endregion
        #endregion
    }
}