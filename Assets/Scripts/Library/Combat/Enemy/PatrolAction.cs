using Library.AI;
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
            controller.navMeshAgent.enabled = !PauseMenu.Instance.pauseActive;
            if (!controller.navMeshAgent.enabled) return;
            controller.navMeshAgent.isStopped = PauseMenu.Instance.pauseActive;
            controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;

            if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
            {
                if (controller.wayPointList[controller.nextWayPoint].gameObject.GetComponent<Waypoint>().active)
                {
                    controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
                }
                else
                {
                    controller.gameObject.transform.parent = controller.wayPointList[controller.nextWayPoint];
                    controller.gameObject.transform.position = controller.wayPointList[controller.nextWayPoint].position;
                    controller.navMeshAgent.enabled = false;
                    controller.gameObject.GetComponentInChildren<BulletPooled>().canFire = true;
                    controller.wayPointList[controller.nextWayPoint].gameObject.GetComponent<Waypoint>().active = true;
                    controller.eh.wp = controller.wayPointList[controller.nextWayPoint].gameObject.GetComponent<Waypoint>();
                    controller.enabled = false;
                }
            }
        }
    }
}