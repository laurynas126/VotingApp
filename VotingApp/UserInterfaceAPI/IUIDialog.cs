using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.UserInterfaceAPI
{
    public delegate void resultsCreated(Dictionary<string, string> result);

    interface IUIDialog
    {
        event resultsCreated ResultsCreatedEvent;//Dialog results are returned as dictionary object: key - label, value - user answer
        void Show();
        void SetTitle(string title);
        void AddField(string fieldName);
    }
}
