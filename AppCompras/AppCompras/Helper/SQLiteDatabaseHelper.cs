using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using AppCompras.Models;
using SQLite;

namespace AppCompras.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conexao;

        public SQLiteDatabaseHelper(string path)
        {
            _conexao = new SQLiteAsyncConnection(path);
            _conexao.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _conexao.InsertAsync(p);
        }

        public void Update(Produto p)
        {
            string sql = "UPDATE Produto SET nome = ?, quantidade = ?, preco = ? WHERE id = ?";

            _conexao.QueryAsync<Produto>(sql, p.nome, p.quantidade, p.preco, p.id);

        }

        public Task<List<Produto>> Select()
        {
            return _conexao.Table<Produto>().ToListAsync();
        }

        /*public Task<Produto> GetById(int id)
        {
            return new Produto();
        }*/

        public Task<int> Delete(int id)
        {
            return _conexao.Table<Produto>().DeleteAsync(i => i.id == id);
        }
    }
}
