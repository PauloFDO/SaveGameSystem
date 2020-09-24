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
    public class SaveTrigger : Trigger
    {
        private Scene scene;

        public void SaveTest()
        {
            PropagateAllSaveEvents.EnableSave();
            PropagateTriggerEvents();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            var collisionTag = ObjectService.GetTag(collision);

            var playerOnSavePosition = TagName.PLAYER == collisionTag && UserIsExecutingSaveAnimation(collision);

            if (playerOnSavePosition && PropagateAllSaveEvents.AllowSave)
            {
                PropagateTriggerEvents();
                PropagateAllSaveEvents.DisableSave();
            }
            else if (TagName.PLAYER == collisionTag && !UserIsExecutingSaveAnimation(collision))
            {
                PropagateAllSaveEvents.EnableSave();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            var collisionTag = ObjectService.GetTag(collision);

            if (TagName.PLAYER == collisionTag)
            {
                PropagateAllSaveEvents.EnableSave();
            }
        }

        private bool UserIsExecutingSaveAnimation(Collision2D collision)
        {
            var playeranimator = collision.gameObject.GetComponent<Player>().Animator;
            return AnimationService.GetAnimationName(playeranimator) == AnimationName.ACTIVATE || AnimationService.GetAnimationName(playeranimator) == AnimationName.COLLECT;
        }

        public override void PropagateTriggerEvents()
        {
            TriggerEventChannels.PropagateMessageEvent(CurrentMessage, MessageTime);
            PropagateAllSaveEvents.Save(SceneManager.GetActiveScene().name);
        }
    }
}