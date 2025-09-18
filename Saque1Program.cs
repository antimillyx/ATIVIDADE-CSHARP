using System;
using System.Collections.Generic;

public class ContaCorrente
{
    public string Agencia { get; }
    public string Numero { get; }
    public string Titular { get; }
    public decimal Saldo { get; private set; }
    public decimal Limite { get; }
    public List<string> Transacoes { get; }

    public ContaCorrente(string agencia, string numero, string titular, decimal limite)
    {
        Agencia = agencia;
        Numero = numero;
        Titular = titular;
        Limite = limite;
        Saldo = 0;
        Transacoes = new List<string>();
    }

    public void Depositar(decimal valor)
    {
        Saldo += valor;
        Transacoes.Add($"Depósito de R$ {valor:F2}");
    }

    public bool Sacar(decimal valor)
    {
        if (valor <= Saldo + Limite)
        {
            Saldo -= valor;
            Transacoes.Add($"Saque de R$ {valor:F2}");
            return true;
        }
        Transacoes.Add($"Tentativa de saque de R$ {valor:F2} (saldo insuficiente)");
        return false;
    }

    public void Extrato()
    {
        Console.WriteLine("Extrato:");
        foreach (var transacao in Transacoes)
        {
            Console.WriteLine(transacao);
        }
    }
}

class Program
{
    static void Main()
    {

        var conta = new ContaCorrente("1234", "56789", "Maria Silva", 500.00m);
        

        conta.Depositar(1000.00m);
        
 
        conta.Sacar(300.00m);
        
       
        Console.WriteLine($"Saldo final: R$ {conta.Saldo:F2}");
        conta.Extrato();
    }
}
