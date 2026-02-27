using FirebirdSql.Data.FirebirdClient;

namespace Repositories
{
    public abstract class RepositorioBase
    {
        protected readonly string _conexao;

        protected RepositorioBase(string conexao)
        {
            _conexao = conexao;
        }

        protected FbConnection CriarConexao()
        {
            var conexao = new FbConnection(_conexao);
            conexao.Open();
            return conexao;
        }
    }
}