using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.ControllerAPI;
using VotingApp.UserInterfaceAPI;

namespace VotingApp.ConsoleLineInterface
{
    class CLIFactory : IUIFactory
    {
        public IController CreateController()
        {
            return new CLIController();
        }

        public IUIDialog CreateDialog(string title, params string[] fields)
        {
            CLIDialog dialog = new CLIDialog();
            dialog.SetTitle(title);
            foreach(string field in fields)
            {
                dialog.AddField(field);
            }
            return dialog;
        }

        public IUIDataView CreateDataView()
        {
            CLIDataView view = new CLIDataView();
            return view;
        }
    }
}
