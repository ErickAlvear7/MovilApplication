

namespace MovilApplication
{
    using Views;
    using Xamarin.Forms;
    public partial class App : Application
    {
        #region Constructor
        public App()
        {
            InitializeComponent();

            // MainPage = new LoginPage();
            this.MainPage = new NavigationPage(new LoginPage());
        }
        #endregion

        #region Metodos
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        } 
        #endregion
    }
}
