using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.ControllerAPI;

namespace VotingApp.UserInterfaceAPI
{
    interface IUIFactory
    {
        IController CreateController();
        IUIDataView CreateDataView();
        //UIListView CreateListView();
        IUIDialog CreateDialog(string title, params string[] fields);

    }
}
