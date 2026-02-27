using Repositories;

namespace Models
{
    public class Transacoes
    {
        public Clientes Clientes { get; }
       
        public Transacoes(Clientes titularDaConta, double saldo)
        {
            Clientes = titularDaConta;
            Clientes.Saldo = saldo;
        }

       

        public bool Sacar(double valor)
        {
            if (valor <= 0) return false;
            if (valor > Clientes.Saldo) return false;

            Clientes.Saldo -= valor;
            

            return true; // apenas altera o saldo, sem persistir
        }

        public bool Depositar(double valor)
        {
            if (valor <= 0) return false;

            Clientes.Saldo += valor;
            

            return true; // apenas altera o saldo
        }

        public bool SolicitarEmprestimo()
        {
            if (Clientes.Saldo < 5000) return false;

            Clientes.Saldo += 10000;
            return true;
        }

        public bool Transferir(double valor, Transacoes destino) // parametro valor e destino
        {
            if (valor <= 0) return false; // se o valor for negativo ou zero, a transferência é inválida
            if (valor > Clientes.Saldo) return false; // se o valor for maior que o saldo disponível, a transferência não pode ser realizada
            Clientes.Saldo -= valor; // subtrai o valor do saldo da conta de origem

            destino.Clientes.Saldo += valor; // adiciona o valor ao saldo da conta de destino
            
            return true; // apenas altera os saldos, sem persistir
        }
    }
}