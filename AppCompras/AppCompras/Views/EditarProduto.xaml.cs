using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppCompras.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCompras.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarProduto : ContentPage
    {
        public EditarProduto()
        {
            InitializeComponent();
        }

        private async void tbSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto p = new Produto
                {
                    id = ((Produto)BindingContext).id,
                    nome = txt_nome.Text,
                    quantidade = Convert.ToDouble(txt_quantidade.Text),
                    preco = Convert.ToDouble(txt_preco.Text)
                };

                await App.Database.Update(p);

                await DisplayAlert("Sucesso!", "Produto atualizado com sucesso!", "OK");

                await Navigation.PushAsync(new Listagem());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void tbVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Listagem());
        }
    }
}