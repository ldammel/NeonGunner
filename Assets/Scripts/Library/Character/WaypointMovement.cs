using System;
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

        public void Start()
        {
            if (path != null)
            {
                path.pathUpdated += OnPathChanged;
            }
        }

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            if (path == null) return;
            dist += speed * Time.deltaTime; 
            transform.position = path.path.GetPointAtDistance(dist);
            transform.rotation = path.path.GetRotationAtDistance(dist, endOfPathInstruction);
            if (Math.Abs(transform.rotation.z) > 0)
            {
                transform.Rotate(0,0,90);
            }
        }
        public void OnPathChanged() {
            dist = path.path.GetClosestDistanceAlongPath(transform.position);
        }
        
    }
}
