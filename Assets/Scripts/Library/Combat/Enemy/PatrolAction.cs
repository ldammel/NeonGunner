using Library.AI;
using Library.Character;
using Library.Combat.Pooling;
using Library.Events;
using UnityEngine;

namespace Library.Combat.Enemy
{
    [CreateAssetMenu(fileName = "Patrol", menuName = "AI/Actions/Patrol")]
    public class PatrolAction : Action
    {
        public override void Act(StateController controller)
        {
            Patrol(controller);
        }

        private void Patrol(StateController controller)
        {
            if (!controller.navMeshAgent.enabled || PauseMenu.Instance.pauseActive) return;
            
            controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
            
            if (!(controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance) || controller.navMeshAgent.pathPending) return;
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
    }
}