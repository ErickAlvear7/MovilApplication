

namespace MovilApplication.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Services;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using System;

    public class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        private DataService dataService;
        #endregion


        #region Atributos
        private string _nombreUsuario;
        private string _passwordUsuario;
        private bool _isToggled;
        private bool _isRunning;
        private bool _isEnabled;
        private bool _isRemember;

        #endregion


        #region Propiedades
        public string NombreUsuario {
            get { return _nombreUsuario; }
            set { SetValue(ref _nombreUsuario, value); }

        }

        public string passwordUsuario {
            get { return _passwordUsuario; }
            set { SetValue(ref _passwordUsuario, value); }
        }

        public bool isToggled {
            get { return _isToggled; }
            set { SetValue(ref _isToggled, value); }
        }

        public bool isRunning {
            get { return _isRunning; }
            set { SetValue(ref _isRunning, value); }
        }

        public bool isEnabled {
            get { return _isEnabled; }
            set { SetValue(ref _isEnabled, value); }
        }

        public bool IsRemember
        {
            get { return this._isRemember; }
            set { SetValue(ref this._isRemember, value); }
        }

        #endregion


        #region Constructor
        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.dataService = new DataService();
            this.isToggled = true;
            this.isEnabled = true;
            this.IsRemember = true;
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
            if (string.IsNullOrEmpty(this.NombreUsuario))
            {
                await Application.Current.MainPage.DisplayAlert("error", "ingrese usuario", "ok");
                return;
            }

            if (string.IsNullOrEmpty(this.passwordUsuario))
            {
                await Application.Current.MainPage.DisplayAlert("error", "ingrese contraseña", "ok");
                return;
            }

            this.isRunning = true;
            this.isEnabled = false;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.isRunning = false;
                this.isEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error de Conección",
                    connection.Message,
                    "ok");

                return;
            }

            var _urlbase = Application.Current.Resources["APIServices"].ToString();

            var _login = await this.apiService.GetLogin(
                _urlbase,
                "api",
                "login",
                this.NombreUsuario,
                this.passwordUsuario);

            if (_login.UserId == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Login Incorrecto",
                    connection.Message,
                    "ok");

                this.isRunning = false;
                this.isEnabled = true;
                this.passwordUsuario = string.Empty;

                return;

            }

            var userlocal = Converter.ToUserLocal(_login);
            var mainViewModel = MainViewModel.GetInstance();

            mainViewModel.userId = _login.UserId;
            mainViewModel.User = userlocal;

            if (this.IsRemember)
            {
                Settings.UserLogin = _login.UserId;
                this.dataService.Delete(userlocal);
                this.dataService.Insert(userlocal);
            }

            this.isRunning = false;
            this.isEnabled = true;
            this.NombreUsuario = string.Empty;
            this.passwordUsuario = string.Empty;

            mainViewModel.Order = new OrderViewModel();
            //MainViewModel.GetInstance().Orders = new OrdersViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new OrderPage());

            #endregion
        }
    }
}
