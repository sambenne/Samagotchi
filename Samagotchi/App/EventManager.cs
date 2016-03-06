using System;
using System.Collections.Generic;
using System.Timers;

namespace Samagotchi.App
{
    public class EventManager
    {
        private static int _ticks;
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

        public void StartTimer()
        {
            var timer = new Timer
            {
                Interval = 2000,
                Enabled = true
            };

            timer.Elapsed += OnTimedEvent;
            timer.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs events)
        {
            RunEvents(_ticks);
            _ticks++;
        }
    }
}
