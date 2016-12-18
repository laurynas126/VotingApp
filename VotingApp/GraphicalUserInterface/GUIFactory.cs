using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.ControllerAPI;
using VotingApp.UserInterfaceAPI;

namespace VotingApp.GraphicalUserInterface
{
    class GUIFactory : IUIFactory
    {
        public IController CreateController()
        {
            return new GUIController();
        }

        public IUIDialog CreateDialog(string title, params string[] fields)
        {
            GUIDialog dialog = new GUIDialog();
            dialog.SetTitle(title);
            foreach (string field in fields)
            {
                dialog.AddField(field);
            }
            return dialog;
        }

        public IUIDataView CreateDataView()
        {
            GUIDataView form = new GUIDataView();
            return form;
        }
    }
}
