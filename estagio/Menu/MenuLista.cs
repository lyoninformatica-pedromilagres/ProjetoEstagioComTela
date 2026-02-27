using Models;
using Repositories;
using Services;
using Menu;
using System;
using System.Globalization;

namespace Menu
{
    public class MenuLista
    {
        private readonly ClienteService _clienteService;
        private readonly TransacaoService _transacaoService;

        public MenuLista(ClienteService clienteService, TransacaoService transacaoService)
        {
            _clienteService = clienteService;
            _transacaoService = transacaoService;
        }

        public void ExibirMenu(Transacoes conta)
        {
            bool continuarOperacao = true;
            while (continuarOperacao)
            {
                Console.WriteLine("\n1 - Consultar saldo\n2 - Sacar\n3 - Depositar\n4 - Empréstimo\n5 - Transferência\n6 - Extrato\n7 - Configurações\n8 - Sair\n");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine($"Seu saldo atual: R$ {conta.Clientes.Saldo:F2}");
                        break;

                    case "2":
                        Console.Write("Digite o valor desejado para o saque: ");
                        if (double.TryParse(Console.ReadLine(), out double valorSaque))
                        {
                            if (_transacaoService.Sacar(conta, valorSaque))
                                Console.WriteLine($"Saque de R$ {valorSaque:F2} realizado com sucesso. Saldo atual: R$ {conta.Clientes.Saldo:F2}");
                            else
                                Console.WriteLine("Saldo insuficiente para o saque.");
                        }
                        break;

                    case "3":
                        Console.Write("Digite o valor desejado para o depósito: ");
                        if (double.TryParse(Console.ReadLine(), out double valorDeposito))
                        {
                            if (_transacaoService.Depositar(conta, valorDeposito))
                                Console.WriteLine($"Depósito de R$ {valorDeposito:F2} realizado com sucesso. Saldo atual: R$ {conta.Clientes.Saldo:F2}");
                            else
                                Console.WriteLine("Não foi possível realizar o depósito.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Você só pode solicitar empréstimo de R$10.000,00 se tiver saldo maior que R$5.000,00.");
                        Console.WriteLine("Deseja solicitar um empréstimo? (sim/nao)");
                        string respostaEmprestimo = Console.ReadLine()?.Trim().ToLower();

                        if (respostaEmprestimo == "sim")
                        {
                            if (_transacaoService.SolicitarEmprestimo(conta))
                            {
                                _clienteService.AtualizarSaldo(conta.Clientes);
                                Console.WriteLine($"Empréstimo concedido! Novo saldo: R$ {conta.Clientes.Saldo:F2}");
                            }
                            else
                            {
                                Console.WriteLine("Saldo insuficiente para solicitar empréstimo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Empréstimo recusado.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("== TRANSFERÊNCIA ==");
                        Console.WriteLine("Digite o CPF ou ID do destinatário: ");
                        string identificador = Console.ReadLine();

                        var clienteDestino = int.TryParse(identificador, out int idDestino)
                            ? _clienteService.ObterCliente(idDestino)
                            : _clienteService.ObterClientePorCpf(identificador);

                        if (clienteDestino == null)
                        {
                            Console.WriteLine("Conta não encontrada.");
                            break;
                        }

                        if (clienteDestino.Id == conta.Clientes.Id || clienteDestino.Cpf == conta.Clientes.Cpf)
                        {
                            Console.WriteLine("Você não pode transferir para sua própria conta.");
                            break;
                        }

                        var contaDestino = new Transacoes(clienteDestino, clienteDestino.Saldo);
                        Console.WriteLine($"Você está transferindo para: {clienteDestino.Nome} (CPF: {clienteDestino.CpfFormatado})");

                        Console.WriteLine("\nDigite o valor da transferência: ");
                        if (double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.CurrentCulture, out double valorTransferencia))
                        {
                            if (_transacaoService.Transferir(conta, contaDestino, valorTransferencia))
                                Console.WriteLine($"Transferência de R$ {valorTransferencia:F2} realizada com sucesso!");
                            else
                                Console.WriteLine("Não foi possível realizar a transferência.");
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("\n=== EXTRATO BANCÁRIO ===");
                        var extrato = TransacoesRepor.ObterExtratoPorCliente(conta.Clientes.Id);
                        if (extrato.Any())
                        {
                            foreach (var linha in extrato)
                                Console.WriteLine(linha);
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma operação encontrada para este cliente.");
                        }
                        break;

                    case "7":
                        Console.WriteLine("Configuração");
                        var configuracaoConta = new ConfiguracaoConta(_clienteService);
                        configuracaoConta.MostrarConfiguracao(conta.Clientes);
                        break;

                    case "8":
                        _clienteService.AtualizarSaldo(conta.Clientes);
                        Console.WriteLine("Obrigado por usar nosso sistema bancário!");
                        continuarOperacao = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
