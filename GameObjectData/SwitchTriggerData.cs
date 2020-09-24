using UnityEngine;
using System.Collections;
using Code.Models.Players;
using Code.Models.Scenarios.Triggers;
using System;

namespace SaveGameSystem
{
    public class SwitchTriggerData : MonoBehaviour
    {
        public static string[] SaveSwitchTriggerData(SwitchTrigger SwitchTriggerScript)
        {
            return new string[]
            {
             SwitchTriggerScript.GetType().AssemblyQualifiedName,
             //SwitchTriggerScript.Active.ToString()
            };
        }

        public static void LoadSwitchTriggerData(string[] dataToLoad, GameObject LoadDataInGameObject)
        {
            var SwitchTriggerScript = LoadDataInGameObject.GetComponent<SwitchTrigger>();
            //SwitchTriggerScript.Active = Convert.ToBoolean(dataToLoad[1]);
        }
    }
}