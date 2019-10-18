using UnityEngine;
using UnityEngine.AI;
using PathCreation;

namespace Library.Character
{
    public class WaypointMovement : MonoBehaviour
    {
        public float speed;
        public PathCreator path;
        private NavMeshAgent _agent;
        //public static Waypoint NWaypoint { get; set; }
        //public Waypoint initial;
        private float dist;
        void Start()
        {
            //NWaypoint = initial;
            _agent = GetComponent<NavMeshAgent>();
        }
        
        void Update()
        {
            dist += speed * Time.deltaTime; 
            _agent.destination = path.path.GetPointAtDistance(dist);//NWaypoint.point;
            _agent.isStopped = false;
        }
        
        
    }
}
