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
    public partial class AlteraContato : ContentPage
    {
        private Contato _contato;
        private bool _inlcluir;

        public AlteraContato(object contato, bool incluir)
        {
            InitializeComponent();
            _contato = (Contato)contato;
            _inlcluir = incluir;

            PopulaCampos(_contato);

            if (_inlcluir)
            {
                this.Title = "Novo Contato";
            }
            else
            {
                this.Title = "Alterar Contato";
            }

        }

        protected void SalvarClicked(Object sender, EventArgs e)
        {
            _contato.Nome = this.Nome.Text;
            _contato.Email = this.Email.Text;
            _contato.Telefone = this.Telefone.Text;

            _contato.Rua = this.Rua.Text;
            _contato.Numero = int.Parse(this.Numero.Text);
            _contato.Complemento = this.Complemento.Text;
            _contato.Bairro = this.Bairro.Text;
            _contato.Cidade = this.Cidade.Text;
            _contato.Estado = this.Estado.Text;
            _contato.Cep = this.Cep.Text;

            using (var dados = new ContatoRepository())
            {
                if (_inlcluir)
                {
                    dados.Insert(_contato);
                }
                else
                {
                    dados.Update(_contato);
                }

                Navigation.PopAsync();
            }
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

        /*
        private void BuscarCep_Clicked(object sender, EventArgs e)
        {

        }*/
    }
}