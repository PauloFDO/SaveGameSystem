using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System.Collections.Generic;

namespace SaveGameSystem
{
    public static class SaveEventsList
    {
        private static List<SaveGameEvent> _savedGameEvents;

        public static List<SaveGameEvent> SavedGameEvents
        {
            get
            {
                if (_savedGameEvents == null)
                {
                    _savedGameEvents = new List<SaveGameEvent>();
                }

                return _savedGameEvents;
            }

            set { _savedGameEvents = value; }
        }

        public static void ClearAllExistingEvents()
        {
            SavedGameEvents = new List<SaveGameEvent>();
        }
    }
}