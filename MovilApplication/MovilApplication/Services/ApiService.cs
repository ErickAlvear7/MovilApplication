

namespace MovilApplication.Services
{
    using Models;
    using Newtonsoft.Json;
    using Plugin.Connectivity;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    public class ApiService
    {

        #region Coneciones
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Falló la Conexión"
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "google.com");

            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "No tiene Conección a Internet"
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Conexión Exitosa"
            };
        }
        #endregion


        #region Metodos
        public async Task<User> GetLogin(
           string urlBase,
           string api,
           string controller,
           string loginname,
           string password)
        {
            try
            {
                var client = new HttpClient();
                ///client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format(
                    "{0}/{1}/{2}/{3}",
                    api,
                    controller,
                    loginname,
                    password);
                var response = await client.GetAsync(url);
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<User>(resultJSON);
                return result;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error de Login",
                    ex.ToString(),
                    "Aceptar");
                return null;
            }
        }
    } 
    #endregion
}
