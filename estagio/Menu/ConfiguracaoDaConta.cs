using Models;
using Services;

namespace Menu
{
    public class ConfiguracaoConta
    {
        private readonly ClienteService _clienteService;

        public ConfiguracaoConta(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void MostrarConfiguracao(Clientes clientes)
        {
            Console.WriteLine("====== Configurações da Conta: ======= ");
            Console.WriteLine("\n1. Alterar Senha");
            Console.WriteLine("2. Voltar ao Menu Principal");
            Console.Write("\nEscolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    _clienteService.AlterarSenha(clientes); // chama o service para alterar senha
                    break;

                case "2":
                    Console.WriteLine("Voltando ao Menu Principal...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
    }
}
