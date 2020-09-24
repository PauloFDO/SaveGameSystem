using UnityEngine;
using System.Collections;

namespace SaveGameSystem
{
    public class PropagateLoadEvent : MonoBehaviour
    {
        GameObject _gameObject;

        public PropagateLoadEvent(GameObject gameObj)
        {
            _gameObject = gameObj;
        }

        public void LoadEvent()
        {
            if (_gameObject.GetComponent<SaveGameObjectData>().GameObjectPoolIndex != SaveGameObjectsEnum.NotADynamicObject)
            {
                _gameObject.SetActive(false);
            }
        }
    }
}