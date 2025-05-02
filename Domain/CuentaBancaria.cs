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
    #region Getters/Setters
    public string GetNumero()
    {
        return _numero;
    }

    public decimal GetSaldo()
    {
        return _saldo;
    }
    public TipoCuenta GetTipo()
    {
        return _tipo;
    }

    public Estado GetEstado()
    {
        return _estado;
    }

    public void SetEstado(Estado estado)
    {
        _estado = estado;
    }

    public decimal GetTasaDeInteres()
    {
        return _tasaDeInteres;
    }

    public void SetTasaDeInteres(decimal tasaDeInteres)
    {
        _tasaDeInteres = tasaDeInteres;
    }

    public decimal GetLimiteDeDescubierto()
    {
        return _limiteDeDescubierto;
    }

    public void SetLimiteDeDescubierto(decimal limiteDeDescubierto)
    {
        _limiteDeDescubierto = limiteDeDescubierto;
    }

    public decimal GetComision()
    {
        return _comision;
    }

    public void SetComision(decimal comision)
    {
        _comision = comision;
    }

    public string[] GetTitulares()
    {
        return _titulares;
    }
    #endregion

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
