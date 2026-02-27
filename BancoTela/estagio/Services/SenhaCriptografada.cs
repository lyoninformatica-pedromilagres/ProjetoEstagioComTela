
namespace estagio.Helper
{
    public static class SenhaCriptografada
    {
        public static string LerSenha()
        {
            string senha = "";
            ConsoleKeyInfo chave; // variável para capturar a tecla pressionada

            do
            {
                chave = Console.ReadKey(true); // lê a tecla pressionada sem exibir no console

                if (chave.Key == ConsoleKey.Backspace && senha.Length > 0) // se a tecla for Backspace e a senha não estiver vazia, remove o último caractere da senha
                {
                    senha = senha.Substring(0, senha.Length - 1); // remove o último caractere da senha
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(chave.KeyChar)) // se a tecla não for um caractere de controle, adiciona o caractere à senha e exibe um asterisco
                {
                    senha += chave.KeyChar;
                    Console.Write("*");
                }
            }
            while (chave.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return senha;
        }
    }
}
