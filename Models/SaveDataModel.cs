using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

namespace SaveGameSystem
{
    [Serializable]
    public class SaveDataModel
    {
        private static SaveDataModel _current;

        public static SaveDataModel current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SaveDataModel();
                    _current.InspectorTransformData = new List<InspectorTransformData>();
                }

                return _current;
            }

            set { _current = value; }
        }

        public List<InspectorTransformData> InspectorTransformData;

        public static void ResetSavedGameObjectsList()
        {
            current.InspectorTransformData = new List<InspectorTransformData>();
        }
    }
}