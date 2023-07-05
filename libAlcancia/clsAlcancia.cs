using System;
using System.Collections.Generic;
using Servicios.Formato;

namespace appAlcancia.Dominio
{
    public class clsAlcancia:IComparable
    {
        #region Atributos
        #region Propios
        private int atrCapacidadMonedas;
        private int atrCapacidadBilletes;
        private List<int> atrDenominacionesBilletes;
        private List<int> atrDenominacionesMonedas;
        #endregion
        #region Derivados
        private int atrSaldoTotal;
        private int atrSaldoMonedas;
        private int atrSaldoBilletes;
        private List<int> atrSaldoMonedasPorDenominacion;
        private List<int> atrSaldoBilltesPorDenominacion;
        private int atrConteoMonedas;
        private int atrConteoBilletes;
        private List<int> atrConteoMonedasPorDenominacion;
        private List<int> atrConteoBilletesPorDenominacion;
        #endregion
        #region Asociativos
        private List<clsBillete> atrBilletes;
        private List<clsMoneda> atrMonedas;
        private clsDivisa atrDivisa;
        #endregion
        #endregion
        #region Operaciones
        #region Constructor
        public clsAlcancia(clsDivisa prmDivisa, int prmCapMonedas, int prmCapBilletes, List<int> prmDenMonedas, List<int> prmDenBilletes)
        {
            atrMonedas = new List<clsMoneda>();
            atrBilletes = new List<clsBillete>();

            atrDivisa = prmDivisa;
            atrCapacidadMonedas = prmCapMonedas;
            atrCapacidadBilletes = prmCapBilletes;

            atrDenominacionesMonedas = prmDenMonedas;
            if (prmDenMonedas == null)
                atrDenominacionesMonedas = new List<int>();
            atrConteoMonedasPorDenominacion =new List<int>(atrDenominacionesMonedas.Count);

            atrDenominacionesBilletes = prmDenBilletes;
            if (prmDenBilletes == null)
                atrDenominacionesBilletes = new List<int>();
            atrConteoBilletesPorDenominacion = new List<int>(atrDenominacionesBilletes.Count);

            atrBilletes = new List<clsBillete>();
            atrMonedas = new List<clsMoneda>();
        }
        #endregion
        #region Accesores
        public clsDivisa darDivisa()
        {
            return atrDivisa;
        }

        public int darCapacidadMonedas()
        {
            return atrCapacidadMonedas;
        }

        public int darCapacidadBilletes()
        {
            return atrCapacidadBilletes;
        }

        public List<int> darDenominacionesBilletes()
        {
            return atrDenominacionesBilletes;
        }

        public List<int> darDenominacionesMonedas()
        {
            return atrDenominacionesMonedas;
        }

        public int darSaldoTotal()
        {
            atrSaldoTotal = darSaldoBilletes() + darSaldoMonedas();
            return atrSaldoTotal;
        }

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

        public List<int> darSaldoMonedasPorDenominacion()
        {
            List<int> varConteo = new List<int>();
            for(int i=0;i<atrDenominacionesMonedas.Count;i++)
            {
                int varSaldo = 0;
                for(int j=0;j<atrMonedas.Count;j++)
                {
                    if (atrMonedas[j].darDenominacion() == atrDenominacionesMonedas[i])
                        varSaldo = varSaldo + atrMonedas[j].darDenominacion();
                }
                varConteo.Add(varSaldo);
            }
            atrSaldoMonedasPorDenominacion = varConteo;
            return atrSaldoMonedasPorDenominacion;
        }

        public List<int> darSaldoBilletesPorDenominacion()
        {
            List<int> varConteo = new List<int>();
            for (int i = 0; i < atrDenominacionesBilletes.Count; i++)
            {
                int varSaldo = 0;
                for (int j = 0; j < atrBilletes.Count; j++)
                {
                    if (atrBilletes[j].darDenominacion() == atrDenominacionesBilletes[i])
                        varSaldo = varSaldo + atrBilletes[j].darDenominacion();
                }
                varConteo.Add(varSaldo);
            }
            atrSaldoBilltesPorDenominacion = varConteo;
            return atrSaldoBilltesPorDenominacion;
        }

        public int darConteoMonedas()
        {
            atrConteoMonedas = atrMonedas.Count;
            return atrConteoMonedas;
        }

        public int darConteoBilletes()
        {
            atrConteoBilletes = atrBilletes.Count;
            return atrConteoBilletes;
        }

        public List<int> darConteoMonedasPorDenominacion()
        {
            List<int> varConteo = new List<int>();
            for (int i = 0; i < atrDenominacionesMonedas.Count; i++)
            {
                int varSaldo = 0;
                for (int j = 0; j < atrMonedas.Count; j++)
                {
                    if (atrMonedas[j].darDenominacion() == atrDenominacionesMonedas[i])
                        varSaldo = varSaldo + 1;
                }
                varConteo.Add(varSaldo);
            }
            atrConteoMonedasPorDenominacion = varConteo;
            return atrConteoMonedasPorDenominacion;
        }

        public List<int> darConteoBilletesPorDenominacion()
        {
            List<int> varConteo = new List<int>();
            for (int i = 0; i < atrDenominacionesBilletes.Count; i++)
            {
                int varSaldo = 0;
                for (int j = 0; j < atrBilletes.Count; j++)
                {
                    if (atrBilletes[j].darDenominacion() == atrDenominacionesBilletes[i])
                        varSaldo = varSaldo + 1;
                }
                varConteo.Add(varSaldo);
            }
            atrConteoBilletesPorDenominacion = varConteo;
            return atrConteoBilletesPorDenominacion;
        }

