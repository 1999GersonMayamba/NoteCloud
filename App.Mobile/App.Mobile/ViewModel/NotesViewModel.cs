using App.Mobile.Data.Api;
using App.Mobile.Model;
using App.Mobile.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.Mobile.ViewModel
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //private string titulo, nota;
        //private DateTime data;
        public List<Note> Notas { get; set; }
        public Command NoteSelectedCommand { get; }
        public ICommand AddNoteCommand => new Command(AddNote);
        public ICommand RemoveNoteCommand => new Command(RemoveNote);
        public ICommand UpdateNoteCommand => new Command(UpdateNote);

        public ICommand NewNoteCommand => new Command(NewNote);
        private Note _NotaSeleciodado { get; set; }

        public Note NotaSeleciodado
        {
            get => _NotaSeleciodado;
            set
            {
                if(_NotaSeleciodado != value)
                {
                    _NotaSeleciodado = value;
                    NotaSelecled(); //Quando for selecionado uma nota invocar este método
                    //var args = new PropertyChangedEventArgs(nameof(NotaSeleciodado));
                    //PropertyChanged?.Invoke(this, args);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private async void NotaSelecled()
        {
            try
            {
                //await Application.Current.MainPage.DisplayAlert(_NotaSeleciodado.Titulo, _NotaSeleciodado.Nota, "Ok");
                await Application.Current.MainPage.Navigation.PushAsync(new NoteView(_NotaSeleciodado));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("NOVA NOTA", ex.Message, "Ok");
            }
        }

        public NotesViewModel()
        {

            ListaDeNotas();

        }

        private async void ListaDeNotas()
        {
            try
            {
                //Trazer as notas de um determinado utilizador
                API_Cliente aPI_Cliente = new API_Cliente();
                Cliente cliente = await aPI_Cliente.NotasCliente(ConfigSystem.Email);

                if(cliente.Nota.Count == 0)
                {

                }else
                {

                    Notas = new List<Note>();
                    Notas = cliente.Nota as List<Note>;
                    int total = Notas.Count;
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("NOTAS", ex.Message, "Ok");

            }

        }

        public async void NewNote()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new NoteView());
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("NOVA NOTA", ex.Message, "Ok");
            }
        }

        public void AddNote()
        {

        }

        public void RemoveNote()
        {

        }

        public void UpdateNote()
        {

        }

       


    }
}
