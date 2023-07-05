using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Formato
{
    public static class clsFormateador
    {
        public static tipoSalida cambiarTipo<tipoSalida>(object prmContenido)
        {
            try
            {
                tipoSalida varObjeto = (tipoSalida)Convert.ChangeType(prmContenido, typeof(tipoSalida));
                return varObjeto;
            }
            catch(Exception e)
            {
                return default(tipoSalida);
            }
        }
    }
}
