using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace SaveGameSystem
{
    public class CreateSaveEvent
    {
        List<Type> _salvableScripts;
        GameObject _gameObject;


        public CreateSaveEvent(List<Type> salvableScripts, GameObject gameObj)
        {
            _salvableScripts = salvableScripts;
            _gameObject = gameObj;
        }

        public void CreateEvent()
        {
            var PropagateSaveEvent = new PropagateSaveEvent(_salvableScripts, _gameObject);
            var gameObjSaveEvent = new SaveGameEvent();
            gameObjSaveEvent.AddListener(PropagateSaveEvent.ExecuteSaveEvent);
            SaveEventsList.SavedGameEvents.Add(gameObjSaveEvent);
        }
    }
}