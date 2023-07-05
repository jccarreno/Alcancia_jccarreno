using System;
using System.Collections.Generic;
using System.Text;
using Servicios.Consulta;

namespace appAlcancia.Dominio
{
    public class clsSistema
    {
        #region Atributos
        #region Singleton
        private static clsSistema atrInstancia;
        #endregion
        #region Asociativos
        private clsAlcancia atrAlcancia;
        private List<clsMoneda> atrMonedas;
        private List<clsBillete> atrBilletes;
        private List<clsAhorrador> atrAhorradores;
        private clsAdministrador atrAdministrador;
        private List<clsDivisa> atrDivisas;
        #endregion
        #endregion
        #region Operaciones
        #region Singleton
        private clsSistema() 
        {
            atrDivisas = new List<clsDivisa>();
            atrMonedas = new List<clsMoneda>();
            atrBilletes = new List<clsBillete>();
            atrAhorradores = new List<clsAhorrador>();
        }
        public static clsSistema darInstancia()
        {
            if(atrInstancia==null)
                atrInstancia = new clsSistema();
            return atrInstancia;
        }
        #endregion
        #region Accesores
        public clsAlcancia darAlcancia()
        {
            return atrAlcancia;
        }

        public List<clsMoneda> darMonedas()
        {
            return atrMonedas;
        }

        public List<clsBillete> darBilletes()
        {
            return atrBilletes;
        }

        public List<clsAhorrador> darAhorradores()
        {
            return atrAhorradores;
        }

        public clsAdministrador darAdministrador()
        {
            return atrAdministrador;
        }

        public List<clsDivisa> darDivisas()
        {
            return atrDivisas;
        }
        #endregion
        #region Cruds
        #region CRUD-Registradores
        public bool registrarAlcancia(int prmIDODivisa,int prmCapMonedas, int prmCapBilletes, List<int> prmDenMonedas, List<int> prmDenBilletes)
        {
            if (atrAlcancia != null)
            {
                if (!atrAlcancia.estaVacia())
                    return false;
            }
            clsDivisa varObjDivisa = recuperarDivisaCon(prmIDODivisa);
            if (varObjDivisa != null)
            {
                bool varBandera = true;
                for(int i=0;i<prmDenMonedas.Count;i++)
                {
                    if (!varObjDivisa.darDenominaciones().Contains(prmDenMonedas[i]))
                        varBandera = false;
                }
                for (int i = 0; i < prmDenBilletes.Count; i++)
                {
                    if (!varObjDivisa.darDenominaciones().Contains(prmDenBilletes[i]))
                        varBandera = false;
                }
                if (!varBandera)
                    return false;
                atrAlcancia =new clsAlcancia(varObjDivisa, prmCapMonedas, prmCapBilletes, prmDenMonedas,prmDenBilletes);
                varObjDivisa.ponerAlcancia(atrAlcancia);
                return true;
            }
            return false;
        }

        public bool registrarMoneda(int prmDenominacion, int prmIDODivisa)
        {
            clsDivisa varObjDivisa = recuperarDivisaCon(prmIDODivisa);
            if(varObjDivisa != null && varObjDivisa.esValida(prmDenominacion))
            {
                clsMoneda varObjMoneda = new clsMoneda(generarIDOMoneda(), prmDenominacion, varObjDivisa);
                atrMonedas.Add(varObjMoneda);
                varObjDivisa.darMonedas().Add(varObjMoneda);
                return true;
            }
            return false;
        }
        public bool registrarMoneda(int prmDenominacion, int prmIDODivisa,string prmIDOAhorrador)
        {
            clsDivisa varObjDivisa = recuperarDivisaCon(prmIDODivisa);
            if (varObjDivisa != null && varObjDivisa.esValida(prmDenominacion))
            {
                clsMoneda varObjMoneda = new clsMoneda(generarIDOMoneda(), prmDenominacion, varObjDivisa);
                atrMonedas.Add(varObjMoneda);
                varObjDivisa.darMonedas().Add(varObjMoneda);
                recuperarAhorradorCon(prmIDOAhorrador).darMonedas().Add(varObjMoneda);
                varObjMoneda.ponerAhorrador(recuperarAhorradorCon(prmIDOAhorrador));
                return true;
            }
            return false;
        }

