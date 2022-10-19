using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Prism.Commands;
using Prism.Mvvm;

namespace FacebookParserNF.ViewModels
{
    internal class MainViewModel : BindableBase
    {

        #region Properties


        public string WndTitle
        {
            get {
                var assemblyInfo = Assembly.GetExecutingAssembly().GetName();
                return string.Format("{0} (ver. {1})", assemblyInfo.Name, assemblyInfo.Version);
            }
        }




        #endregion Properties



        #region Commands



        #region DelegateCommand:TestCommand
        private DelegateCommand _TestCommand;
        public DelegateCommand TestCommand
        {
            get => _TestCommand ?? (_TestCommand = new DelegateCommand(() =>
           {
               //your code

               //System.Windows.MessageBox.Show("OK");

               var connectToFacebookView = new FacebookParserNF.Views.Popups.ConnectToFacebookView();
               connectToFacebookView.ShowDialog();

           }, () => true));
        }
        #endregion DelegateCommand:TestCommand


        #endregion Commands



        #region Constructors
        public MainViewModel()
        {

        }

        #endregion Constructors



        #region Methods

        #endregion Methods

    }
}
