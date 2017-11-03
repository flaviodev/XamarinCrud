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
    public partial class ListaContato : ContentPage
    {
        public ListaContato()
        {
            InitializeComponent();
            this.AtualizarLista();
        }


        private void AtualizarLista()
        {
            using (var dados = new ContatoRepository())
            {
                this.Lista.ItemsSource = dados.Listar();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlteraContato(new Contato(), true));
        }


        protected override void OnAppearing()
        {
            this.AtualizarLista();
        }

        private void Lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new ConsultaContato(Lista.SelectedItem));
        }
    }
}