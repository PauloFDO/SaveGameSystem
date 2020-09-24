using UnityEngine;
using UnityEditor;
using Code.Models.Scenarios.Triggers;
using Code.Services;
using Code.Configuration;
using Code.States.Scenarios;
using Code.States;
using Code.Models.Players;
using UnityEngine.SceneManagement;

namespace SaveGameSystem
{
    public class LoadTrigger : Trigger
    {
        private Scene scene;

        public void LoadTest()
        {
            PropagateTriggerEvents();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            var collisionTag = ObjectService.GetTag(collision);
            var playeranimator = collision.gameObject.GetComponent<Player>().Animator;

            var runningAnimation = AnimationService.GetAnimationName(playeranimator) == AnimationName.ACTIVATE 
                || AnimationService.GetAnimationName(playeranimator) == AnimationName.COLLECT;

            if (TagName.PLAYER == collisionTag && runningAnimation)
            {
                    PropagateAllSaveEvents.DisableSave();
                    PropagateTriggerEvents();
                    Invoke("SwitchSaveAfterSeconds", 3);
            }
        }

        private void SwitchSaveAfterSeconds()
        {
            PropagateAllSaveEvents.EnableSave();
        }

        public override void PropagateTriggerEvents()
        {
            TriggerEventChannels.PropagateMessageEvent(CurrentMessage, MessageTime);
            PropagateAllLoadEvents.Load(SceneManager.GetActiveScene().name);
        }
    }
}