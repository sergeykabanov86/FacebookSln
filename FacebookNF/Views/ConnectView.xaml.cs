using FacebookNF.Models;
using System;
using System.Windows;
using System.Windows.Controls;


namespace FacebookNF.Views
{
    /// <summary>
    /// Логика взаимодействия для ConnectView.xaml
    /// </summary>
    public partial class ConnectView : Window
    {
        #region Properties

        public string Url { get; set; }

        public FacebookAuthModel Auth { get; set; } = new FacebookAuthModel();

        //public System.Windows.Forms.DialogResult DlgResult { get; set; } = System.Windows.Forms.DialogResult.Cancel;

        #endregion Properties


        public ConnectView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(Url);
        }

        private void WebBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void WebBrowser_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {

            if(e.Uri.Fragment.Contains("access_token"))
            {
                var results = e.Uri.Fragment.Split('&');
                Auth.access_token = results[0].Split('=')[1];
                Auth.data_access_expiration_time = long.Parse( results[1].Split('=')[1]);
                Auth.expires_in = long.Parse(results[2].Split('=')[1]);
                //DlgResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

      
    }
}
