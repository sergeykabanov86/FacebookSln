using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FacebookMySDKNF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesignMode { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;

            base.OnStartup(e);
        }
    }
}
