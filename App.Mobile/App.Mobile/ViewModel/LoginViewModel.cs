using App.Mobile.Data.Api;
using App.Mobile.Model;
using App.Mobile.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.Mobile.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoginCommand => new Command(Login);
        public ICommand RegisterCommand => new Command(Regiser);

        private string _email { get; set; }
        private string _senha { get; set; }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;

            }
        }

        public string Senha
        {
            get => _senha;
            set
            {
                _senha = value;

            }
        }

        private async void Login(object obj)
        {

            try
            {

                //Validar se preencheu todos os campos para o login
                if (string.IsNullOrEmpty(_email))
                {
                    await Application.Current.MainPage.DisplayAlert("EMAIL", "Preencher o campo email para poder entrar na sua conta.", "Ok");

                    //await Application.Current.MainPage.DisplayAlert(_NotaSeleciodado.Titulo, _NotaSeleciodado.Nota, "Ok");
                    //await Application.Current.MainPage.Navigation.PushAsync(new NoteView(_NotaSeleciodado));
                }
                else if (string.IsNullOrEmpty(_senha))
                {
                    await Application.Current.MainPage.DisplayAlert("SENHA", "Preencher o campo senha para poder entrar na sua conta.", "Ok");
                }
                else
                {
                    Account account = new Account();
                    account.Email = _email;
                    account.Password = _senha;
                    account.ConfirPasswrd = _senha;
                    API_Account aPI_Account = new API_Account();
                    var Result = await aPI_Account.Login(account) as Account;
                    if(!string.IsNullOrEmpty(Result.Grupo))
                    {
                        // await Application.Current.MainPage.Navigation.PushAsync( NotesViewModel());
                        Application.Current.MainPage = new  NavigationPage(new NotesView())
                        {
                            BarBackgroundColor = Color.FromHex("#023047")
                        };
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("LOGIN", "Usuário Invalido", "Ok");

                    }
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("ENTRAR", ex.Message, "Ok");
            }
        }

        private async void Regiser(object obj)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new RegisterView());
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("ENTRAR", ex.Message, "Ok");
            }

        }
    }
}
