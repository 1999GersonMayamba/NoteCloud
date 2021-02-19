using App.Mobile.Model;
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
        public ObservableCollection<Note> Notas { get; set; }
        public Command NoteSelectedCommand { get; }
        public ICommand AddNoteCommand => new Command(AddNote);
        public ICommand RemoveNoteCommand => new Command(RemoveNote);
        public ICommand UpdateNoteCommand => new Command(UpdateNote);

        public NotesViewModel()
        {

            Notas = new ObservableCollection<Note>()
            {
                new Note(){Titulo = "Summer Fun", Nota = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", Data = DateTime.Now.ToShortTimeString()},
                 new Note(){Titulo = "Summer Fun Mayamba", Nota = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", Data = DateTime.Now.ToShortTimeString()},
                  new Note(){Titulo = "Summer Fun", Nota = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", Data = DateTime.Now.ToShortTimeString()},
                   new Note(){Titulo = "Summer Fun Gerson", Nota = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", Data = DateTime.Now.ToShortTimeString()},
                    new Note(){Titulo = "Summer Fun", Nota = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", Data = DateTime.Now.ToShortTimeString()}
            };

            //Note note = new Note();
            //note.Titulo = "Summer Fun";
            //note.Nota = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s";
            //note.Data = DateTime.Now;
            //Notas.Add(note);
            //Notas.Add(note);
            //Notas.Add(note);
            //Notas.Add(note);
            //Notas.Add(note);

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

        //public string Titulo
        //{
        //    get => titulo;
        //    set
        //    {
        //        titulo = value;
        //        var args = new PropertyChangedEventArgs(nameof(Titulo));
        //        PropertyChanged?.Invoke(this, args);
        //    }
        //}

        //public string Nota
        //{
        //    get => nota;
        //    set
        //    {
        //        nota = value;
        //        var args = new PropertyChangedEventArgs(nameof(Nota));
        //        PropertyChanged?.Invoke(this, args);
        //    }
        //}

        //public DateTime Data
        //{
        //    get => data;
        //    set
        //    {
        //        data = value;
        //        var args = new PropertyChangedEventArgs(nameof(Data));
        //        PropertyChanged?.Invoke(this, args);
        //    }
        //}
    }
}
