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
        public float maxSpeed;
        public PathCreator path;
        public EndOfPathInstruction endOfPathInstruction;
        public float dist;
        private bool _active;
        public float reducedSpeed;

        private Rigidbody rb;

        public void Start()
        {
            reducedSpeed = speed;
            speed = 3;
            if (path != null)
            {
                path.pathUpdated += OnPathChanged;
            }
            rb = gameObject.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            rb.isKinematic = PauseMenu.Instance.pauseActive;
            if (PauseMenu.Instance.pauseActive) return;
            if (path == null) return;
            dist += speed * Time.deltaTime; 
            transform.position = path.path.GetPointAtDistance(dist);
            transform.rotation = path.path.GetRotationAtDistance(dist, endOfPathInstruction);
            if (Math.Abs(transform.rotation.z) > 0)
            {
                transform.Rotate(0,0,90);
            }
            if(speed > reducedSpeed)
            {
                speed -= 1f * Time.deltaTime;
            }
            else if (speed < reducedSpeed)
            {
                speed += 1f * Time.deltaTime;
            }
            
        }
        public void OnPathChanged() {
            dist = path.path.GetClosestDistanceAlongPath(transform.position);
        }

        public void SetSpeed(float amount)
        {
            reducedSpeed += amount;
            if (reducedSpeed <= 0) reducedSpeed = 0;
            if (reducedSpeed >= maxSpeed) reducedSpeed = maxSpeed;
        }

    }
}
