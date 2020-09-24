using UnityEngine;
using System.Collections;

namespace SaveGameSystem
{
    public static class PropagateAllSaveEvents
    {
        public static bool AllowSave;

        public static void Save(string SceneName)
        {
            if (AllowSave)
            {
                foreach (var savedEvent in SaveEventsList.SavedGameEvents)
                {
                    savedEvent.Invoke();
                }

                SaveGameObjectDataManager.OnSave(SceneName);
            }
        }

        public static void EnableSave()
        {
            PropagateAllSaveEvents.AllowSave = true;
        }

        public static void DisableSave()
        {
            PropagateAllSaveEvents.AllowSave = false;
        }
    }
}