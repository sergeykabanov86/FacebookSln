using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookMySDKNF.Infrastructure.Commands
{
    class CloseAppliactionCommand : Prism.Commands.DelegateCommandBase
    {
        protected override bool CanExecute(object parameter) => true;

        protected override void Execute(object parameter) => System.Windows.Application.Current.Shutdown();
    }
}
