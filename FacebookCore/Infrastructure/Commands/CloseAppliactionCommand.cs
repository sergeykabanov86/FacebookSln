using System;
using System.Collections.Generic;
using System.Text;
using TemplateMVVM_CV19.Infrastructure.Commands.Base;

namespace FacebookCore.Infrastructure.Commands
{
    internal class CloseAppliactionCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => System.Windows.Application.Current.Shutdown();
    }
}
