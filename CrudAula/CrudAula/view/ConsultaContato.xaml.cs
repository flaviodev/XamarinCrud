using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CrudAula.model;

namespace CrudAula.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaContato : ContentPage
    {
        private Contato _contato;

        public ConsultaContato(object contato)
        {
            InitializeComponent();

            _contato = (Contato)contato;

            PopulaCampos(_contato);
        }

        private void PopulaCampos(Contato contato)
        {
            this.Nome.Text = contato.Nome;
            this.Email.Text = contato.Email;
            this.Telefone.Text = contato.Email;

            this.Rua.Text = contato.Rua;
            this.Numero.Text = contato.Numero.ToString();
            this.Complemento.Text = contato.Complemento;
            this.Bairro.Text = contato.Bairro;
            this.Cidade.Text = contato.Cidade;
            this.Estado.Text = contato.Estado;
            this.Cep.Text = contato.Cep;

        }

        private void EditarClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlteraContato(_contato, false));
        }

        private void ExcluirClicked(object sender, EventArgs e)
        {
            using (var dados = new ContatoRepository())
            {
                dados.Delete(_contato);
                Navigation.PopAsync();
            }
        }

        protected override void OnAppearing()
        {
            using (var dados = new ContatoRepository())
            {
                _contato = dados.ObterPeloId(_contato.Id);
                PopulaCampos(_contato);
            }

        }


    }
}