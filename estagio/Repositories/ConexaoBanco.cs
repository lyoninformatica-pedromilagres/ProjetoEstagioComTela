using System;

namespace Repositories
{
    public class ConexaoBanco
    {
        // Método que retorna a string de conexão
        public static string ObterStringConexao()
        {
            return "User=SYSDBA;Password=masterkey;Database=C:\\Pasta de Trabalho\\SAR\\SAR\\bin\\packed\\scripts\\Meubanco\\A.fdb;DataSource=localhost;Port=4050;";
        }
    }
}
