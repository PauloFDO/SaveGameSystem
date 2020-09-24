using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
using System;
using Code.Models.Players;

namespace SaveGameSystem
{
    public class SaveGameObjectDataManager : MonoBehaviour
    {
        public static void OnSave(string SceneneName)
        {
            if (SerializationManager.Save(SaveDataModel.current, SceneneName))
            {
                Debug.Log("data saved");
            }
            else
            {
                Debug.LogError("Something went wrong saving data");
            }
        }     
    }
}