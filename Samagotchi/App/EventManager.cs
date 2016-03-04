using System;
using System.Collections.Generic;

namespace Samagotchi.App
{
    public class EventManager
    {
        public Dictionary<string, Action> Events;

        public EventManager()
        {
            Events = new Dictionary<string, Action>();
        }

        public void Add(string name, Action eventFunction)
        {
            Events.Add(name, eventFunction);
        }

        public void RunEvents()
        {
            foreach (var eventFunc in Events)
            {
                eventFunc.Value.Invoke();
            }
        }
    }
}
