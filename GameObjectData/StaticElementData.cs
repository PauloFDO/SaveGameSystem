using UnityEngine;
using System.Collections;
using Code.Models.Players;
using Code.Models.Interfaces.PlayerInterfaces;
using Code.Models;
using Code.States.StaticElementsStates;
using System;

namespace SaveGameSystem
{
    public class StaticElementData : MonoBehaviour
    {
        public static string[] SaveStaticElementDataData(StaticElement StaticElementScript)
        {
            return new string[]
            {
             StaticElementScript.GetType().AssemblyQualifiedName,
             StaticElementScript.gameObject.activeInHierarchy.ToString()
            };
        }

        public static void LoadStaticElementDataData(string[] dataToLoad, GameObject LoadDataInGameObject)
        {
            var StaticElementScript = LoadDataInGameObject.GetComponent<StaticElement>();
            StaticElementScript.gameObject.SetActive(Convert.ToBoolean(dataToLoad[1]));
        }
    }
}