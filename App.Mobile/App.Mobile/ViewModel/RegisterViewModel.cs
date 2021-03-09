using App.Mobile.Data.Api;
using App.Mobile.Model;
using App.Mobile.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App.Mobile.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand RegistarCommand => new Command(Registar);
        public ICommand LoginCommand => new Command(Login);

        private string _email { get; set; }
        private string _senha { get; set; }
        public string _nome { get; set; }
        public string _endereco { get; set; }
        public string _telefone { get; set; }

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

        public string Nome
        {
            get => _nome;
            set
            {
                _nome = value;
            }
        }

        public string Telefone
        {
            get => _telefone;
            set
            {
                _telefone = value;
            }
        }

        public string Endereco
        {
            get => _endereco;
            set
            {
                _endereco = value;
            }

        }
        private async void Registar(object obj)
        {
            try
            {
                //Validar se preencheu todos os campos para o Registo
                if (string.IsNullOrEmpty(_email))
                {
                    await Application.Current.MainPage.DisplayAlert("EMAIL", "Preencher o campo email para poder criar a sua conta.", "Ok");

                    //await Application.Current.MainPage.DisplayAlert(_NotaSeleciodado.Titulo, _NotaSeleciodado.Nota, "Ok");
                    //await Application.Current.MainPage.Navigation.PushAsync(new NoteView(_NotaSeleciodado));
                }
                else if (string.IsNullOrEmpty(_senha))
                {
                    await Application.Current.MainPage.DisplayAlert("SENHA", "Preencher o campo senha para poder criar a sua conta.", "Ok");
                }
                else if (string.IsNullOrEmpty(_nome))
                {
                    await Application.Current.MainPage.DisplayAlert("NOME", "Preencher o campo NOME para poder criar a sua conta.", "Ok");
                }
                else if (string.IsNullOrEmpty(_endereco))
                {
                    await Application.Current.MainPage.DisplayAlert("ENREDEÇO", "Preencher o campo ENDEREÇO para poder criar a sua conta.", "Ok");
                }
                else if (string.IsNullOrEmpty(_telefone))
                {
                    await Application.Current.MainPage.DisplayAlert("TELEFONE", "Preencher o campo TELEFONE para poder criar a sua conta.", "Ok");
                }
                else
                {
                    //Formar o objecto para poder criar conta na app
                    Account account = new Account();
                    account.Email = _email;
                    account.Password = _senha;
                    account.ConfirPassword = _senha;
                    account.Nome = _nome;
                    account.Endereco = _endereco;
                    account.Telefone = _telefone;

                    //Registar o cliente
                    API_Account aPI_Account = new API_Account();
                    Account account1 = await aPI_Account.CreateAccount(account);

                    if(string.IsNullOrEmpty(account1.Token))
                    {
                        await Application.Current.MainPage.DisplayAlert(account1.Message, account1.DetailMessage, "Ok");

                    }else
                    {
                        //Se o login ocorrer com sucesso guadar o token
                        await SecureStorage.SetAsync("oauth_token", account1.Token);
                        ConfigSystem.Token = account1.Token;
                        //Guardar o email do utilizador
                        await SecureStorage.SetAsync("email_user", account1.Email);
                        ConfigSystem.Email = account1.Email;

                        Application.Current.MainPage = new NavigationPage(new NotesView())
                        {
                            BarBackgroundColor = Color.FromHex("#023047")
                        };

                    }

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("REGISTAR", ex.Message, "Ok");
            }
        }
        private async void Login(object obj)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PopAsync(); 
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("REGISTAR", ex.Message, "Ok");
            }
        }


    }
}
