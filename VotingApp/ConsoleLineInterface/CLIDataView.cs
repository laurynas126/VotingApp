using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.UserInterfaceAPI;

namespace VotingApp.ConsoleLineInterface
{
    class CLIDataView : IUIDataView
    {
        private Dictionary<string, string> data;
        private string _title;

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(List<string> value)
        {
            Console.WriteLine();
            Console.WriteLine("----------" + _title + "----------");
            foreach (var element in value)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
        }

        public void SetData(Dictionary<string, string> data)
        {
            this.data = data;
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        public void Show()
        {
            //Console.WriteLine();
            //Console.WriteLine("----------" + _title + "----------");
            //foreach(var element in data)
            //{
            //    Console.WriteLine(element.Key + ": " + element.Value);
            //}
            //Console.WriteLine();
        }
    }
}