        public bool registrarBillete(string prmSerial, int prmDenominacion, int prmIDODivisa)
        {
            clsDivisa varObjDivisa = recuperarDivisaCon(prmIDODivisa);
            if (varObjDivisa != null && varObjDivisa.esValida(prmDenominacion) && !existeSerial(prmSerial))
            {
                clsBillete varObjBillete = new clsBillete(prmSerial, prmDenominacion, varObjDivisa);
                atrBilletes.Add(varObjBillete);
                varObjDivisa.darBilletes().Add(varObjBillete);
                return true;
            }
            return false;
        }

        public bool registrarBillete(string prmSerial, int prmDenominacion, int prmIDODivisa,string prmIDOAhorrador)
        {
            clsDivisa varObjDivisa = recuperarDivisaCon(prmIDODivisa);
            if (varObjDivisa != null && varObjDivisa.esValida(prmDenominacion) && !existeSerial(prmSerial))
            {
                clsBillete varObjBillete = new clsBillete(prmSerial, prmDenominacion, varObjDivisa);
                atrBilletes.Add(varObjBillete);
                varObjDivisa.darBilletes().Add(varObjBillete);
                recuperarAhorradorCon(prmIDOAhorrador).darBilletes().Add(varObjBillete);
                varObjBillete.ponerAhorrador(recuperarAhorradorCon(prmIDOAhorrador));
                return true;
            }
            return false;
        }

        public bool registrarAhorrador(string prmPID, string prmNombreUsuario, string prmNombreCompleto, string prmClave)
        {
            if (existePID(prmPID))
                return false;
            if(existeNombreUsuario(prmNombreUsuario))
                return false;
            atrAhorradores.Add(new clsAhorrador(prmPID, prmNombreUsuario, prmNombreCompleto, prmClave));
            return true;
        }
        public bool registrarAdministrador(string prmClave)
        {
            if (atrAdministrador != null)
                return false;
            atrAdministrador = new clsAdministrador(prmClave);
            return true;
        }
        public bool registrarDivisa(string prmNombre, List<int> prmDenominaciones)
        {
            if (existeNombreDivisa(prmNombre))
                return false;
            atrDivisas.Add(new clsDivisa(generarIDODivisa(), prmNombre, prmDenominaciones));
            return true;
        }
        #endregion
        #region CRUD-Editores
        public bool editarAlcancia(int prmIDODivisa, int prmCapMonedas, int prmCapBilletes, List<int> prmDenMonedas, List<int> prmDenBilletes)
        {
            clsDivisa varObjDivisa = recuperarDivisaCon(prmIDODivisa);
            if (atrAlcancia != null && varObjDivisa!=null)
                return atrAlcancia.modificar(varObjDivisa, prmCapMonedas, prmCapBilletes, prmDenMonedas, prmDenBilletes);
            return false;
        }

        public bool editarMoneda(int prmIDO, int prmDenominacion)
        {
            clsMoneda varObjMoneda = recuperarMonedaCon(prmIDO);
            if (varObjMoneda != null)
                return varObjMoneda.modificar(prmDenominacion);
            return false;
        }

        public bool editarBillete(string prmIDO, int prmDenominacion)
        {
            clsBillete varObjBillete = recuperarBilleteCon(prmIDO);
            if (varObjBillete != null)
                return varObjBillete.modificar(prmDenominacion);
            return false;
        }

        public bool editarAhorrador(string prmPID, string prmNombreCompleto, string prmClave)
        {
            clsAhorrador varObjAhorrador = recuperarAhorradorCon(prmPID);
            if (varObjAhorrador != null)
                return varObjAhorrador.modificar(prmNombreCompleto, prmClave);
            return false;
        }

        public bool editarAdministrador(string prmClave)
        {
            if (atrAdministrador != null)
                return atrAdministrador.modificar(prmClave);
            return false;
        }

        public bool editarDivisa(int prmIDO,string prmNombre, List<int> prmDenominaciones)
        {
            clsDivisa ObjDivisa = recuperarDivisaCon(prmIDO);
            if (ObjDivisa != null)
                return ObjDivisa.modificar(prmNombre, prmDenominaciones);
            return false;
        }
        #endregion
        #region CRUD-Eliminadores
        public bool eliminarAlcancia()
        {
            if (atrAlcancia == null)
                return false;
            if (atrAlcancia.finalizar())
            {
                atrAlcancia = null;
                return true;
            }
            return false;
        }

