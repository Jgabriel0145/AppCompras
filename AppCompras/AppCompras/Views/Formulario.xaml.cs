using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppCompras.Models;

namespace AppCompras.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Formulario : ContentPage
    {
        public Formulario()
        {
            InitializeComponent();
        }

        private async void tbSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto p = new Produto
                {
                    nome = txt_nome.Text,
                    quantidade = Convert.ToDouble(txt_quantidade.Text),
                    preco = Convert.ToDouble(txt_preco.Text)
                };

                await App.Database.Insert(p);

                await DisplayAlert("Sucesso!","Produto cadastrado com sucesso!","OK");

                await Navigation.PushAsync(new Listagem());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}