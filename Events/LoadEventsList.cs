using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System.Collections.Generic;

namespace SaveGameSystem
{
    public static class LoadEventsList
    {
        private static List<LoadGameEvent> _loadGameEvents;

        public static List<LoadGameEvent> LoadGameEvents
        {
            get
            {
                if (_loadGameEvents == null)
                {
                    _loadGameEvents = new List<LoadGameEvent>();
                }

                return _loadGameEvents;
            }

            set { _loadGameEvents = value; }
        }

        public static void ClearAllExistingEvents()
        {
            LoadGameEvents = new List<LoadGameEvent>();
        }

    }
}