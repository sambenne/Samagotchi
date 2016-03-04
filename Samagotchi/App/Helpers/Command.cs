using System.Collections.Generic;
using Samagotchi.App.Actions;

namespace Samagotchi.App.Helpers
{
    public class Command
    {
        public Command()
        {
            Args = new List<string>();
        }
        public IAction Action { get; set; }
        public List<string> Args { get; set; }
    }
}