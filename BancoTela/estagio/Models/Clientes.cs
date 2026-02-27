using Repositories;
namespace Models
{
    public class Clientes
    {
        public int Id { get; }
        public string Nome { get; }
        public string Cpf { get; }
        public double Saldo { get; set; }
        public string Senha { get; set; }

        // Propriedade que retorna o CPF formatado
        public string CpfFormatado
        {
            get
            {
                string apenasNumeros = new string(Cpf.Where(char.IsDigit).ToArray());
                if (apenasNumeros.Length == 11)
                {
                    return Convert.ToUInt64(apenasNumeros).ToString(@"000\.000\.000\-00");
                }
                return Cpf; // retorna como está se não tiver 11 dígitos


            }
        }
        public static bool ValidarFormatoCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return false;

            // Extrai apenas os números
            string apenasNumeros = new string(cpf.Where(char.IsDigit).ToArray());

            return apenasNumeros.Length == 11;
        }

        public Clientes(int id, string nome, string cpf, double saldo, string senha)  // adicionamos os parametros necessários para criar um cliente completo
        {
            Id = id;
            Nome = nome;
            Cpf = new string(cpf.Where(char.IsDigit).ToArray());
            Saldo = saldo;
            Senha = senha; // atribui a senha ao criar o cliente


        }

        
    }
}
