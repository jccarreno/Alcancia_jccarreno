using System;
using Servicios.Interfaces;
using System.Collections.Generic;

namespace Servicios.Consulta
{
    public static class clsConsultor
    {
        public static bool existeIDOEn<TipoItem,TipoIDO>(List<TipoItem> prmColeccion, TipoIDO prmValor) where TipoItem : iPatronIDO<TipoIDO>
            where TipoIDO : IComparable
        {
            foreach(TipoItem varObjeto in prmColeccion)
            {
                if (varObjeto.darIDO().CompareTo(prmValor) == 0)
                    return true;
            }
            return false;
        }

        public static bool existeNombreEn<TipoItem>(List<TipoItem> prmColeccion,string prmValor)
            where TipoItem:iNombrable
        {
            foreach(TipoItem varObjeto in prmColeccion)
            {
                if (varObjeto.darNombre() == prmValor)
                    return true;
            }
            return false;
        }

        public static TipoItem recuperarItemDe<TipoItem, TipoIDO>(List<TipoItem> prmColeccion, TipoIDO prmValor)
            where TipoItem:iPatronIDO<TipoIDO>
            where TipoIDO:IComparable
        {
            foreach(TipoItem varObjeto in prmColeccion)
            {
                if (varObjeto.darIDO().CompareTo(prmValor) == 0)
                    return varObjeto;
            }
            return default(TipoItem);
        }

        public static int darNuevoIDO<TipoItem>(List<TipoItem> prmColeccion)
            where TipoItem:iPatronIDO<int>
        {
            if (prmColeccion.Count == 0) return 0;
            return prmColeccion[prmColeccion.Count - 1].darIDO() + 1;
        }

    }
}
