using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using AppCompras.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCompras.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listagem : ContentPage
    {
        ObservableCollection<Produto> lista_produtos = new ObservableCollection<Produto>();

        public Listagem()
        {
            InitializeComponent();

            lst_produtos.ItemsSource = lista_produtos;
        }

        private void tbNovo_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Formulario());
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro",ex.Message,"OK");
            }
        }

        private async void tbSomar_Clicked(object sender, EventArgs e)
        {
            double total = lista_produtos.Sum(i => i.quantidade * i.preco);

            await DisplayAlert("Total", $"O total da compra é R$ {total.ToString("F2")}", "OK");
        }

        protected override void OnAppearing()
        {
            if (lista_produtos.Count == 0)
            {
                Task.Run(async () =>
                {
                    List<Produto> list_temporaria = await App.Database.Select();

                    foreach (Produto item in list_temporaria)
                        lista_produtos.Add(item);

                    ref_carregando.IsRefreshing = false;
                });
            }
        }

        private async void miExcluir_Clicked(object sender, EventArgs e)
        {
            MenuItem disparador = (MenuItem)sender;

            Produto produto_selecionado = (Produto)disparador.BindingContext;

            bool confirmacao = await DisplayAlert("Exclusão", "Deseja excluir o produto?", "Sim", "Não");
        
            if (confirmacao)
            {
                await App.Database.Delete(produto_selecionado.id);

                lista_produtos.Remove(produto_selecionado);
            }
        
        }

        private void txt_pesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            string pesquisa = e.NewTextValue;

            Task.Run(async () =>
            {
                List<Produto> list_temporaria = await App.Database.Search(pesquisa);

                lista_produtos.Clear();

                foreach (Produto item in list_temporaria)
                    lista_produtos.Add(item);

                ref_carregando.IsRefreshing = false;
            });
        }

        private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new EditarProduto
            {
                BindingContext = (Produto)e.SelectedItem
            });
        }
    }
}