using System;
using System.Collections.Generic;
using System.Text;


namespace Servicios.Interfaces
{
    public interface iPatronIDO<T> where T:IComparable
    {
        T darIDO();
    }
}
