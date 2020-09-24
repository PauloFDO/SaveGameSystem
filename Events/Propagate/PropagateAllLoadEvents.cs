using UnityEngine;
using System.Collections;

namespace SaveGameSystem
{
    public static class PropagateAllLoadEvents
    {
        public static void Load(string SceneName)
        {
            foreach (var loadEvent in LoadEventsList.LoadGameEvents)
            {
                loadEvent.Invoke();
            }

            LoadGameObjectDataManager.OnLoad(SceneName);
        }
    }
}