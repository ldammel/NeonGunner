using Library.Events;
using UnityEngine;
using UnityEngine.AI;
using PathCreation;

namespace Library.Character
{
    public class WaypointMovement : MonoBehaviour
    {
        public float speed;
        public PathCreator path;
        public EndOfPathInstruction endOfPathInstruction;
        public float dist;
        private bool _active;
        void Start()
        {
            if (path != null)
            {
                path.pathUpdated += OnPathChanged;
            }
        }
        
        void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            if (path == null) return;
            dist += speed * Time.deltaTime; 
            transform.position = path.path.GetPointAtDistance(dist);
            transform.rotation = path.path.GetRotationAtDistance(dist, endOfPathInstruction);
            if (transform.rotation.z != 0)
            {
                transform.Rotate(0,0,90);
            }
        }
        public void OnPathChanged() {
            dist = path.path.GetClosestDistanceAlongPath(transform.position);
        }
        
    }
}
