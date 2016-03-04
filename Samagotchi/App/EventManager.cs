using System;
using System.Collections.Generic;

namespace Samagotchi.App
{
    public class EventManager
    {
        public Dictionary<string, Action<int>> Events;

        public EventManager()
        {
            Events = new Dictionary<string, Action<int>>();
        }

        public void Add(string name, Action<int> eventFunction)
        {
            Events.Add(name, eventFunction);
        }

        public void RunEvents(int ticks)
        {
            foreach (var eventFunc in Events)
            {
                eventFunc.Value.Invoke(ticks);
            }
        }
    }
}
