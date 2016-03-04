using System.Collections.Generic;
using Samagotchi.App.Commands;

namespace Samagotchi.App.Helpers
{
    public class Command
    {
        public Command()
        {
            Args = new List<string>();
        }
        public string Action { get; set; }
        public ICommand Commander { get; set; }
        public List<string> Args { get; set; }
    }
}