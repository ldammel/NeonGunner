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
        public WaypointMovement _mov;
        public override void Act(StateController controller)
        {
            Patrol(controller);
        }

        private void Patrol(StateController controller)
        {
            controller.navMeshAgent.enabled = !PauseMenu.Instance.pauseActive;
            if (!controller.navMeshAgent.enabled) return;
            
            controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
            
            if (!(controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance) || controller.navMeshAgent.pathPending) return;
            if (controller.wayPointList[controller.nextWayPoint].gameObject.GetComponent<Waypoint>().isWaypointActive)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            }
            else
            {
                if (!controller.isMelee)
                {
                    controller.gameObject.GetComponentInChildren<BulletPooled>().canFire = true;
                    controller.wayPointList[controller.nextWayPoint].gameObject.GetComponent<Waypoint>().isWaypointActive = true;
                    controller.eh.wp = controller.wayPointList[controller.nextWayPoint].gameObject.GetComponent<Waypoint>();
                }
                else
                {
                    if (!controller.setSpeed)
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<WaypointMovement>().SetSpeed(-1);
                    }
                    controller.gameObject.transform.parent = controller.wayPointList[controller.nextWayPoint];
                    controller.gameObject.transform.position = controller.wayPointList[controller.nextWayPoint].position;
                    controller.wayPointList[controller.nextWayPoint].gameObject.GetComponent<Waypoint>().isWaypointActive = true;
                    controller.eh.wp = controller.wayPointList[controller.nextWayPoint].gameObject.GetComponent<Waypoint>();
                    controller.navMeshAgent.enabled = false;
                    controller.enabled = false;
                }
            }
        }
    }
}