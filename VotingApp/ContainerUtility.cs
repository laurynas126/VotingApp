using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VotingApp.CommandAPI;
using VotingApp.Commands;
using VotingApp.ControllerAPI;
using VotingApp.GraphicalUserInterface;
using VotingApp.Localization;
using VotingApp.ParliamentaryPoll;
using VotingApp.PollCommands;
using VotingApp.ReferendumPoll;
using VotingApp.Repositories;
using VotingApp.UserInterfaceAPI;
using VotingApp.VotingSystemAPI;

namespace VotingApp
{
    static class ContainerUtility
    {
        public static void Register(IUnityContainer container, IUIFactory factory, IPollFactory pollfactory)
        {
            //Register UI Factory instance
            container.RegisterInstance<IUIFactory>(factory);

            //Register Poll Factory instance
            container.RegisterInstance<IPollFactory>(pollfactory);

            //Register repository instances
            container.RegisterInstance(new VotingRepository())
                .RegisterInstance(new OptionRepository());

            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromAllInterfacesInSameAssembly,
                WithName.TypeName);

            //Register processor
            container.RegisterInstance<ICommandProcessor>(new CommandProcessor());
            
            //Register commands
            container.RegisterType<CreatePollCommand>(new InjectionProperty("Title", Constants.CreatePoll));
            container.RegisterType<AddOptionCommand>(new InjectionConstructor(
                Constants.AddOption, 
                typeof(IUIFactory), 
                typeof(IPollFactory), 
                typeof(VotingRepository), 
                typeof(OptionRepository)));
            container.RegisterType<AddVotesCommand>(new InjectionConstructor(
                Constants.AddVotes, 
                typeof(IUIFactory), 
                typeof(IPollFactory), 
                typeof(VotingRepository)));
            container.RegisterType<EndVotingCommand>(new InjectionConstructor(
                Constants.EndVoting, 
                typeof(IUIFactory), 
                typeof(VotingRepository)));
            container.RegisterType<StartVotingCommand>(new InjectionConstructor(
                Constants.StartVoting, 
                typeof(IUIFactory), 
                typeof(VotingRepository)));
            container.RegisterType<ShowVotingCommand>(new InjectionConstructor(
                Constants.ShowVoting, 
                typeof(IUIFactory), 
                typeof(VotingRepository)));
            container.RegisterType<ShowOptionCommand>(new InjectionConstructor(
                Constants.ShowOption, 
                typeof(IUIFactory), 
                typeof(OptionRepository)));
            container.RegisterType<UndoCommand>(new InjectionConstructor(
                Constants.Undo, 
                typeof(ICommandProcessor)));

            //Register list of commands
            container.RegisterType<IList<ICommand>, List<ICommand>>(new InjectionConstructor(), 
                new InjectionMethod("Add", typeof(CreatePollCommand)),
                new InjectionMethod("Add", typeof(AddOptionCommand)),
                new InjectionMethod("Add", typeof(StartVotingCommand)),
                new InjectionMethod("Add", typeof(EndVotingCommand)),
                new InjectionMethod("Add", typeof(AddVotesCommand)),
                new InjectionMethod("Add", typeof(ShowVotingCommand)),
                new InjectionMethod("Add", typeof(ShowOptionCommand)),
                new InjectionMethod("Add", typeof(UndoCommand)));

            var list = container.Resolve<IList<ICommand>>();
            //Register controller
            container.RegisterType<IController>(new InjectionFactory(c => c.Resolve<IUIFactory>().CreateController()),
                new InjectionMethod("SetCommandProcessor", new ResolvedParameter(typeof(ICommandProcessor))))
                .RegisterType<IController>("Init",
                new InjectionMethod("SetCommandProcessor", typeof(ICommandProcessor)),
                new InjectionMethod("AddCommands", typeof(IList<ICommand>)));
        }
    }
}
