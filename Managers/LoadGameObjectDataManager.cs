using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
using System;
using Code.Models.Players;
using Code.Managers;

namespace SaveGameSystem
{
    public class LoadGameObjectDataManager : MonoBehaviour
    {
        public static void OnLoad(string SceneName)
        {
            SaveDataModel.current = (SaveDataModel)SerializationManager.Load<SaveDataModel>(SceneName);
            var existingStoredObjects = ReturnExistingSavedObjectsOfScene(SaveDataModel.current.InspectorTransformData);

            LoadDataOnGameObject(existingStoredObjects, SaveDataModel.current.InspectorTransformData);

            SaveDataModel.ResetSavedGameObjectsList();
            Debug.Log("Loaded");
        }

        public static List<GameObject> ReturnExistingSavedObjectsOfScene(IEnumerable<InspectorTransformData> GameObjDataGroupedByTag)
        {
            var existingGameObjectList = new List<GameObject>();
            var savedGameObjectNames = GameObjDataGroupedByTag.Select(x => x.GameObjectName);

            existingGameObjectList.AddRange(Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => savedGameObjectNames.Contains(obj.name)));
            
            return existingGameObjectList;
        }

        private static void LoadDataOnGameObject(List<GameObject> existingSavedObjectsInScene, IEnumerable<InspectorTransformData> gameObjectsData)
        {
            foreach (var gameObjectData in gameObjectsData)
            {
                var existingObject = existingSavedObjectsInScene.SingleOrDefault(x => x.GetInstanceID() == gameObjectData.GameObjectId);

                if (existingObject == null)
                {
                    existingObject = GetObjectFromPoolManager(gameObjectData);

                    if (existingObject == null)
                    {
                        Debug.LogError("Error loading gameobject " + gameObjectData.GameObjectName + " it could not be found, are we missing the prefab in the pool manager?");
                        continue;
                    }
                }

                LoadDataInExistingObject(existingObject, gameObjectData);
            }
        }

        private static GameObject GetObjectFromPoolManager(InspectorTransformData gameObjectData)
        {
            return gameObjectData.GameObjectPoolIndex != SaveGameObjectsEnum.NotADynamicObject
                    ? PoolManager.GetSharedInstance().GetLoadableGameObject((int)gameObjectData.GameObjectPoolIndex) : null;
        }

        private static void LoadDataInExistingObject(GameObject existingGameObject, InspectorTransformData inspectorData)
        {
            existingGameObject.transform.position = inspectorData.position;
            existingGameObject.SetActive(true);

            if (inspectorData.ScriptSalvableData != null)
            {
                var dataType = Type.GetType(inspectorData.ScriptSalvableData[0]);
                TypeToDataModelMapping.LoadSalvableDataFromScript(dataType, existingGameObject, inspectorData.ScriptSalvableData);
            }
        }
    }
}