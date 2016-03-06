using System.Collections.Generic;
using Samagotchi.App.Helpers;

namespace Samagotchi.App.Actions
{
    public interface IAction
    {
        void Register(Commands commands, EventManager events);
        bool CanRun();
        void Do(IList<string> args);
        string Name();
    }
}