        public bool eliminarMoneda(int prmIDO)
        {
            clsMoneda varObjMoneda = recuperarMonedaCon(prmIDO);
            if (varObjMoneda == null)
                return false;
            if(varObjMoneda.finalizar())
            {
                atrMonedas.Remove(varObjMoneda);
                return true;
            }
            return false;
        }

        public bool eliminarBillete(string prmSerial)
        {
            clsBillete varObjBillete = recuperarBilleteCon(prmSerial);
            if (varObjBillete == null)
                return false;
            if (varObjBillete.finalizar())
            {
                atrBilletes.Remove(varObjBillete);
                return true;
            }
            return false;
        }

        public bool eliminarAhorrador(string prmPID)
        {
            clsAhorrador varObjAhorrador = recuperarAhorradorCon(prmPID);
            if (varObjAhorrador == null)
                return false;
            if(varObjAhorrador.finalizar())
            {
                for (int i = 0; i < varObjAhorrador.darMonedas().Count; i++)
                    atrMonedas.Remove(varObjAhorrador.darMonedas()[i]);
                for(int i = 0; i < varObjAhorrador.darBilletes().Count; i++)
                    atrBilletes.Remove(varObjAhorrador.darBilletes()[i]);
                atrAhorradores.Remove(varObjAhorrador);
                return true;
            }
            return false;
        }

        public bool elminarDivisa(int prmIDO)
        {
            clsDivisa varObjDivisa = recuperarDivisaCon(prmIDO);
            if (varObjDivisa == null)
                return false;
            if (!varObjDivisa.finalizar())
                return false;
            atrDivisas.Remove(varObjDivisa);
            return true;
        }
        #endregion
        #endregion
        #region Consultores
        private bool existeSerial(string prmValor)
        {
            return clsConsultor.existeIDOEn(atrBilletes, prmValor);
        }
        private bool existePID(string prmValor)
        {
            return clsConsultor.existeIDOEn(atrAhorradores, prmValor);
        }
        private bool existeIDODivisa(int prmValor)
        {
            return clsConsultor.existeIDOEn(atrDivisas, prmValor);
        }
        private bool existeNombreUsuario(string prmValor)
        {
            return clsConsultor.existeNombreEn(atrAhorradores, prmValor);
        }
        private bool existeNombreDivisa(string prmValor)
        {
            return clsConsultor.existeNombreEn(atrDivisas, prmValor);
        }
        #endregion
        #region Utilitarios
        private int generarIDOMoneda()
        {
            return clsConsultor.darNuevoIDO(atrMonedas);
        }
        public int generarIDODivisa()
        {
            return clsConsultor.darNuevoIDO(atrDivisas);
        }
        #endregion
        #region Recuperadores
        public clsMoneda recuperarMonedaCon(int prmIDO)
        {
            return clsConsultor.recuperarItemDe(atrMonedas, prmIDO);
        }
        public clsBillete recuperarBilleteCon(string prmSerial)
        {
            return clsConsultor.recuperarItemDe(atrBilletes, prmSerial);
        }

        public clsAhorrador recuperarAhorradorCon(string prmPID)
        {
            return clsConsultor.recuperarItemDe(atrAhorradores, prmPID);
        }

