using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingApp.CommandAPI;
using VotingApp.Commands;
using VotingApp.ConsoleLineInterface;
using VotingApp.ControllerAPI;
using VotingApp.GraphicalUserInterface;
using VotingApp.ParliamentaryPoll;
using VotingApp.PollCommands;
using VotingApp.ReferendumPoll;
using VotingApp.Repositories;
using VotingApp.UserInterfaceAPI;
using VotingApp.VotingSystemAPI;

namespace VotingApp
{
    class Program
    {
        static IUnityContainer container;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            container = new UnityContainer();
            ContainerUtility.Register(container, new GUIFactory(), new ReferendumFactory());
            var controller = container.Resolve<IController>();
            container.BuildUp(controller, "Init");
            controller.Start();
        }
    }
}
