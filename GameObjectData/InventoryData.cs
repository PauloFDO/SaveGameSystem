using UnityEngine;
using System.Collections;
using Code.Models.Players;
using Code.Models.Interfaces.PlayerInterfaces;
using System.Linq;
using Code.ScriptableObjects.Weapons;
using Code.ScriptableObjects.Collectables;
using Code.ScriptableObjects.Armors;
using Code.ScriptableObjects.Badges;
using Code.ScriptableObjects.Upgrades;
using System.Collections.Generic;
using Newtonsoft.Json;
using Code.Managers;

namespace SaveGameSystem
{
    public class InventoryData : MonoBehaviour
    {
        public static string[] SaveInventoryData(Inventory inventoryScript)
        {
            return new string[]
            {
             inventoryScript.GetType().AssemblyQualifiedName,
             string.Join( ",", inventoryScript.combatWeapons.Select(x=>x.Index))
            };
        }

        public static void LoadInventoryData(string[] dataToLoad, GameObject LoadDataInGameObject)
        {
            //var InventoryPool = GameObject.Find("Inventory Items Pool Manager").GetComponent<InventoryItemsPoolManager>();

            //var weaponsIndex = new List<int>(dataToLoad[1].Split(',').Select(int.Parse).ToList());
            //var getInventoryPoolWeaponsByIndex = InventoryPool.GetAllCombatWeapons().Where(x => weaponsIndex.Contains(x.Index));

            //var inventoryScript = LoadDataInGameObject.GetComponent<Inventory>();
            //inventoryScript.combatWeapons = getInventoryPoolWeaponsByIndex.ToList();

        }
    }
}