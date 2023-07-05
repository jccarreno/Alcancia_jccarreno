using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using appAlcancia.Dominio;
using System.Collections.Generic;

namespace uTestAlcancia
{
    [TestClass]
    public class uTestSistema
    {
        clsSistema atrTestSistema;
        clsMoneda atrTestMoneda;
        clsAlcancia atrTestAlcancia;
        clsBillete atrTestBillete;
        clsDivisa atrTestDivisa;
        clsAdministrador atrTestAdministrador;

        [TestMethod]
        public void testDarInstancia()
        {
            #region Configurar
            atrTestSistema = clsSistema.darInstancia();
            #endregion
            #region Prueba y Comprobacion
            Assert.IsNotNull(atrTestSistema);
            Assert.AreEqual(atrTestSistema.GetType(), typeof(clsSistema));
            #endregion
        }

        #region Test Registradores
        [TestMethod]
        public void testRegistrarAlanciaEnSistemaSinAlcancia()
        {
            #region Configurar
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarSinAlcancia();
            atrTestAlcancia = new clsAlcancia(atrTestSistema.darDivisas()[1], 20, 10, new List<int> { 500, 1000 }, null);
            #endregion
            #region Prueba y Comprobacion
            Assert.IsTrue(atrTestSistema.registrarAlcancia(1, 20, 10, new List<int> { 500, 1000 }, null));
            Assert.AreEqual(0, atrTestAlcancia.CompareTo(atrTestSistema.darAlcancia()));
            #endregion
        }

        [TestMethod]
        public void testRegistrarAlanciaEnSistemaConAlcanciaSinDinero()
        {
            #region Configurar
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarConAlcanciaSinDinero();
            atrTestAlcancia = new clsAlcancia(atrTestSistema.darDivisas()[1], 20, 10, new List<int> { 500,1000 }, null);
            #endregion
            #region Prueba y Comprobacion
            Assert.IsTrue(atrTestSistema.registrarAlcancia(1, 20, 10, new List<int> { 500, 1000 }, null));
            Assert.AreEqual(0, atrTestAlcancia.CompareTo(atrTestSistema.darAlcancia()));
            #endregion
        }
        [TestMethod]
        public void testRegistrarAlanciaEnSistemaConAlcanciaConDinero()
        {
            #region Configurar
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarConAlcanciaConDinero();
            atrTestAlcancia = new clsAlcancia(atrTestSistema.darDivisas()[0], 10, 5, new List<int> { 500 }, new List<int> { 2000, 5000 });
            #endregion
            #region Prueba y Comprobacion
            Assert.IsFalse(atrTestSistema.registrarAlcancia(1, 20, 10, new List<int> { 500, 1000 }, null));
            Assert.AreEqual(0, atrTestSistema.darAlcancia().CompareTo(atrTestAlcancia));
            #endregion
        }

