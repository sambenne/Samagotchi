using System.Collections.Generic;

namespace Samagotchi.App.Commands
{
    public interface ICommand
    {
        void Do(IList<string> args);
    }
}
