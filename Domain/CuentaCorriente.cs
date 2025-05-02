using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CuentaCorriente : CuentaBancaria
{
    public decimal LimiteDeDescubierto { get; set; }
    public decimal Comision { get; set; }
    public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, TipoCuenta.CuentaCorriente, titulares)
    {
    }
}
