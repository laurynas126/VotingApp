using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.UserInterfaceAPI;

namespace VotingApp.ConsoleLineInterface
{
    class CLIDialog : IUIDialog
    {
        private string _title;
        private List<string> fieldList = new List<string>();

        public event resultsCreated ResultsCreatedEvent;

        public void AddField(string fieldName)
        {
            fieldList.Add(fieldName);
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        public void Show()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            Console.WriteLine(_title);
            foreach (string field in fieldList)
            {
                Console.Write(field + ": ");
                string value = Console.ReadLine();
                result.Add(field, value);
            }
            ResultsCreatedEvent?.Invoke(result);
            return;
        }
    }
}
