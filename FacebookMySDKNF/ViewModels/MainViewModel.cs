using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookMySDKNF.Data;
using FacebookMySDKNF.Resources;
using FacebookMySDKNF.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace FacebookMySDKNF.ViewModels
{
    internal class MainViewModel : BindableBase
    {

        #region Properties

        public string WndTitle { get; set; } = "My Fucking Title";



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

               var fbClient = new FacebookClient(10);
               var fbService = new FacebookService(fbClient);
               
               try
               {
                   var res = fbService.GetAccountAsync(FacebookSettings.AccessToken);

               }
               catch (Exception ex)
               {
                   System.Windows.MessageBox.Show(ex.Message);
               }

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
