using System;
using System.Collections.Generic;

public class ContaCorrente
{
    public string Agencia { get; private set; }
    public string Numero { get; private set; }
    public string Titular { get; private set; }
    public double Saldo { get; private set; }
    public double Limite { get; private set; }
    public List<string> Transacoes { get; private set; }

    public ContaCorrente(string agencia, string numero, string titular, double limite)
    {
        Agencia = agencia;
        Numero = numero;
        Titular = titular;
        Limite = limite;
        Saldo = 0;
        Transacoes = new List<string>();
        Transacoes.Add($"Conta aberta com limite de R$ {limite:F2}");
    }

    public void Depositar(double valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor de depósito deve ser positivo");
        }
        
        Saldo += valor;
        Transacoes.Add($"Depósito de R$ {valor:F2} - Saldo: R$ {Saldo:F2}");
    }

    public void Sacar(double valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor de saque deve ser positivo");
        }

        if (valor > Saldo + Limite)
        {
            throw new InvalidOperationException("Saldo insuficiente para saque");
        }

        Saldo -= valor;
        Transacoes.Add($"Saque de R$ {valor:F2} - Saldo: R$ {Saldo:F2}");
    }

    public void Extrato()
    {
        Console.WriteLine("\nExtrato da Conta:");
        foreach (var transacao in Transacoes)
        {
            Console.WriteLine(transacao);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        ContaCorrente conta = new ContaCorrente(
            agencia: "1234",
            numero: "56789",
            titular: "Maria Silva",
            limite: 500.00
        );

        try
        //DEPÓSITO DE 1 MIL
        {

            conta.Depositar(1000.00);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante operação: {ex.Message}");
        }


        Console.WriteLine($"\nSaldo final: R$ {conta.Saldo:F2}");


        conta.Extrato();
    }
}
