using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace CrudAula.model
{
    class Endereco
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public Estado_info Estado_info { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }

    }
}
