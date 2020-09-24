using UnityEngine;
using UnityEditor;

namespace SaveGameSystem
{
    public class GOSalvableData
    {
        public static void IdentificationData(GameObject gameObject, InspectorTransformData inspectorData)
        {
            inspectorData.GameObjectId = gameObject.GetInstanceID();
            inspectorData.GameObjectTag = gameObject.tag;
            inspectorData.GameObjectName = gameObject.name;
        }

        public static void MovementData(GameObject gameObject, InspectorTransformData inspectorData)
        {
            inspectorData.position = gameObject.transform.position;
        }
    }
}