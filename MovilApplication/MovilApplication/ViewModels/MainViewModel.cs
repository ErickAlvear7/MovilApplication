

namespace MovilApplication.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class MainViewModel : BaseViewModel
    {
        #region Constructor

        public MainViewModel()

        {

            instance = this;

            this.Login = new LoginViewModel();

        }

        #endregion



        #region ViewsModels

        public LoginViewModel Login { get; set; }

        #endregion





        #region Singleton

        private static MainViewModel instance;

        public static MainViewModel GetInstance()

        {

            if (instance == null)

            {

                return new MainViewModel();

            }

            return instance;

        }

        #endregion
    }
}
