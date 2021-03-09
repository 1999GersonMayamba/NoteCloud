using App.Mobile.Data.Api;
using App.Mobile.Model;
using App.Mobile.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App.Mobile.ViewModel
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //private string titulo, nota;
        //private DateTime data;
        public Command NoteSelectedCommand { get; }
        public ICommand AddNoteCommand => new Command(AddNote);
        public ICommand RemoveNoteCommand => new Command<Note>(RemoveNote);
        public ICommand UpdateNoteCommand => new Command(UpdateNote);
        public ICommand GetNotesCommand { get; set; }
        public ICommand NewNoteCommand => new Command(NewNote);
        public ICommand LogoutCommand => new Command(LogoutApp);
        private bool _IndicatorActiviy { get; set; }

        private Note _NotaSeleciodado { get; set; }     
        public Note NotaSeleciodado
        {
            get => _NotaSeleciodado;
            set
            {
                if(_NotaSeleciodado != value)
                {
                    _NotaSeleciodado = value;
                    NotaSelecled(); //Método invocado quando se fazer o set da propriedade
                }
            }
        }

        public bool IndicatorActiviy
        {
            get => _IndicatorActiviy;
            set {   _IndicatorActiviy = value;}
        }

        private API_Cliente apiService;

        private ObservableCollection<Note> notas;
        public ObservableCollection<Note> Notas
        {
            get { return notas; }
            set
            {
                notas = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private async void NotaSelecled()
        {
            try
            {
                ConfigSystem.UpdateOrDelete = 1;
                //await Application.Current.MainPage.DisplayAlert(_NotaSeleciodado.Titulo, _NotaSeleciodado.Nota, "Ok");
                await Application.Current.MainPage.Navigation.PushAsync(new NoteView(_NotaSeleciodado));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("NOVA NOTA", ex.Message, "Ok");
            }
        }

        public   NotesViewModel()
        {

        }


        private async void LogoutApp(object obj)
        {
            try
            {
                //Habilitar o indicador de actividade
                IndicatorActiviy = true;

                bool DialogResult = await Application.Current.MainPage.DisplayAlert("Sair", "Tem a certeza que deseja sair da aplicação", "SIM", "NÃO");

                if(DialogResult == true)
                {
                    //Remover o token da security storage
                    SecureStorage.Remove("oauth_token");
                    ConfigSystem.Token = null;
                    //Remover o email da securiry storage
                    SecureStorage.Remove("email_user");
                    ConfigSystem.Email = null;

                    Application.Current.MainPage = new NavigationPage(new LoginView())
                    {
                        BarBackgroundColor = Color.FromHex("#023047")
                    };
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Sair", ex.Message, "Ok");

            }

            //Desabilitar o indicador de actividade
            IndicatorActiviy = true;
        }


        public async void ListaDeNotas()
        {
            try
            {

                var list = await apiService.NotasCliente(ConfigSystem.Email);
                Notas = new ObservableCollection<Note>(list.Nota);

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
                ConfigSystem.UpdateOrDelete = 0;
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

        public async void RemoveNote(Note note)
        {
            try
            {
                //Habilitar o indicador de actividade
                IndicatorActiviy = true;

                bool DialogResult = await Application.Current.MainPage.DisplayAlert("NOTA", "Tem a certeza que deseja eliminar está nota?", "SIM", "NÃO");

                if (DialogResult == true)
                {
                    API_Nota aPI_Nota = new API_Nota();
                    var DeleteResponse = await aPI_Nota.DeleteNote(note.Id);
                    await Application.Current.MainPage.DisplayAlert("NOTA", DeleteResponse, "Ok");
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("NOTAS", ex.Message, "Ok");
            }

            //Desabilitar o indicador de actividade
            IndicatorActiviy = false;
        }

        public void UpdateNote()
        {

        }

       


    }
}
