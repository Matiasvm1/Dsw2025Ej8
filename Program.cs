using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Creacion de cuentas
            CuentaBancaria cuenta1 = new CuentaCorriente("12345", 5000, new[] { "Matias Ignacio" }) { LimiteDeDescubierto = 1000, Comision = 0.05m };
            CuentaBancaria cuenta2 = new CuentaCorriente("67890", 3000, new[] { "Carlos Facundo" }) { LimiteDeDescubierto = 500, Comision = 0.03m };
            CuentaBancaria cuenta3 = new CajaDeAhorro("11223", 3900, new[] { "Emilio Sebastian" }) { TasaDeInteres = 0 };
            CuentaBancaria cuenta4 = new CajaDeAhorro("44556", 10000, new[] { "Carlos Lopez" }) { TasaDeInteres = 0.03m };
            //Lista de cuentas

            ListaDeCuentas listaDeCuentas = new ListaDeCuentas();

            listaDeCuentas.AgregarCuenta(cuenta1);
            listaDeCuentas.AgregarCuenta(cuenta2);
            listaDeCuentas.AgregarCuenta(cuenta3);
            listaDeCuentas.AgregarCuenta(cuenta4);

            //Muestro cuentas

            listaDeCuentas.MostrarResumenes();
            //Aplico operaciones incluyendo todos los errores posibles.

            RealizarOperaciones(cuenta1);
            RealizarOperaciones(cuenta2);
            RealizarOperaciones(cuenta3);
            RealizarOperaciones(cuenta4);


        }

        private static void RealizarOperaciones(CuentaBancaria cuenta)
        {


            Console.WriteLine($"\n\n\n----------------------\nCuenta:  {cuenta.Numero} \nTipo: {cuenta.TipoCuenta.ToString()}\nSaldo Actual: {cuenta.Saldo}");
            Console.WriteLine("---Depositos---");

            cuenta.Depositar(1000);
            cuenta.Depositar(-500);

            Console.WriteLine("--- Retiros ---");
            cuenta.Retirar(500);
            cuenta.Retirar(4000);
            cuenta.Retirar(100);


            if (cuenta is CajaDeAhorro caja)
            {
                caja.AplicarInteres();
            }
        }
    }
}
