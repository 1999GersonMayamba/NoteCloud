using App.Mobile.Data.Api;
using App.Mobile.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.Mobile.ViewModel
{
    public class NoteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SaveNoteCommand => new Command(SaveNote);
        public ICommand DeleteNoteCommand => new Command(DeleteNote);
        private string _titulo { get; set; }
        private string _nota { get; set; }

        private Note Note { get; set; }
        public string Titulo
        {
            get => _titulo;
            set 
            {
                _titulo = value;

            }
        }


        public string Nota
        {
            get => _nota;
            set
            {
                _nota = value;

            }
        }
        private async void SaveNote()
        {
            try
            {
                if(string.IsNullOrEmpty(_titulo))
                {
                    await Application.Current.MainPage.DisplayAlert("TITULO", "Preencher o campo TITULO para poder salvar a sua nota", "Ok");
                }
                else if(string.IsNullOrEmpty(_nota))
                {
                    await Application.Current.MainPage.DisplayAlert("NOTA", "Preencher o campo NOTA para poder salvar a sua nota", "Ok");
                }
                else
                {

                    if(ConfigSystem.UpdateOrDelete == 1)
                    {
                        API_Nota aPI_Nota = new API_Nota();
                        Note.Titulo = _titulo;
                        Note.Nota1 = _nota;
                        Note note = await aPI_Nota.UpdateNote(Note);
                        Titulo = note.Titulo;
                        Nota = note.Nota1;
                    }
                    else
                    {
                        API_Nota aPI_Nota = new API_Nota();
                        Note nota = new Note();
                        nota.Titulo = _titulo;
                        nota.Nota1 = _nota;
                        Cliente cliente = new Cliente();
                        cliente.Email = ConfigSystem.Email;
                        nota.IdClienteNavigation = cliente;
                        Note note = await aPI_Nota.SaveNote(nota);
                        if (!string.IsNullOrEmpty(note.Nota1))
                        {
                            await Application.Current.MainPage.DisplayAlert("NOTA", "A sua nota foi salva com sucesso.", "Ok");
                            //Após salvar a nota retroceder para a pagina inicial
                            await Application.Current.MainPage.Navigation.PopAsync();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("NOTA", "Ocorreu um erro ao tentar salvar a sua nota", "Ok");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("NOTA", ex.Message, "Ok");
            }
        }

        public NoteViewModel(Note note)
        {
            _nota = note.Nota1;
            _titulo = note.Titulo;
            Note = note;
        }

        public NoteViewModel()
        {

        }

        private async void DeleteNote()
        {
            try
            {
                //Habilitar o indicador de actividade
                //IndicatorActiviy = true;

                bool DialogResult = await Application.Current.MainPage.DisplayAlert("NOTA", "Tem a certeza que deseja eliminar está nota?", "SIM", "NÃO");

                if (DialogResult == true)
                {
                    API_Nota aPI_Nota = new API_Nota();
                    var DeleteResponse = await aPI_Nota.DeleteNote(Note.Id);
                    await Application.Current.MainPage.DisplayAlert("NOTA", DeleteResponse, "Ok");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("NOTAS", ex.Message, "Ok");
            }

            //Desabilitar o indicador de actividade
            //IndicatorActiviy = false;
        }

    }
}
