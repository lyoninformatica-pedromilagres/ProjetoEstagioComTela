using estagio.Helper;
using Models;
using Services;

namespace Menu
{
    public class MenuOperacoes
    {
        private readonly ClienteService _clienteService;

        public MenuOperacoes(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public Transacoes? LoginOuRegistroCliente()
        {
            Console.WriteLine("============ Bem-vindo ao sistema bancário! ============");
            Console.WriteLine("\nPossui ID de acesso? (sim/nao)");
            string respostaId = Console.ReadLine()?.Trim().ToLower();

            int id;
            Transacoes conta;

            if (respostaId == "sim")
            {
                Console.Write("Digite seu ID: ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    var cliente = _clienteService.ObterCliente(id); // usa o service
                    if (cliente != null)
                    {
                        if (string.IsNullOrEmpty(cliente.Senha))
                        {
                            Console.WriteLine("Este cliente ainda não possui senha cadastrada.");
                            Console.Write("Crie uma nova senha: ");
                            string novaSenha = SenhaCriptografada.LerSenha();

                            cliente.Senha = novaSenha;
                            _clienteService.AtualizarSenha(cliente); // persiste via service

                            Console.WriteLine("Senha cadastrada com sucesso! Agora faça login novamente.");
                            return null;
                        }

                        Console.Write("\nDigite sua senha: ");
                        string senhaDigitada = SenhaCriptografada.LerSenha();

                        if (cliente.Senha == senhaDigitada)
                        {
                            conta = new Transacoes(cliente, cliente.Saldo);
                            Console.WriteLine($"\nBem-vindo de volta, {cliente.Nome}! Seu saldo atual é de R$ {conta.Clientes.Saldo:F2}");
                            return conta;
                        }
                        else
                        {
                            Console.WriteLine("Senha incorreta. Acesso negado.");
                            return null;
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID não encontrado.");
                        return null;
                    }
                }
            }
            else
            {
                Console.Write("Digite o ID que foi informado pelo caixa eletrônico: ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    var clienteExistente = _clienteService.ObterCliente(id);
                    if (clienteExistente != null)
                    {
                        Console.WriteLine("ID já existe. Por favor, escolha outro ID.");
                        return null;
                    }

                    Console.Write("\nAgora digite seu nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("\nDigite seu CPF (somente números): ");
                    string cpf = Console.ReadLine();

                    if (Models.Clientes.ValidarFormatoCpf(cpf))
                    {

                    }
                    else
                    {
                        Console.WriteLine("CPF inválido! Digite os 11 números.");
                    }

                        Console.Write("\nCrie uma senha de acesso: ");
                    string senha = SenhaCriptografada.LerSenha();

                    var saldo = new Random().Next(100, 5001);

                    var titular = new Clientes(id, nome, cpf, saldo, senha);
                    _clienteService.RegistrarCliente(titular); // cria via service

                    conta = new Transacoes(titular, saldo);
                    Console.WriteLine($"Cliente {nome}, você foi registrado. Seu saldo atual é de R$ {saldo:F2}");
                    return conta;
                }
            }

            return null;
        }
    }
}
