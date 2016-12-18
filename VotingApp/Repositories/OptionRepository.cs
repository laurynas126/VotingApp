using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.VotingSystemAPI;

namespace VotingApp.Repositories
{
    public class OptionRepository
    {
        public Dictionary<string, Option> OptionDict { get; }
        public OptionRepository()
        {
            OptionDict = new Dictionary<string, Option>();
        }
    }
}
