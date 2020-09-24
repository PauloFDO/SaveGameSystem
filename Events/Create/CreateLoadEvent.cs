using UnityEngine;
using System.Collections;

namespace SaveGameSystem
{
    public class CreateLoadEvent : MonoBehaviour
    {
        GameObject _gameObject;

        public CreateLoadEvent(GameObject gameObj)
        {
            _gameObject = gameObj;
        }

        public void CreateEvent()
        {
            var propagateEvent = new PropagateLoadEvent(_gameObject);
            var gameObjLoadEvent = new LoadGameEvent();
            gameObjLoadEvent.AddListener(propagateEvent.LoadEvent);
            LoadEventsList.LoadGameEvents.Add(gameObjLoadEvent);
        }
    }
}