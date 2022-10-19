using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookNF.Data;
using FacebookNF.Models;
using Prism.Commands;
using Prism.Mvvm;

using FacebookSharp;
using FacebookSharp.Winforms;
using System.Diagnostics;

namespace FacebookNF.ViewModels
{
    internal class MainViewModel : BindableBase
    {

        #region Properties

        const string appId = "1184643042148110";
        const string appSecret = "79d6879d74d983bb86c32df3d742fb56";

        #region User:WndTitle - Заголовок окна
        private UserModel _WndTitle;
        public UserModel WndTitle { get => _WndTitle; set => SetProperty(ref _WndTitle, value); }
        #endregion User:WndTitle

        #region FacebookContext:fbCtx - FacebookContext
        private FacebookContext _fbCtx;
        public FacebookContext fbCtx { get => _fbCtx; set => SetProperty(ref _fbCtx, value); }

        private FacebookAuthModel _FacebookAuth;
        public FacebookAuthModel FacebookAuth
        {
            get { return _FacebookAuth; }
            set { _FacebookAuth = value; }
        }


        public FacebookSharp.Facebook fbSharp { get; set; }

        #endregion FacebookContext:fbCtx



        #region string:SearchedUser - Ник искомого пользователя
        private string _SearchedUser;
        public string SearchedUser { get => _SearchedUser; set => SetProperty(ref _SearchedUser, value); }
        #endregion string:SearchedUser


        #region User:FoundUser - Найденный пользователь
        private UserModel _FoundUser;
        public UserModel FoundUser { get => _FoundUser; set => SetProperty(ref _FoundUser, value); }
        #endregion User:FoundUser






        #endregion Properties



        #region Commands



        #region DelegateCommand:TestCommand
        private DelegateCommand _TestCommand;
        public DelegateCommand TestCommand
        {
            get => _TestCommand ?? (_TestCommand = new DelegateCommand(() =>
           {


               //TestSharp();
               TestFacebookSDK();


           }, () => true));
        }
        #endregion DelegateCommand:TestCommand


        #endregion Commands



        #region Constructors
        public MainViewModel()
        {
            if (!App.IsDesignMode)
                GetFacebookAccessToken();

            if (!App.IsDesignMode && FacebookAuth != null && FacebookAuth.access_token.Length > 1)
                CreateFacebookSDK();

            if (!App.IsDesignMode && FacebookAuth != null && FacebookAuth.access_token.Length > 1)
                CreateFacebookSharp();
        }

        #endregion Constructors



        #region Methods

        public void GetFacebookAccessToken()
        {
            string http = string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri=http://localhost&type=user_agent&display=popup", appId);
            var wnd = new FacebookNF.Views.ConnectView();
            wnd.Url = http;
            try
            {
                wnd.ShowDialog();
                //if(wnd.DlgResult == System.Windows.Forms.DialogResult.OK)
                FacebookAuth = wnd.Auth;

            }
            catch (Exception ex)
            {
                fbCtx.AccessToken = string.Empty;
                System.Windows.MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Ошбика подключения!", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            finally
            {
                wnd.Close();
            }


            if (FacebookAuth == null || FacebookAuth.access_token.Length <= 1)
            {
                System.Windows.MessageBox.Show("Не удалось подключиться к ФБ. Попробуй еще)");
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void CreateFacebookSDK()
        {
            fbCtx = new FacebookContext()
            {
                AccessToken = FacebookAuth.access_token,
                ApplicationID = appId,
                ApplicationSecret = appSecret
            };
        }

        private void TestFacebookSDK()
        {
            try
            {
                fbCtx.Test();
            }
            catch (Exception ex)
            {

                Debug.Write(ex.Message);
            }
        }



        private void CreateFacebookSharp()
        {

            //FacebookSettings fbSettings = new FacebookSettings { ApplicationKey = appId, ApplicationSecret = appSecret };
            FacebookSettings fbSettings = new FacebookSettings { ApplicationKey = appId, AccessToken = FacebookAuth.access_token, AccessExpires = FacebookAuth.expires_in, ApplicationSecret = appSecret };
            fbSettings.DefaultApplicationPermissions = new[] { "email", "public_profile", "publish_to_groups", "publish_video", "user_birthday", "user_friends", "user_gender", "user_likes",
                                                                "offline_access", "publish_stream","user_about_me","user_events", "user_groups", "user_hometown", "user_interests",
                                                                "user_photos", "user_religion_politics", "user_status",  "user_work_history"};
            FacebookLoginForm fbLoginDlg = new FacebookLoginForm(fbSettings);



            #region WinFormAuth
            //try
            //{
            //    FacebookAuthenticationResult fbAuthResult;
            //    if (fbLoginDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        System.Windows.Forms.MessageBox.Show("You are logged in.");
            //        fbAuthResult = fbLoginDlg.FacebookAuthenticationResult;
            //        string txtAccessToken = fbAuthResult.AccessToken;
            //        string txtExpiresIn = fbAuthResult.ExpiresIn.ToString();
            //    }
            //    else
            //    {
            //        System.Windows.Forms.MessageBox.Show("You must login inorder to access Facebook features.");
            //        //fbAuthResult = fbLoginDlg.FacebookAuthenticationResult;
            //        //System.Windows.Forms.MessageBox.Show(fbAuthResult.ErrorReasonText);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //    throw;
            //}

            #endregion WinFormAuth



            fbSharp = new FacebookSharp.Facebook(fbSettings);
            fbSharp.Settings.DefaultApplicationPermissions = new[] { "email", "public_profile", "publish_to_groups", "publish_video", "user_birthday", "user_friends", "user_gender",
                                                                "user_likes","offline_access", "publish_stream","user_about_me","user_events", "user_groups", "user_hometown",
                                                                "user_interests","user_photos", "user_religion_politics", "user_status",  "user_work_history", "user_messenger_contact"};

            try
            {
                var res = fbSharp.Get<FacebookSharp.Schemas.Graph.User>("me");
                WndTitle = new UserModel
                {
                    id = res.ID,
                    name = res.Name
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }



        }


        private void TestSharp()
        {

            try
            {
                var me = fbSharp.Get<FacebookSharp.Schemas.Graph.User>("/me");
                var friendListData = fbSharp.Get("/me/friends");
            }
            catch (Exception ex)
            {

                Debug.Write(ex.Message);
            }

        }

        #endregion Methods

    }
}
