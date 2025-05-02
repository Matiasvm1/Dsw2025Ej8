using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class ListaDeCuentas
    {
        private List<CuentaBancaria> _lista;
        public IReadOnlyList<CuentaBancaria> Lista => _lista.AsReadOnly();
        public ListaDeCuentas()
        {
            _lista = new List<CuentaBancaria>();
        }

        public void AgregarCuenta(CuentaBancaria cuenta)
        {
            _lista.Add(cuenta);
        }

        public void MostrarResumenes()
        {
            if (_lista == null || _lista.Count == 0)
            {
                Console.WriteLine("No hay cuentas para mostrar.");
                return;
            }

            foreach (var cuenta in _lista)
            {
                var resumen = cuenta.ObtenerResumen(); 
                MostrarResumen(resumen);  
            }
        }


        private void MostrarResumen(object resumen)
        {
            if (resumen == null)
            {
                Console.WriteLine("El resumen de la cuenta es nulo.");
                return;
            }

            try
            {
                
                var numero = resumen.GetType().GetProperty("Numero")?.GetValue(resumen);
                var tipo = resumen.GetType().GetProperty("TipoCuenta")?.GetValue(resumen);
                var saldo = resumen.GetType().GetProperty("Saldo")?.GetValue(resumen);

               
                if (numero == null || tipo == null || saldo == null)
                {
                    Console.WriteLine("Algunas propiedades del resumen son nulas.");
                }
                else
                {
                    
                    Console.WriteLine($"Número: {numero}, Tipo: {tipo}, Saldo: {saldo}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al acceder a las propiedades del resumen: {ex.Message}");
            }
        }

    }
}

