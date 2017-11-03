using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace CrudAula.model
{
    class Estado_info
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public long Area_km2 { get; set; }
        public int Codigo_ibgeidade { get; set; }
        public string Nome { get; set; }
    }
}
