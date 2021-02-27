

namespace MovilApplication.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {

        #region Atributos
        private string _nombreUsuario;
        private string _passwordUsuario; 
        #endregion



        #region Propiedades
        public string mombreUsuario {
            get{ return _nombreUsuario; }
            set { SetValue(ref _nombreUsuario, value); }
        
        }

        public string passwordUsuario {
            get { return _passwordUsuario; }
            set { SetValue(ref _passwordUsuario, value); }
        }

        public bool isToggled { get; set; }

        public bool isRunning { get; set; }
        #endregion

        #region MyRegion
        public LoginViewModel()
        {
            this.isToggled = true;
        }

        #endregion

        #region Comandos
        public ICommand loginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        #endregion



        #region Metodos
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.mombreUsuario))
            {
                await Application.Current.MainPage.DisplayAlert("error", "ingrese usuario", "ok");
                return;
            }

            if (string.IsNullOrEmpty(this.passwordUsuario))
            {
                await Application.Current.MainPage.DisplayAlert("error", "ingrese contraseña", "ok");
                return;
            }
        }

      






        #endregion
    }
}