        [TestMethod]
        public void testRegistrarPrimeraOcurrenciaBilleteConDenominacionValida()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarDivisas();
            atrTestBillete = new clsBillete("ABC123", 1000, atrTestSistema.darDivisas()[0]);
            Assert.IsTrue(atrTestSistema.registrarBillete("ABC123", 1000, 0));
            Assert.AreEqual(0, atrTestBillete.CompareTo(atrTestSistema.darBilletes()[0]));
        }
        [TestMethod]
        public void testRegistrarPrimeraOcurrenciaBilleteConDenominacionNoValida()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarDivisas();
            atrTestBillete = new clsBillete("ABC123", 2000, atrTestSistema.darDivisas()[2]);
            Assert.IsFalse(atrTestSistema.registrarBillete("ABC123", 2000, 2));
            Assert.AreEqual(0, atrTestSistema.darBilletes().Count);
        }

        [TestMethod]
        public void testRegistrarPrimeraOcurrenciaMonedaConDenominacionValida()
        {
            #region Configurar
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarDivisas();
            #endregion
            atrTestMoneda = new clsMoneda(0, 1000, atrTestSistema.darDivisas()[0]);
            Assert.IsTrue(atrTestSistema.registrarMoneda(100, 0));
            Assert.AreEqual(0, atrTestMoneda.CompareTo(atrTestSistema.darMonedas()[0]));

        }
        [TestMethod]
        public void testRegistrarPrimeraOcurrenciaMonedaConDenominacionNoValida()
        {
            #region Configurar
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarDivisas();
            #endregion
            atrTestMoneda = new clsMoneda(0, 2000, atrTestSistema.darDivisas()[2]);
            Assert.IsFalse(atrTestSistema.registrarMoneda(2000, 2));
            Assert.AreEqual(0, atrTestSistema.darMonedas().Count);

        }

        [TestMethod]
        public void testRegistrarSegundaOcurrenciaBilleteConDenominacionNoValida()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarSinAlcancia();
            clsBillete atrTestBillete = new clsBillete("ABC123", 100, atrTestSistema.darDivisas()[1]);
            Assert.IsFalse(atrTestSistema.registrarBillete("ABC123", 100, 1));
            Assert.AreEqual(0, atrTestBillete.CompareTo(atrTestSistema.darBilletes()[0]));
            Assert.AreEqual(2, atrTestSistema.darBilletes().Count);
        }
        [TestMethod]
        public void testRegistrarPrimeraOcurrenciaAhorrador()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarDivisasDineroAhorradoresSinAlcancia();
            clsAhorrador atrTestAhorrador = new clsAhorrador("12567899", "jjmoreno", "George Brown", "key123");
            Assert.IsTrue(atrTestSistema.registrarAhorrador("12567899", "jjmoreno", "George Brown", "key123"));
            Assert.AreEqual(0, atrTestAhorrador.CompareTo(atrTestSistema.darAhorradores()[0]));
        }
        [TestMethod]
        public void testRegistrarPrimeraOcurrenciaAdministrador()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestAdministrador = new clsAdministrador("unaClave");
            Assert.IsTrue(atrTestSistema.registrarAdministrador("unaClave"));
            Assert.AreEqual(0, atrTestAdministrador.CompareTo(atrTestSistema.darAdministrador()));
        }
        [TestMethod]
        public void testRegistrarSegundaOcurrenciaAdministrador()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarConAlcanciaSinDinero();
            atrTestAdministrador = new clsAdministrador("clave123");
            Assert.IsFalse(atrTestSistema.registrarAdministrador("unaClave"));
            Assert.AreEqual(0, atrTestAdministrador.CompareTo(atrTestSistema.darAdministrador()));
        }
        [TestMethod]
        public void testRegistrarPrimeraOcurrenciaDivisa()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestDivisa = new clsDivisa(0, "COP", new List<int> { 100, 200, 500 });
            Assert.IsTrue(atrTestSistema.registrarDivisa("COP", new List<int> { 100, 200, 500 }));
            Assert.AreEqual(0, atrTestDivisa.CompareTo(atrTestSistema.darDivisas()[0]));
        }
        [TestMethod]
        public void testRegistrarSegundaOcurrenciaDivisa()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarDivisas();
            atrTestDivisa = new clsDivisa(0, "COP", new List<int> { 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000 });
            Assert.IsFalse(atrTestSistema.registrarDivisa("COP", new List<int> { 100, 200, 500 }));
            Assert.AreEqual(0, atrTestDivisa.CompareTo(atrTestSistema.darDivisas()[0]));
        }

        #endregion

        #region Test editores
        [TestMethod]
        public void testEditarDivisasEnAlcanciaVacia()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarConAlcanciaSinDinero();
            atrTestDivisa= new clsDivisa(1, "USD", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 });

            Assert.IsTrue(atrTestSistema.editarAlcancia(1, 10, 5, new List<int> { 500 }, new List<int> { 2000, 5000 }));
            Assert.Equals(0,atrTestSistema.darAlcancia().darDivisa().CompareTo(atrTestDivisa));
        }
        [TestMethod]
        public void testEditarDivisasEnAlcanciaConDinero()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarConAlcanciaSinDinero();
            atrTestDivisa = new clsDivisa(1, "USD", new List<int> { 1, 5, 10, 20, 50, 100, 200, 500, 1000 });

            Assert.IsFalse(atrTestSistema.editarAlcancia(1, 10, 5, new List<int> { 500 }, new List<int> { 2000, 5000 }));
            Assert.AreNotEqual(0, atrTestSistema.darAlcancia().darDivisa().CompareTo(atrTestDivisa));
        }
        [TestMethod]
        public void testEditarCapMonedasEnAlcanciaVacia()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarConAlcanciaSinDinero();
            atrTestAlcancia = new clsAlcancia(atrTestSistema.darDivisas()[0], 10, 5, new List<int> { 500 }, new List<int> { 2000, 5000 });

            Assert.IsTrue(atrTestSistema.editarAlcancia(0, 11, 5, new List<int> { 500 }, new List<int> { 2000, 5000 }));
            Assert.AreNotEqual(0, atrTestSistema.darAlcancia().CompareTo(atrTestAlcancia));
        }
        [TestMethod]
        public void testEditarCapMonedasMayorEnAlcanciaConDinero()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarConAlcanciaConDinero();

            Assert.IsTrue(atrTestSistema.editarAlcancia(0, 11, 5, new List<int> { 500 }, new List<int> { 2000, 5000 }));
            Assert.AreEqual(11, atrTestSistema.darAlcancia().darCapacidadMonedas());
            Assert.AreEqual(1, atrTestSistema.darAlcancia().darConteoMonedas());
        }
        [TestMethod]
        public void testEditarCapMonedasMenorEnAlcanciaConDinero()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarConAlcanciaConDinero();

            Assert.IsFalse(atrTestSistema.editarAlcancia(0, 0, 5, new List<int> { 500 }, new List<int> { 2000, 5000 }));
            Assert.AreEqual(10, atrTestSistema.darAlcancia().darCapacidadMonedas());
            Assert.AreEqual(1, atrTestSistema.darAlcancia().darConteoMonedas());
        }
        [TestMethod]
        public void testEditarCapBilletesEnAlcanciaVacia()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarConAlcanciaSinDinero();
            atrTestAlcancia = new clsAlcancia(atrTestSistema.darDivisas()[0], 10, 5, new List<int> { 500 }, new List<int> { 2000, 5000 });

            Assert.IsTrue(atrTestSistema.editarAlcancia(0, 10, 6, new List<int> { 500 }, new List<int> { 2000, 5000 }));
            Assert.AreEqual(6, atrTestSistema.darAlcancia().darCapacidadBilletes());
            Assert.AreNotEqual(0, atrTestSistema.darAlcancia().CompareTo(atrTestAlcancia));
        }
        [TestMethod]
        public void testEditarCapBilletesMayorEnAlcanciaConDinero()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarConAlcanciaConDinero();

            Assert.IsTrue(atrTestSistema.editarAlcancia(0, 10, 6, new List<int> { 500 }, new List<int> { 2000, 5000 }));
            Assert.AreEqual(6, atrTestSistema.darAlcancia().darCapacidadBilletes());
            Assert.AreEqual(1, atrTestSistema.darAlcancia().darConteoBilletes());
        }
        [TestMethod]
        public void testEditarCapBilletesMenorEnAlcanciaConDinero()
        {
            atrTestSistema = clsSistema.darInstancia();
            atrTestSistema.generarConAlcanciaConDinero();

            Assert.IsFalse(atrTestSistema.editarAlcancia(0, 10, 0, new List<int> { 500 }, new List<int> { 2000, 5000 }));
            Assert.AreEqual(5, atrTestSistema.darAlcancia().darCapacidadBilletes());
            Assert.AreEqual(1, atrTestSistema.darAlcancia().darConteoBilletes());
        }
        [TestMethod]
        public void testEditarDenMonedasEnAlcanciaVacia()
        { }

        [TestMethod]
        public void testEditarDenMonedasMayorEnAlcanciaConDinero()
        { }
        [TestMethod]
        public void testEditarDenMonedasMenorEnAlcanciaConDinero()
        { }

        [TestMethod]
        public void testEditarDenMonedasMenorEnAlcanciaSinSaldos()//Editar Denominacion con moneda
        { }
        [TestMethod]
        public void testEditarDenMonedasMenorEnAlcanciaConSaldos()
        { }

        [TestMethod]
        public void testEditarDenBilletesMayorEnAlcanciaConDinero()
        { }
        [TestMethod]
        public void testEditarDenBilletesMenorEnAlcanciaConDinero()
        { }

        [TestMethod]
        public void testEditarDenBilletesMenorEnAlcanciaSinSaldos()//Editar Denominacion con moneda
        { }
        [TestMethod]
        public void testEditarDenBilletesMenorEnAlcanciaConSaldos()
        { }
        #endregion
    }
}
