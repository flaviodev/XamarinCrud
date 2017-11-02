using CrudAula.model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudAula.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaContato : ContentPage
    {

        private Contato _contato;
        private bool _inlcluir;

        public TelaContato(object contato, bool incluir)
        {
            InitializeComponent();
            _contato = (Contato)contato;
            _inlcluir = incluir;

            this.Nome.Text = _contato.Nome;
            this.Email.Text = _contato.Email;
            this.Telefone.Text = _contato.Email;

            if(_inlcluir)
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
    }
}