using UnityEngine;
using System.Collections;
using Code.Models.Players;
using Code.Models.Interfaces.PlayerInterfaces;

namespace SaveGameSystem
{
    public class AmmunitionData : MonoBehaviour
    {
        public static string[] SaveAmmunitionData(AmmunitionContainer ammunitionScript)
        {
            return new string[]
            {
             ammunitionScript.GetType().AssemblyQualifiedName,
             ammunitionScript.CurrentAmmunition.ToString()
            };
        }

        public static void LoadAmmunitionData(string[] dataToLoad, GameObject LoadDataInGameObject)
        {
            var AmmunitionComponent = LoadDataInGameObject.GetComponent<AmmunitionContainer>();
            AmmunitionComponent.CurrentAmmunition = int.Parse(dataToLoad[1]);
            AmmunitionComponent.UpdateDisplayedAmmunition();
        }
    }
}