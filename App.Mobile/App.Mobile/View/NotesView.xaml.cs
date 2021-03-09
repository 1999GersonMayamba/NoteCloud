using App.Mobile.Data.Api;
using App.Mobile.Model;
using App.Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Mobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesView : ContentPage
    {
        public NotesView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();
            LodingNotes();
            //this.BindingContext = new NotesViewModel();
        }

        private async void LodingNotes()
        {
            try
            {
                //Apresentar o indicador de actividade
                IndicadorDeActividade.IsRunning = true;
                
                API_Cliente aPI_Cliente = new API_Cliente();
                var listNotes = await aPI_Cliente.NotasCliente(ConfigSystem.Email);
                Notas.ItemsSource = listNotes.Nota;
            }
            catch(Exception ex)
            {
               await DisplayAlert("NOTAS", ex.Message, "OK");
            }

            //Desabilitar o indicador de actividade
            IndicadorDeActividade.IsRunning = false;
        }
    }
}