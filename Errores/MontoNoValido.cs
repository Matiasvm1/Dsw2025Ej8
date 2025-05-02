using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Errores
{
    internal class MontoNoValido : Exception
    {
        public MontoNoValido() : base(" El monto ingresado no es válido para la operación solicitada.")
        {
        }
        public MontoNoValido(string message) : base(message)
        {
        }
    }
}
