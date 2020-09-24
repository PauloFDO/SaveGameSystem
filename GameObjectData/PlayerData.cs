using UnityEngine;
using System.Collections;
using Code.Models.Players;

namespace SaveGameSystem
{
    public class PlayerData : MonoBehaviour
    {
        public static string[] SavePlayerData(Player playerScript)
        {
            return new string[]
            {
             playerScript.GetType().AssemblyQualifiedName,
             playerScript.CurrentHealth.ToString(),
             playerScript.CurrentDarkEnergy.ToString()
            };
        }

        public static void LoadPlayerData(string[] dataToLoad, GameObject LoadDataInGameObject)
        {
            var Playercomponent = LoadDataInGameObject.GetComponent<Player>();

            Playercomponent.CurrentHealth = float.Parse(dataToLoad[1]);
            Playercomponent.CurrentDarkEnergy = float.Parse(dataToLoad[2]);
        }
    }
}