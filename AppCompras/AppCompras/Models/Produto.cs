using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppCompras.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nome { get; set; }
        public double quantidade { get; set; }
        public double preco { get; set; }


    }
}
