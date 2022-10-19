using FacebookCore.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TemplateMVVM_CV19.Infrastructure.Commands;


using System.Linq;
using System.Windows.Data;
using Prism.Mvvm;
using Prism.Commands;


namespace FacebookCore.ViewModels
{
    //[System.Windows.Markup.MarkupExtensionReturnType(typeof(MainViewModel))] -- 
    internal class MainViewModel : BindableBase
    {

        #region Properties


        #region Title - Заголовок окна
        private string _WndTitle = "MainViewTitle";
        public string WndTitle { get => _WndTitle; set => SetProperty(ref _WndTitle, value); }
        #endregion Title



        #endregion Properties



        #region Commands






        #region DelegateCommand:TestCommand
        private DelegateCommand _TestCommand;
        public DelegateCommand TestCommand
        {
            get => _TestCommand ??= new DelegateCommand(() =>
            {
                //your code
                //System.Windows.MessageBox.Show("OK");



                string appId = "1184643042148110";
                string appSecret = "79d6879d74d983bb86c32df3d742fb56";


               
                }, () => true);
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