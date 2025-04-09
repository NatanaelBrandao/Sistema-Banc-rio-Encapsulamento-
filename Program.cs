using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.WriteLine("=== SISTEMA BANCÁRIO ===");
        Console.WriteLine("Cadastro de Nova Conta\n");
        
        // 1. Cadastro da conta
        Console.Write("Digite o número da conta: ");
        string numeroConta = Console.ReadLine();
        
        Console.Write("Digite o nome do titular: ");
        string titular = Console.ReadLine();
        
        Console.Write("Digite o saldo inicial (ou 0 para não ter saldo): ");
        decimal saldoInicial;
        while(!decimal.TryParse(Console.ReadLine(), out saldoInicial))
        {
            Console.Write("Valor inválido. Digite novamente: ");
        }
        
        var conta = new ContaBancaria(numeroConta, titular, saldoInicial);
        Console.WriteLine("\nConta criada com sucesso!");
        
        // 2. Menu de operações
        while(true)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Ver Saldo");
            Console.WriteLine("4 - Ver Extrato");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();
            
            try
            {
                switch(opcao)
                {
                    case "1": // Depositar
                        Console.Write("Digite o valor para depósito: ");
                        decimal valorDeposito;
                        while(!decimal.TryParse(Console.ReadLine(), out valorDeposito))
                        {
                            Console.Write("Valor inválido. Digite novamente: ");
                        }
                        conta.Depositar(valorDeposito);
                        Console.WriteLine("Depósito realizado com sucesso!");
                        break;
                        
                    case "2": // Sacar
                        Console.Write("Digite o valor para saque: ");
                        decimal valorSaque;
                        while(!decimal.TryParse(Console.ReadLine(), out valorSaque))
                        {
                            Console.Write("Valor inválido. Digite novamente: ");
                        }
                        conta.Sacar(valorSaque);
                        Console.WriteLine("Saque realizado com sucesso!");
                        break;
                        
                    case "3": // Ver Saldo
                        Console.WriteLine($"\nSaldo atual: {conta.Saldo:C}");
                        break;
                        
                    case "4": // Ver Extrato
                        Console.WriteLine("\n=== EXTRATO ===");
                        foreach(var t in conta.VerExtrato())
                        {
                            Console.WriteLine($"{t.DataHora:dd/MM/yyyy HH:mm} | " +
                                            $"{t.Tipo,-12} | " +
                                            $"{t.Valor,10:C} | " +
                                            $"{t.Descricao}");
                        }
                        break;
                        
                    case "5": // Sair
                        Console.WriteLine("Encerrando o sistema...");
                        return;
                        
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}