        public clsDivisa recuperarDivisaCon(int prmIDO)
        {
            return clsConsultor.recuperarItemDe(atrDivisas, prmIDO);
        }
        #endregion
        #region Metodo personalizado
        public bool ingresarMonedaAlcancia(int prmIDOMoneda)
        {
            if (atrAlcancia!=null)
            {
                clsMoneda varObjMoneda = recuperarMonedaCon(prmIDOMoneda);
                if(varObjMoneda!=null)
                {
                    if (atrAlcancia.comprobarDenMoneda(varObjMoneda))
                    {
                        if (varObjMoneda.darAlcancia() == null)
                        {
                            if (atrAlcancia.darCapacidadMonedas() > atrAlcancia.darMonedas().Count)
                            {
                                atrAlcancia.darMonedas().Add(varObjMoneda);
                                varObjMoneda.ponerAlcancia(atrAlcancia);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool ingresarBilleteAlcancia(string prmIDOBillete)
        {
            if (atrAlcancia != null)
            {
                clsBillete varObjBillete = recuperarBilleteCon(prmIDOBillete);
                if (varObjBillete != null)
                {
                    if (atrAlcancia.comprobarDenBillete(varObjBillete))
                    {
                        if (varObjBillete.darAlcancia() == null)
                        {
                            if (atrAlcancia.darCapacidadBilletes() > atrAlcancia.darBilletes().Count)
                            {
                                atrAlcancia.darBilletes().Add(varObjBillete);
                                varObjBillete.ponerAlcancia(atrAlcancia);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool sacarMonedaAlcancia(int prmIDOMoneda)
        {
            if (atrAlcancia != null)
            {
                clsMoneda varObjMoneda = recuperarMonedaCon(prmIDOMoneda);
                if (varObjMoneda != null)
                {
                    if (varObjMoneda.darAlcancia() != null)
                    {
                        atrAlcancia.darMonedas().Remove(varObjMoneda);
                        varObjMoneda.ponerAlcancia(null);
                        return true;
                    }
                }
            }
            return false;
        }
        public bool sacarBilleteAlcancia(string prmIDOBillete)
        {
            if (atrAlcancia != null)
            {
                clsBillete varObjBillete = recuperarBilleteCon(prmIDOBillete);
                if (varObjBillete != null)
                {
                    if (varObjBillete.darAlcancia() != null)
                    {
                        atrAlcancia.darBilletes().Remove(varObjBillete);
                        varObjBillete.ponerAlcancia(null);
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
        #endregion
        #region Pruebas
        public void generarSinAlcancia()
        {
            atrAdministrador = new clsAdministrador("clave123");

            atrDivisas.Add(new clsDivisa(0, "COP", new List<int> { 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000 }));
            atrDivisas.Add(new clsDivisa(1, "USD", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));
            atrDivisas.Add(new clsDivisa(2, "EUR", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));

            atrMonedas.Add(new clsMoneda(0, 500, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[0]);

            atrMonedas.Add(new clsMoneda(1, 1000, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[1]);

            atrBilletes.Add(new clsBillete("ABC123", 100, atrDivisas[1]));
            atrDivisas[1].darBilletes().Add(atrBilletes[0]);

            atrBilletes.Add(new clsBillete("QER789", 2000, atrDivisas[0]));
            atrDivisas[0].darBilletes().Add(atrBilletes[1]);

            atrAhorradores.Add(new clsAhorrador("0", "juanNN", "Juan Narvaez", "unaClave"));
            atrAhorradores[0].darMonedas().Add(atrMonedas[0]);
            atrMonedas[0].ponerAhorrador(atrAhorradores[0]);

            atrAhorradores[0].darBilletes().Add(atrBilletes[0]);
            atrBilletes[0].ponerAhorrador(atrAhorradores[0]);

            atrAhorradores.Add(new clsAhorrador("1", "aPolanco", "Any Polanco", "otraclave"));
            atrAhorradores[1].darMonedas().Add(atrMonedas[1]);
            atrMonedas[1].ponerAhorrador(atrAhorradores[1]);
        }
        public void generarConAlcanciaSinDinero()
        {
            atrAdministrador = new clsAdministrador("clave123");

            atrDivisas.Add(new clsDivisa(0, "COP", new List<int> { 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000 }));
            atrDivisas.Add(new clsDivisa(1, "USD", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));
            atrDivisas.Add(new clsDivisa(2, "EUR", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));

            atrMonedas.Add(new clsMoneda(0, 500, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[0]);

            atrMonedas.Add(new clsMoneda(1, 1000, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[1]);

            atrBilletes.Add(new clsBillete("ABC123", 100, atrDivisas[1]));
            atrDivisas[1].darBilletes().Add(atrBilletes[0]);

            atrBilletes.Add(new clsBillete("QER789", 2000, atrDivisas[0]));
            atrDivisas[0].darBilletes().Add(atrBilletes[1]);

            atrAhorradores.Add(new clsAhorrador("0", "juanNN", "Juan Narvaez", "unaClave"));
            atrAhorradores[0].darMonedas().Add(atrMonedas[0]);
            atrMonedas[0].ponerAhorrador(atrAhorradores[0]);

            atrAhorradores[0].darBilletes().Add(atrBilletes[0]);
            atrBilletes[0].ponerAhorrador(atrAhorradores[0]);

            atrAhorradores.Add(new clsAhorrador("1", "aPolanco", "Any Polanco", "otraclave"));
            atrAhorradores[1].darMonedas().Add(atrMonedas[1]);
            atrMonedas[1].ponerAhorrador(atrAhorradores[1]);

            atrAlcancia = new clsAlcancia(atrDivisas[0], 10, 5, new List<int> { 500 },new List<int> {2000,5000 });
        }
        public void generarConAlcanciaConDinero()
        {
            atrAdministrador = new clsAdministrador("clave123");

            atrDivisas.Add(new clsDivisa(0, "COP", new List<int> { 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000 }));
            atrDivisas.Add(new clsDivisa(1, "USD", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));
            atrDivisas.Add(new clsDivisa(2, "EUR", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));

            atrMonedas.Add(new clsMoneda(0, 500, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[0]);

            atrMonedas.Add(new clsMoneda(1, 1000, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[1]);

            atrBilletes.Add(new clsBillete("ABC123", 100, atrDivisas[1]));
            atrDivisas[1].darBilletes().Add(atrBilletes[0]);

            atrBilletes.Add(new clsBillete("QER789", 2000, atrDivisas[0]));
            atrDivisas[0].darBilletes().Add(atrBilletes[1]);

            atrAhorradores.Add(new clsAhorrador("0", "juanNN", "Juan Narvaez", "unaClave"));
            atrAhorradores[0].darMonedas().Add(atrMonedas[0]);
            atrMonedas[0].ponerAhorrador(atrAhorradores[0]);

            atrAhorradores[0].darBilletes().Add(atrBilletes[0]);
            atrBilletes[0].ponerAhorrador(atrAhorradores[0]);

            atrAhorradores.Add(new clsAhorrador("1", "aPolanco", "Any Polanco", "otraclave"));
            atrAhorradores[1].darMonedas().Add(atrMonedas[1]);
            atrMonedas[1].ponerAhorrador(atrAhorradores[1]);

            atrAlcancia = new clsAlcancia(atrDivisas[0], 10, 5, new List<int> { 500 }, new List<int> { 2000, 5000 });
            atrAlcancia.darMonedas().Add(atrMonedas[0]);
            atrMonedas[0].ponerAlcancia(atrAlcancia);
            //Mio
            atrAlcancia.darBilletes().Add(atrBilletes[0]);
            atrBilletes[0].ponerAlcancia(atrAlcancia);
        }
        public void generarAdministradorAlcanciaSinDinero()
        {
            atrAdministrador = new clsAdministrador("clave123");

            atrDivisas.Add(new clsDivisa(0, "COP", new List<int> { 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000 }));
            atrDivisas.Add(new clsDivisa(1, "USD", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));
            atrDivisas.Add(new clsDivisa(2, "EUR", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));

            atrMonedas.Add(new clsMoneda(0, 500, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[0]);

            atrMonedas.Add(new clsMoneda(1, 1000, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[1]);

            atrBilletes.Add(new clsBillete("ABC123", 100, atrDivisas[1]));
            atrDivisas[1].darBilletes().Add(atrBilletes[0]);

            atrBilletes.Add(new clsBillete("QER789", 2000, atrDivisas[0]));
            atrDivisas[0].darBilletes().Add(atrBilletes[1]);

            atrAhorradores.Add(new clsAhorrador("0", "juanNN", "Juan Narvaez", "clave123"));
            atrAhorradores[0].darMonedas().Add(atrMonedas[0]);
            atrMonedas[0].ponerAhorrador(atrAhorradores[0]);
            atrAhorradores[0].darBilletes().Add(atrBilletes[0]);
            atrBilletes[0].ponerAhorrador(atrAhorradores[0]);

            atrAhorradores.Add(new clsAhorrador("1", "aPolanco", "Any Polanco", "otraclave"));
            atrAhorradores[1].darMonedas().Add(atrMonedas[1]);
            atrMonedas[1].ponerAhorrador(atrAhorradores[1]);

            atrAlcancia = new clsAlcancia(atrDivisas[0], 10, 5, new List<int> { 500 }, new List<int> { 2000, 5000 });
        }
        public void generarAdministradorAlcanciaConDinero()
        {
            atrAdministrador = new clsAdministrador("clave123");

            atrDivisas.Add(new clsDivisa(0, "COP", new List<int> { 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000 }));
            atrDivisas.Add(new clsDivisa(1, "USD", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));
            atrDivisas.Add(new clsDivisa(2, "EUR", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));

            atrMonedas.Add(new clsMoneda(0, 500, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[0]);

            atrMonedas.Add(new clsMoneda(1, 1000, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[1]);

            atrBilletes.Add(new clsBillete("ABC123", 100, atrDivisas[1]));
            atrDivisas[1].darBilletes().Add(atrBilletes[0]);

            atrBilletes.Add(new clsBillete("QER789", 2000, atrDivisas[0]));
            atrDivisas[0].darBilletes().Add(atrBilletes[1]);

            atrAhorradores.Add(new clsAhorrador("0", "juanNN", "Juan Narvaez", "clave123"));
            atrAhorradores[0].darMonedas().Add(atrMonedas[0]);
            atrMonedas[0].ponerAhorrador(atrAhorradores[0]);
            atrAhorradores[0].darBilletes().Add(atrBilletes[0]);
            atrBilletes[0].ponerAhorrador(atrAhorradores[0]);

            atrAhorradores.Add(new clsAhorrador("1", "aPolanco", "Any Polanco", "otraclave"));
            atrAhorradores[1].darMonedas().Add(atrMonedas[1]);
            atrMonedas[1].ponerAhorrador(atrAhorradores[1]);

            atrAlcancia = new clsAlcancia(atrDivisas[0], 10, 5, new List<int> { 500 }, new List<int> { 2000, 5000 });
            atrAlcancia.darMonedas().Add(atrMonedas[0]);
            atrMonedas[0].ponerAlcancia(atrAlcancia);
        }
        public void generarDivisasDineroAhorradoresSinAlcancia()
        {
            atrAdministrador = new clsAdministrador("clave123");

            atrDivisas.Add(new clsDivisa(0, "COP", new List<int> { 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000 }));
            atrDivisas.Add(new clsDivisa(1, "USD", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));
            atrDivisas.Add(new clsDivisa(2, "EUR", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));

            atrMonedas.Add(new clsMoneda(0, 500, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[0]);

            atrMonedas.Add(new clsMoneda(1, 1000, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[1]);

            atrBilletes.Add(new clsBillete("ABC123", 100, atrDivisas[1]));
            atrDivisas[1].darBilletes().Add(atrBilletes[0]);

            atrBilletes.Add(new clsBillete("QER789", 1000, atrDivisas[0]));
            atrDivisas[0].darBilletes().Add(atrBilletes[1]);

            atrAhorradores.Add(new clsAhorrador("0", "juanN", "Juan Narvaez", "unaClave"));
            atrAhorradores[0].darMonedas().Add(atrMonedas[0]);
            atrMonedas[0].ponerAhorrador(atrAhorradores[0]);

            atrAhorradores[0].darBilletes().Add(atrBilletes[0]);
            atrBilletes[0].ponerAhorrador(atrAhorradores[0]);

            atrAhorradores.Add(new clsAhorrador("1", "aPolanco", "Any Polanco", "otraclave"));
            atrAhorradores[1].darMonedas().Add(atrMonedas[1]);
            atrMonedas[1].ponerAhorrador(atrAhorradores[1]);
        }
        public void generarDivisas()
        {
            atrDivisas.Add(new clsDivisa(0, "COP", new List<int> { 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000 }));
            atrDivisas.Add(new clsDivisa(1, "USD", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));
            atrDivisas.Add(new clsDivisa(2, "EUR", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 }));
            atrMonedas.Add(new clsMoneda(1, 1000, atrDivisas[0]));
            atrDivisas[0].darMonedas().Add(atrMonedas[1]);
        }
        #endregion
    }
}
