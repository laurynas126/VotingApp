using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.UserInterfaceAPI
{
    interface IUIDataView : IObserver<List<string>>
    {
        void Show();
        void SetTitle(string title);
        void SetData(Dictionary<string, string> data);
    }
}
