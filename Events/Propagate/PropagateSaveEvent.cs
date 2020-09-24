using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace SaveGameSystem
{
    public class PropagateSaveEvent
    {
        List<Type> _salvableScripts;
        GameObject _gameObject;

        public PropagateSaveEvent(List<Type> salvableScripts, GameObject gameObj)
        {
            _salvableScripts = salvableScripts;
            _gameObject = gameObj;
        }

        public void ExecuteSaveEvent()
        {
            foreach (var item in _salvableScripts)
            {
                var componentWithDataToSave = _gameObject.GetComponent(item);
                if (componentWithDataToSave != null)
                {
                    var scriptData = TypeToDataModelMapping.GetSalvableDataFromScript(componentWithDataToSave);
                    StoreAllSalvableData(scriptData);
                }
            }
        }

        private void StoreAllSalvableData(string[] scriptData)
        {
            var inspectorData = new InspectorTransformData();
            inspectorData.ScriptSalvableData = scriptData;
            inspectorData.GameObjectPoolIndex = _gameObject.GetComponent<SaveGameObjectData>().GameObjectPoolIndex;
            GOSalvableData.IdentificationData(_gameObject, inspectorData);
            GOSalvableData.MovementData(_gameObject, inspectorData);
            SaveDataModel.current.InspectorTransformData.Add(inspectorData);
        }
    }
}