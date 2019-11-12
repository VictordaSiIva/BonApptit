using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using BonApptit.Modelos;
using Xamarin.Forms;
namespace BonApptit.Banco
{
    public class DataBase
    {
        private SQLiteConnection _conexao;
        public DataBase()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Mesa>();
            _conexao.CreateTable<Pedido>();
            _conexao.CreateTable<Adicional>();
            _conexao.CreateTable<Lanches>();
            _conexao.CreateTable<Sobremesa>();
            _conexao.CreateTable<Acompanhamento>();

        }

        public void InserirMesa(Mesa mesa)
        {
            _conexao.Insert(mesa);
        }
        public void InserirPedido(Pedido pedido)
        {
            _conexao.Insert(pedido);
        }
        public void AtualizarPedido(int id)
        {
            _conexao.Table<Pedido>().Where(p => p.Id == id).FirstOrDefault();
            _conexao.Update(id);
        }
        public void ExcluirPedido(int id)
        {
            _conexao.Table<Pedido>().Where(p => p.Id == id).FirstOrDefault();
            _conexao.Delete(id);
        }

    }
}
