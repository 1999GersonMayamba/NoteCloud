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
        private void SaveNote()
        {
            throw new NotImplementedException();
        }

        private void DeleteNote()
        {
            throw new NotImplementedException();
        }
        public NoteViewModel(Note note)
        {
            _nota = note.Nota1;
            _titulo = note.Titulo;
        }

        public NoteViewModel()
        {

        }

    }
}
