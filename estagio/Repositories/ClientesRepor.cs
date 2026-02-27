using FirebirdSql.Data.FirebirdClient;
using Models;

namespace Repositories

{
    public class ClientesRepor : RepositorioBase
    {
        public ClientesRepor(string conexao) : base(conexao) { }


        // metodo de consulta 
        public Models.Clientes? ObterCliente(int id)
        {
            using var conexao = CriarConexao();
            string sql = "SELECT ID, SALDO, NOME, CPF, SENHA FROM CLIENTES WHERE ID = @id";
            using var cmd = new FbCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int idEncontrado = reader.GetInt32(0);
                double saldo = reader.GetDouble(1);
                string nome = reader.GetString(2);
                string cpf = reader.GetString(3);
                string senha = reader.IsDBNull(4) ? "" : reader.GetString(4);

                return new Models.Clientes(idEncontrado, nome, cpf, saldo, senha);

            }
            return null;
        }






        // metodo de consulta
        public Models.Clientes? ObterClientePorCpf(string cpf)
        {
            using var conexao = CriarConexao();
            string sql = "SELECT ID, SALDO, NOME, CPF, SENHA FROM CLIENTES WHERE CPF = @cpf";
            using var cmd = new FbCommand(sql, conexao);

            // normaliza o CPF digitado pelo cliente
            string cpfNumerico = new string(cpf.Where(char.IsDigit).ToArray());
            cmd.Parameters.AddWithValue("@cpf", cpfNumerico);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32(0);
                double saldo = reader.GetDouble(1);
                string nome = reader.GetString(2);
                string cpfEncontrado = reader.GetString(3);
                string senha = reader.GetString(4);

                // normaliza o CPF vindo do banco
                cpfEncontrado = new string(cpfEncontrado.Where(char.IsDigit).ToArray());

                return new Models.Clientes(id, nome, cpfEncontrado, saldo, senha);
            }
            return null;
        }



        //metodo de insercao 
        public bool CriarCliente(Models.Clientes clientes)
        {
            using var conexao = CriarConexao();
            string sql = "INSERT INTO CLIENTES (ID, SALDO, NOME, CPF, SENHA) VALUES (@id, @saldo, @nome, @cpf, @senha)";
            using var cmd = new FbCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", clientes.Id);
            cmd.Parameters.AddWithValue("@saldo", clientes.Saldo);
            cmd.Parameters.AddWithValue("@nome", clientes.Nome);
            cmd.Parameters.AddWithValue("@cpf", clientes.Cpf);
            cmd.Parameters.AddWithValue("@senha", clientes.Senha);

            int linhasAfetadas = cmd.ExecuteNonQuery();
            return linhasAfetadas > 0;
        }

        // metodo de atualizacao
        public void AtualizarSaldo(Models.Clientes clientes)
        {
            using var conexao = CriarConexao();
            string sql = "UPDATE CLIENTES SET SALDO = @saldo WHERE ID = @id";
            using var cmd = new FbCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", clientes.Id);
            cmd.Parameters.AddWithValue("@saldo", clientes.Saldo);
            cmd.ExecuteNonQuery();
        }

        public void AtualizarSenha(Models.Clientes clientes)
        {
            using var conexao = CriarConexao();
            string sql = "UPDATE CLIENTES SET SENHA = @senha WHERE ID = @id";
            using var cmd = new FbCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", clientes.Id);
            cmd.Parameters.AddWithValue("@senha", clientes.Senha);
            cmd.ExecuteNonQuery();
        }

    }
}