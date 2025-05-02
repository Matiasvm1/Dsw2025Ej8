namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public TipoCuenta TipoCuenta { get;}
    public String Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; }
    public string[] Titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        this.Numero = numero;
        this.Saldo = saldo;
        this.TipoCuenta = tipo;
        this.Estado = Estado.Activa;
        this.Titulares = titulares;
    }
    
   
 

    public abstract void Depositar(decimal monto);


    public abstract void Retirar(decimal monto);
    
    public object ObtenerResumen()
    {
        return new
        {
            Numero = this.Numero,
            TipoCuenta = this.TipoCuenta.ToString(),
            Saldo = this.Saldo
        };
    }
    
}
