﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace CrudAula.model
{
    class ContatoRepository : IDisposable
    {
        private SQLite.Net.SQLiteConnection _conexao;

        public ContatoRepository()
        {
            var config = DependencyService.Get<IConfig>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "banco2.db3"));
            _conexao.CreateTable<Contato>();
        }

        public void Insert (Contato contato)
        {
            _conexao.Insert(contato);
        }

        public void Update(Contato contato)
        {
            _conexao.Update(contato);
        }

        public void Delete(Contato contato)
        {
            _conexao.Delete(contato);
        }

        public List<Contato> Listar()
        {
            return _conexao.Table<Contato>().OrderBy(c => c.Nome).ToList();
        }

        public Contato ObterPeloId(int id)
        {
            return _conexao.Table<Contato>().FirstOrDefault(c => c.Id == id);

        }

        public void Dispose()
        {
            _conexao.Dispose();
          //  throw new NotImplementedException();
        }
    }

}
