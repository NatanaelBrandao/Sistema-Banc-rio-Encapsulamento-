using System;
using System.Collections.Generic;

public enum TipoTransacao { Deposito, Saque, Transferencia }

public class Transacao
{
    public DateTime DataHora { get; }
    public TipoTransacao Tipo { get; }
    public decimal Valor { get; }
    public string Descricao { get; }

    public Transacao(TipoTransacao tipo, decimal valor, string descricao)
    {
        DataHora = DateTime.Now;
        Tipo = tipo;
        Valor = valor;
        Descricao = descricao;
    }
}
