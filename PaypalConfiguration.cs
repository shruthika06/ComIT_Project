using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping
{
    public class PaypalConfiguration
    {
        //Variables for storing the clientID and clientSecret key
        public readonly static string ClientId;
        public readonly static string ClientSecret;
        //Constructor
        static PaypalConfiguration()
        {
            var config = GetConfig();
            ClientId = "AcJ4FAeKm8Km7G3XfSz2FjenDyoKwA2wFOTZOLTFsrL7YK1pINCn9XIoMj6eeShnifvZAFeBY7cJLQEh";
            ClientSecret = "EKTHCKqmy3QtqoNQCvmap2qjyY4Tla7R2N42_TgAQ-lAG-9oCQ-4diaLmB_eh7wIznWvfgAwvfJ6UtUv";
        }
        // getting properties from the web.config
        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            // getting accesstocken from paypal
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}