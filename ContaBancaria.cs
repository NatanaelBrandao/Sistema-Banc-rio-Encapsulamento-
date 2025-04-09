using System;
using System.Collections.Generic;
public class ContaBancaria
{
    private decimal _saldo;
    private string _numeroConta;
    private string _titular;
    private List<Transacao> _transacoes;

    public string NumeroConta => _numeroConta;
    public string Titular => _titular;
    public decimal Saldo => _saldo;

    public ContaBancaria(string numeroConta, string titular, decimal saldoInicial = 0)
    {
        _numeroConta = numeroConta;
        _titular = titular;
        _saldo = saldoInicial;
        _transacoes = new List<Transacao>();
        
        if(saldoInicial > 0)
            _transacoes.Add(new Transacao(TipoTransacao.Deposito, saldoInicial, "Saldo inicial"));
    }

    public void Depositar(decimal valor)
    {
        if(valor <= 0)
            throw new ArgumentException("Valor deve ser positivo");

        _saldo += valor;
        _transacoes.Add(new Transacao(TipoTransacao.Deposito, valor, "Depósito"));
    }

    public void Sacar(decimal valor)
    {
        if(valor <= 0)
            throw new ArgumentException("Valor deve ser positivo");
        if(valor > _saldo)
            throw new InvalidOperationException("Saldo insuficiente");

        _saldo -= valor;
        _transacoes.Add(new Transacao(TipoTransacao.Saque, valor, "Saque"));
    }

    public IEnumerable<Transacao> VerExtrato() => _transacoes.AsReadOnly();
}
