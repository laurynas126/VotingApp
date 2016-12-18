using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.VotingSystemAPI;

namespace VotingApp.Adapters
{
    class VotingAdapter : Observer, IObservable<List<string>>, IDisposable
    {
        private List<IObserver<List<string>>> viewObservers = new List<IObserver<List<string>>>();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Notify(NotifyData data)
        {
            List<string> result = new List<string>();
            if (data.ExtraData.Contains("STARTED"))
            {
                result.Add("Voting has just started!");
            }
            else if (data.IsOpen)
            {
                result.Add("Voting is open");
                if (data.VotesReceived != -1)
                {
                    result.Add("Option " + data.OptionName + " received " + data.VotesReceived + " votes");
                }
            }
            else
            {
                result.Add("Voting is closed");
            }
            if (data.IsValidated)
            {
                result.Add("Voting is now officialy validated!");
            }
            result.Add("Total/Eligible votes: " + data.TotalVoters + "/" + data.EligibleVoters);
            NotifyObservers(result);
        }

        public void SetData(Dictionary<string, string> data)
        {
            List<string> result = new List<string>();
            bool IsOpen = bool.Parse(data["Has Started"]);
            if (IsOpen)
            {
                result.Add("Voting is open");
            }
            else result.Add("Voting is closed");
            string voteinfo = "Total/Eligible votes: " + data["Total Votes"] + "/" + data["Eligible Voters"];
            result.Add(voteinfo);
            NotifyObservers(result);
        }

        private void NotifyObservers(List<string> data)
        {
            foreach(var observer in viewObservers)
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
