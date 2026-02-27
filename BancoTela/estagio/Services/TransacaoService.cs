using Models;
using Repositories;


namespace Services
{
    public class TransacaoService
    {
        private readonly ClientesRepor _clientesRepo;

        public TransacaoService(ClientesRepor clientesRepo)
        {
            _clientesRepo = clientesRepo;
        }

        public bool Sacar(Transacoes conta, double valor)
        {
            if (!conta.Sacar(valor)) return false;

            _clientesRepo.AtualizarSaldo(conta.Clientes);
            TransacoesRepor.Registrar(conta.Clientes.Id.ToString(),
                $"- Saque de R$ {valor:F2}. Saldo atual: R$ {conta.Clientes.Saldo:F2}");

            return true;
        }

        public bool Depositar(Transacoes conta, double valor)
        {
            if (!conta.Depositar(valor)) return false;

            _clientesRepo.AtualizarSaldo(conta.Clientes);
            TransacoesRepor.Registrar(conta.Clientes.Id.ToString(),
                $"+ Depósito de R$ {valor:F2}. Saldo atual: R$ {conta.Clientes.Saldo:F2}");

            return true;
        }

        public bool SolicitarEmprestimo(Transacoes conta)
        {
            if (!conta.SolicitarEmprestimo()) return false;
                
            _clientesRepo.AtualizarSaldo(conta.Clientes);
            TransacoesRepor.Registrar(conta.Clientes.Id.ToString(),
                $"+ Emprestimo no valor de R$ 10.000,00. Saldo atual: R$ {conta.Clientes.Saldo:F2}");

            return true;
        }


        public bool Transferir(Transacoes origem, Transacoes destino, double valor)
        {
            if (!origem.Transferir(valor, destino)) return false;

            _clientesRepo.AtualizarSaldo(origem.Clientes);
            _clientesRepo.AtualizarSaldo(destino.Clientes);

            TransacoesRepor.Registrar(origem.Clientes.Id.ToString(),
                $"- Transferência de R$ {valor:F2} para {destino.Clientes.Nome}. Saldo atual: R$ {origem.Clientes.Saldo:F2}");
            TransacoesRepor.Registrar(destino.Clientes.Id.ToString(),
                $"+ Recebimento de R$ {valor:F2} de {origem.Clientes.Nome}. Saldo atual: R$ {destino.Clientes.Saldo:F2}");

            return true;
        }
    }
}
