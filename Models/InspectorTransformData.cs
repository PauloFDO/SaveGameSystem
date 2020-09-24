using UnityEditor;
using System;
using UnityEngine;

namespace SaveGameSystem
{
    [Serializable]
    public class InspectorTransformData
    {
        public int GameObjectId;

        public string GameObjectName;

        public string GameObjectTag;

        public SaveGameObjectsEnum GameObjectPoolIndex;

        public Vector3 position;

        public Quaternion rotation;

        public string[] ScriptSalvableData;
    }
}