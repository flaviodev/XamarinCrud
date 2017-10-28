using CrudAula.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite.Net.Attributes;
using Java.IO;
using Android.Util;

namespace CrudAula.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaContato : ContentPage
    {
        public TelaContato()
        {

            InitializeComponent();

            using (var dados = new ContatoRepository())
            {
                this.Lista.ItemsSource = dados.Listar();
            }

        }
        protected void SalvarClicked(Object sender, EventArgs e)
        {
            var contato = new Contato
            {
                Nome = this.Nome.Text,
                Email = this.Email.Text,
                Telefone = this.Telefone.Text

            };

            using (var dados = new ContatoRepository())
            {
                dados.Insert(contato);
                this.Lista.ItemsSource = dados.Listar();
            }
        }

        protected void ExcluirClicked(Object sender, EventArgs e)
        {
            Contato contato = (Contato) Lista.SelectedItem;    

            if (contato !=null)
            {
                using (var dados = new ContatoRepository())
                {
                    dados.Delete(contato);
                    this.Lista.ItemsSource = dados.Listar();
                }

            }

        }

    }
}