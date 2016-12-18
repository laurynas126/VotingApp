using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.VotingSystemAPI;

namespace VotingApp.Adapters
{
    class OptionAdapter : Observer, IObservable<List<string>>, IDisposable
    {
        private List<IObserver<List<string>>> viewObservers = new List<IObserver<List<string>>>();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Notify(NotifyData data)
        {
            List<string> result = new List<string>();
            if (data.IsOpen)
            {
                result.Add("Voting is open");
            }
            else
            {
                result.Add("Voting is closed");
            }
            if (data.ExtraData != "")
            {
                result.Add(data.ExtraData);
            }
            result.Add("Just received " + data.VotesReceived + " votes");
            if (data.IsValidated)
            {
                result.Add("Voting is now officialy VALIDATED!");
            }
            result.Add("Total votes for this option: " + data.TotalVoters);
            NotifyObservers(result);
        }

        public void SetData(Dictionary<string, string> data)
        {
            List<string> result = new List<string>();
            string optionString = data["Data"];
            result.Add(optionString);
            NotifyObservers(result);
        }

        private void NotifyObservers(List<string> data)
        {
            foreach (var observer in viewObservers)
            {
                observer.OnNext(data);
            }
        }

        public IDisposable Subscribe(IObserver<List<string>> observer)
        {
            viewObservers.Add(observer);
            return this;
        }
    }
}
