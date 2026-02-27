using System;
using System.Collections.Generic;
using FirebirdSql.Data.FirebirdClient;


namespace Repositories
{

    public static class TransacoesRepor
    {
        public static void Registrar(string identificador, string mensagem)
        {
            using (var conn = new FbConnection(ConexaoBanco.ObterStringConexao()))
            {
                conn.Open();
                using (var cmd = new FbCommand(
                    "INSERT INTO TRANSACOES (ID_CLIENTE, MENSAGEM, DATA_HORA) VALUES (@IdCliente, @Mensagem, @DataHora)", conn))
                {
                    if (int.TryParse(identificador, out int id))
                        cmd.Parameters.AddWithValue("@IdCliente", id);
                    else
                        cmd.Parameters.AddWithValue("@IdCliente", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Mensagem", mensagem);
                    cmd.Parameters.AddWithValue("@DataHora", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<string> ObterExtratoPorCliente(int clienteId)
        {
            var extrato = new List<string>();
            using (var conn = new FbConnection(ConexaoBanco.ObterStringConexao()))
            {
                conn.Open();
                using (var cmd = new FbCommand(
                    "SELECT DATA_HORA, MENSAGEM FROM TRANSACOES WHERE ID_CLIENTE = @IdCliente ORDER BY DATA_HORA", conn))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", clienteId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            extrato.Add($"\n{reader.GetDateTime(0):dd/MM/yyyy HH:mm:ss} : {reader.GetString(1)}");
                        }
                    }
                }
            }
            return extrato;
        }
    }
}