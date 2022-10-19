using FacebookMySDKCore.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TemplateMVVM_CV19.Infrastructure.Commands;
using System.Linq;
using System.Windows.Data;
using Prism.Commands;
using FacebookMySDKCore.Data;
using FacebookMySDKCore.Services;
using FacebookMySDKCore.Resources;
using System.Threading.Tasks;

namespace FacebookMySDKCore.ViewModels
{
    //[System.Windows.Markup.MarkupExtensionReturnType(typeof(MainViewModel))] -- 
    internal class MainViewModel : Prism.Mvvm.BindableBase
    {

        #region Properties


        #region Title - Заголовок окна
        private string _WndTitle = "My Facebook SDK";
        public string WndTitle { get => _WndTitle; set => SetProperty(ref _WndTitle, value); }
        #endregion Title


        private bool _TestCommand2IsActive = false;
        public bool TestCommand2IsActive
        {
            get { return _TestCommand2IsActive; }
            set {
                _TestCommand2IsActive = value;
                Test2Command.RaiseCanExecuteChanged();
            }
        }



        #endregion Properties



        #region Commands



        #region DelegateCommand:TestCommand
        private DelegateCommand _TestCommand;
        public DelegateCommand TestCommand
        {
            get => _TestCommand ??= new DelegateCommand(() =>
            {
                //your code
                //System.Windows.MessageBox.Show("Test");
                //TestCommand2IsActive = !TestCommand2IsActive;

                var facebookClient = new FacebookClient(1);
                var facebookService = new FacebookService(facebookClient);

                try
                {
                    var accountTask = facebookService.GetAccountAsync(FacebookSettings.AccessToken);
                    Task.WaitAll(accountTask);
                    var account = accountTask.Result;
                }
                catch (Exception ex)
                {

                    System.Windows.MessageBox.Show(ex.Message, "Error get a Account info", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                

            }, () => true);
        }
        #endregion DelegateCommand:TestCommand




        #region DelegateCommand:Test2Command
        private DelegateCommand _Test2Command;
        public DelegateCommand Test2Command
        {
            get => _Test2Command ??= new DelegateCommand(() =>
            {
                //your code
                System.Windows.MessageBox.Show("Test2");
            }, () => TestCommand2IsActive);
        }
        #endregion DelegateCommand:Test2Command



        #endregion Commands



        #region Constructors
        public MainViewModel()
        {
            TestCommand2IsActive = false;
        }
        #endregion Constructors



        #region Methods




        #endregion Methods

    }
}