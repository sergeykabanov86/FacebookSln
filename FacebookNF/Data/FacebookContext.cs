using FacebookNF.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FacebookNF.Data
{
    internal class FacebookContext
    {

        #region Properties

        private Facebook.FacebookClient fbContext { get; set; }


        private string _ApplicationId;
        public string ApplicationID
        {
            get { return _ApplicationId; }
            set
            {
                _ApplicationId = value;
                fbContext.AppId = value;
            }
        }


        private string _APIKey;
        public string APIKey
        {
            get { return _APIKey; }
            set
            {
                _APIKey = value;
            }
        }



        private string _ApplicationSecret;
        public string ApplicationSecret
        {
            get { return _ApplicationSecret; }
            set
            {
                _ApplicationSecret = value;
                fbContext.AppSecret = value;
            }
        }


        public string AccessToken
        {
            get => fbContext.AccessToken;
            set
            {
                fbContext.AccessToken = value;
            }
        }

        #endregion Properties

        public FacebookContext()
        {
            fbContext = new Facebook.FacebookClient();
        }


        public UserModel GetName(string name = "me")
        {
            try
            {
                var res = fbContext.Get("/" + name).ToString();
                var me = (UserModel)System.Text.Json.JsonSerializer.Deserialize(res, typeof(UserModel));

                return me;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n\nGetMyName() error: {0}\n\n", ex.Message);
            }

            return new UserModel();
        }


        public void Test()
        {

            try
            {
                var user = fbContext.Get("me");
                var friends = fbContext.Get("me/friends");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n\n{0}\n\n",ex.Message);
            }

        }


    }
}
