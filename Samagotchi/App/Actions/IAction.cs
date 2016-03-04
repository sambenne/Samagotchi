using System.Collections.Generic;

namespace Samagotchi.App.Actions
{
    public interface IAction
    {
        bool CanRun();
        void Do(IList<string> args);
        string Name();
    }
}
