using CefSharp.Wpf;
using FacebookParserNF.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Linq;

namespace FacebookParserNF.Views.Popups
{
    /// <summary>
    /// Логика взаимодействия для ConnectToFacebookView.xaml
    /// var cookies = await Cef.GetGlobalCookieManager().VisitAllCookiesAsync();
    /// </summary>
    public partial class ConnectToFacebookView : Window
    {
        private const string _url = "https://www.facebook.com/";

        System.Windows.Threading.DispatcherTimer _timer = new System.Windows.Threading.DispatcherTimer();

        public List<CefSharp.Cookie> CookiesList { get; set; }
        public string CookiesString { get; set; }


        public ConnectToFacebookView()
        {
            CefInit();
            TimerInit();
            InitializeComponent();

            cefBrowser.Address = _url; 
        }

        private void TimerInit()
        {
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {

            Debug.WriteLine("\n\ntimer_Tick click\n\n");
            var domain = ".facebook.com";

            var visitor = new CookieCollector();
            CefSharp.Cef.GetGlobalCookieManager().VisitUrlCookies(_url, true, visitor);
            var cookies = visitor.Task.Result.Where(x => x.Domain == domain);

            if (cookies.Where(x => x.Name == "c_user").SingleOrDefault() != null)
            {
                CookiesList = new List<CefSharp.Cookie>(cookies);
                CookiesString = CookieCollector.GetCookieHeader(cookies.ToList());
                this.Close();
            }

            return;
        }

        public static void CefInit()
        {
            //var cefSettings = new CefSettings();
            //cefSettings.LogSeverity = CefSharp.LogSeverity.Verbose;
            //var cashPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache");
            //cefSettings.CachePath = cashPath;
            //System.Diagnostics.Debug.WriteLine($"\n\nCachePath: {cashPath}\n\n");
            //CefSharp.Cef.Initialize(cefSettings);
        }

      

    
    }
}
