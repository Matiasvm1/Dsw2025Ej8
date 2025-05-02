using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CajaDeAhorro : CuentaBancaria 
{
    public decimal TasaDeIntereses { get; set; }

    public CajaDeAhorro(string numero, decimal saldo, string[] titulares) :
        base(numero, saldo, TipoCuenta.CajaDeAhorro, titulares)
    {
    }
}

