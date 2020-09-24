using Code.Models.Players;
using Code.Models.Enemies;
using UnityEngine;
using System;
using System.Linq;
using Code.Models.Interfaces.PlayerInterfaces;
using Code.Models;
using Code.Models.Scenarios.Triggers;

namespace SaveGameSystem
{
    public static class TypeToDataModelMapping
    {
        public static string[] GetSalvableDataFromScript(object data)
        {
            if (data.GetType() == typeof(Player))
            {
                return PlayerData.SavePlayerData((Player)data);
            }
            else if (data.GetType() == typeof(AmmunitionContainer))
            {
                return AmmunitionData.SaveAmmunitionData((AmmunitionContainer)data);
            }
            else if (data.GetType() == typeof(StaticElement))
            {
                return StaticElementData.SaveStaticElementDataData((StaticElement)data);
            }
            else if (data.GetType() == typeof(SwitchTrigger))
            {
                return SwitchTriggerData.SaveSwitchTriggerData((SwitchTrigger)data);
            }
            else if (data.GetType() == typeof(Inventory))
            {
                return InventoryData.SaveInventoryData((Inventory)data);
            }

            return null;
        }

        public static void LoadSalvableDataFromScript(Type data, GameObject gameobjectToLoad, string[] dataToLoad)
        {
            if (data == typeof(Player))
            {
                PlayerData.LoadPlayerData(dataToLoad, gameobjectToLoad);
            }
            else if (data == typeof(AmmunitionContainer))
            {
                AmmunitionData.LoadAmmunitionData(dataToLoad, gameobjectToLoad);
            }
            else if (data == typeof(StaticElement))
            {
                StaticElementData.LoadStaticElementDataData(dataToLoad, gameobjectToLoad);
            }
            else if (data == typeof(SwitchTrigger))
            {
                SwitchTriggerData.LoadSwitchTriggerData(dataToLoad, gameobjectToLoad);
            }
            else if (data == typeof(Inventory))
            {
                InventoryData.LoadInventoryData(dataToLoad, gameobjectToLoad);
            }
        }
    }
}