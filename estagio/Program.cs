using FirebirdSql.Data.FirebirdClient;
using Models;
using Repositories;
using Services;
using Menu;
using System;

namespace estagio.Interface
{
    class Programa
    {
        static void Main(string[] args)
        {
            // String de conexão
            string connString = ConexaoBanco.ObterStringConexao();

            // Instancia o repositório
            var clientesRepo = new ClientesRepor(connString);

            // Instancia os serviços
            var clienteService = new ClienteService(clientesRepo);
            var transacaoService = new TransacaoService(clientesRepo);

            // Menu de login / registro
            var menuOperacoes = new MenuOperacoes(clienteService);
            Transacoes conta = menuOperacoes.LoginOuRegistroCliente();

            if (conta == null)
                return;

            // Menu principal
            var menuLista = new MenuLista(clienteService, transacaoService);
            menuLista.ExibirMenu(conta);
        }
    }
}


