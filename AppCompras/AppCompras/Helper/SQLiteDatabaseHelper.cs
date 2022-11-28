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

        }

        public void Insert(Produto p)
        {

        }

        public void Update(Produto p)
        {

        }

        public Task<List<Produto>> Select()
        {
            return new List<Produto>();
        }

        public Task<Produto> GetById(int id)
        {
            return new Produto();
        }

        public void Delete(int id)
        {

        }
    }
}
