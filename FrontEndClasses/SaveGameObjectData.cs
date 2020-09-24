using Code.Models;
using Code.Models.Enemies;
using Code.Models.Interfaces.PlayerInterfaces;
using Code.Models.Players;
using Code.Models.Scenarios.Triggers;
using SaveGameSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaveGameSystem
{ 
    public class SaveGameObjectData : MonoBehaviour
    {
        List<Type> salvableScripts = new List<Type>();

        [Tooltip("If the object needs to be loaded from the pool manager (for dynamic objects)")]
        public SaveGameObjectsEnum GameObjectPoolIndex = SaveGameObjectsEnum.NotADynamicObject;

        public void Start()
        {
            salvableScripts.Add(typeof(Player));
            salvableScripts.Add(typeof(AmmunitionContainer));
            salvableScripts.Add(typeof(Enemy));
            salvableScripts.Add(typeof(StaticElement));
            salvableScripts.Add(typeof(SwitchTrigger));
            salvableScripts.Add(typeof(Inventory));

            var saveEvent = new CreateSaveEvent(salvableScripts, gameObject);
            saveEvent.CreateEvent();

            var loadEvent = new CreateLoadEvent(gameObject);
            loadEvent.CreateEvent();
        }
    }
}
