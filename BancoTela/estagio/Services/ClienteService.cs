
using estagio.Helper;
using Models;
using Repositories;

namespace Services
{
    public class ClienteService
    {
        private readonly ClientesRepor _repo;

        public ClienteService(ClientesRepor repo)
        {
            _repo = repo;
        }

        // Buscar cliente por ID
        public Clientes? ObterCliente(int id)
        {
            return _repo.ObterCliente(id);
        }

        // Buscar cliente por CPF
        public Clientes? ObterClientePorCpf(string cpf)
        {
            return _repo.ObterClientePorCpf(cpf);
        }

        // Criar novo cliente
        public bool RegistrarCliente(Clientes cliente)
        {
            return _repo.CriarCliente(cliente);
        }

        // Atualizar saldo
        public void AtualizarSaldo(Clientes cliente)
        {
            _repo.AtualizarSaldo(cliente);
        }

        // Atualizar senha direto (sem validação)
        public void AtualizarSenha(Clientes cliente)
        {
            _repo.AtualizarSenha(cliente);
        }

        // Alterar senha com validação
        public void AlterarSenha(Clientes cliente)
        {
            Console.WriteLine("Digite sua senha atual: ");
            string senhaAtual = SenhaCriptografada.LerSenha();

            if (cliente.Senha != senhaAtual)
            {
                Console.WriteLine("Senha atual incorreta. Operação cancelada.");
                return;
            }

            Console.WriteLine("\nDigite sua nova senha: ");
            string novaSenha = SenhaCriptografada.LerSenha();
            Console.WriteLine("Confirme sua nova senha: ");
            string confirmarSenha = SenhaCriptografada.LerSenha();

            if (novaSenha != confirmarSenha)
            {
                Console.WriteLine("As senhas não coincidem. Operação cancelada.");
                return;
            }

            cliente.Senha = novaSenha;
            _repo.AtualizarSenha(cliente); // persiste no banco

            Console.WriteLine("Senha atualizada com sucesso.");
        }
    }
}
