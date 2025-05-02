using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Errores;

namespace Dsw2025Ej8.Domain;

public class CajaDeAhorro : CuentaBancaria 
{
    public decimal TasaDeIntereses { get; set; }

    public CajaDeAhorro(string numero, decimal saldo, string[] titulares) :
        base(numero, saldo, TipoCuenta.CajaDeAhorro, titulares)
    {
    }

    public override void Depositar(decimal monto)
    {
        try
        {
            if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            else if (Estado != Estado.Activa)
            {
                throw new CuentaNoActiva($"No se puede operar con la cuenta {Estado}");
            }
            else
            {
                Saldo += monto;
                Console.WriteLine($"Deposito de ${monto} realizado con exito.");
            }


        }
        catch (MontoNoValido ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (CuentaNoActiva ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public override void Retirar(decimal monto)
    {
        try
        {
            if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            else if (Estado != Estado.Activa)
            {
                throw new CuentaNoActiva($"No se puede operar con la cuenta {Estado}");
            }
            else if ((Saldo - monto) < 0)
            {
                throw new SaldoInsuficiente("La cuenta no cuenta con saldo para la operacion Solicitada. Fue Suspendida.");
            }
            else
            {
                Saldo -= monto;
                Console.WriteLine($"Retiro de $ {monto} realizado con exito.");
            }
        }
        catch (MontoNoValido ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (CuentaNoActiva ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (SaldoInsuficiente ex)
        {
            Estado = Estado.Suspendida;
            Console.WriteLine(ex.Message);
        }
    }
}