        public List<clsMoneda> darMonedas()
        {
            return atrMonedas;
        }

        public List<clsBillete> darBilletes()
        {
            return atrBilletes;
        }
        #endregion
        #region Mutadores
        public bool ponerDivisa(clsDivisa prmValor)
        {
            atrDivisa = prmValor;
            return true;
        }

        public bool ponerCapacidadMonedas(int prmValor)
        {
            atrCapacidadMonedas = prmValor;
            return true;
        }

        public bool ponerCapacidadBilletes(int prmValor)
        {
            atrCapacidadBilletes = prmValor;
            return true;
        }

        public bool ponerDenominacionesMonedas(List<int> prmColeccion)
        {
            atrDenominacionesMonedas = prmColeccion;
            return true;
        }

        public bool ponerDenominacionesBilletes(List<int> prmColeccion)
        {
            atrDenominacionesBilletes = prmColeccion;
            return true;
        }

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
        #endregion
        #region Consultores
        public bool estaVacia()
        {
            if (darConteoBilletes() == 0 && darConteoMonedas() == 0)
                return true;
            return false;
        }

        public bool comprobarDenMonedas(List<int> prmDenominaciones)
        {
            for(int i=0;i<prmDenominaciones.Count;i++)
            {
                if (!atrDivisa.darDenominaciones().Contains(prmDenominaciones[i]))
                    return false;
            }
            return true;
        }

        public bool comprobarDenBilletes(List<int> prmDenominaciones)
        {
            for (int i = 0; i < prmDenominaciones.Count; i++)
            {
                if (!atrDivisa.darDenominaciones().Contains(prmDenominaciones[i]))
                    return false;
            }
            return true;
        }
        #endregion
        #region Crud
        public bool modificar(clsDivisa prmDivisa, int prmCapMonedas, int prmCapBilletes, List<int> prmDenMonedas, List<int> prmDenBilletes)
        {
            if(prmDivisa.darIDO()!=atrDivisa.darIDO())
            {
                if (!estaVacia())
                    return false;
            }
            if (prmCapMonedas < atrMonedas.Count || prmCapBilletes < atrBilletes.Count)
                return false;
            bool varBandera = true;
            for (int i = 0; i < prmDenMonedas.Count; i++)
            {
                if (!atrDivisa.darDenominaciones().Contains(prmDenMonedas[i]))
                    varBandera = false;
            }
            for (int i = 0; i < prmDenBilletes.Count; i++)
            {
                if (!atrDivisa.darDenominaciones().Contains(prmDenBilletes[i]))
                    varBandera = false;
            }
            if (!varBandera)
                return false;

            atrDivisa = prmDivisa;
            atrCapacidadMonedas = prmCapMonedas;
            atrCapacidadBilletes = prmCapBilletes;
            atrDenominacionesMonedas = prmDenMonedas;
            atrDenominacionesBilletes = prmDenBilletes;
            return true;
        }
        #endregion
        #region Destructor
        public bool finalizar()
        {
            return estaVacia();
        }
        #endregion
        #region Query
        public int CompareTo(object prmObjeto)
        {
            if (prmObjeto == null)
                return 99;
            clsAlcancia varObjeto = clsFormateador.cambiarTipo<clsAlcancia>(prmObjeto);
            if (varObjeto != null)
            {
                if (atrDivisa.CompareTo(varObjeto) == 0 &&
                    atrCapacidadBilletes == varObjeto.atrCapacidadBilletes &&
                    atrCapacidadMonedas == varObjeto.atrCapacidadMonedas &&
                    atrMonedas.Equals(varObjeto.darMonedas()) &&
                    atrBilletes.Equals(varObjeto.darBilletes()) &&
                    atrDenominacionesMonedas.Equals(varObjeto.atrDenominacionesMonedas) &&
                    atrDenominacionesBilletes.Equals(varObjeto.atrDenominacionesBilletes))
                        return 0;
            }
            return -99;
        }
        #endregion
        #region prueba
        public void generar()
        {
            atrDivisa = new clsDivisa(0, "COP", new List<int> { 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000 });
            atrCapacidadMonedas = 10;
            atrCapacidadBilletes = 5;
            atrDenominacionesMonedas = new List<int> { 500 };
            atrDenominacionesBilletes = new List<int> { 2000,5000};


            atrMonedas.Add(new clsMoneda(0, 500,atrDivisa));
            atrMonedas[0].ponerAlcancia(this);
            atrDivisa.darMonedas().Add(atrMonedas[0]);
        }
        #endregion
        #region Metodos personalizados
        public bool comprobarDenMoneda(clsMoneda prmMoneda)
        {
            return (atrDenominacionesMonedas.Contains(prmMoneda.darDenominacion()));
        }
        public bool comprobarDenBillete(clsBillete prmBillete)
        {
            return (atrDenominacionesBilletes.Contains(prmBillete.darDenominacion()));
        }
        public bool hayEspacioMonedas()
        {
            return (darCapacidadMonedas() > darMonedas().Count);
        }
        public bool hayEspacioBilletes()
        {
            return (darCapacidadBilletes() > darBilletes().Count);
        }
        #endregion
        #endregion
    }
}
