using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Errores;

namespace Dsw2025Ej8.Domain;

public class CuentaCorriente : CuentaBancaria
{
    public decimal LimiteDeDescubierto { get; set; }
    public decimal Comision { get; set; }
    public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, TipoCuenta.CuentaCorriente, titulares)
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
                decimal saldoArestar = monto * Comision;
                monto -= saldoArestar;
                Saldo += monto;
                Console.WriteLine($"Deposito de ${monto} realizado con exito. La comision es de ${Math.Round(saldoArestar, 2)}");
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
            else if (Saldo - monto <= LimiteDeDescubierto)
            {
                throw new SaldoInsuficiente();
            }
            else
            {
                Saldo -= monto;
                Console.WriteLine($"Retiro de {monto} realizado con exito.");
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
