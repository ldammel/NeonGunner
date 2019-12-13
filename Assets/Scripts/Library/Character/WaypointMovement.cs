using System;
using Library.Events;
using UnityEngine;
using UnityEngine.AI;
using PathCreation;

namespace Library.Character
{
    public class WaypointMovement : MonoBehaviour
    {
        public float moveSpeed;
        public float maxSpeed;
        public PathCreator path;
        public EndOfPathInstruction endOfPathInstruction;
        public float currentDistance;
        private bool _active;
        public float reducedSpeed;

        private Rigidbody rb;

        public void Start()
        {
            reducedSpeed = moveSpeed;
            moveSpeed = 3;
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
            currentDistance += moveSpeed * Time.deltaTime; 
            transform.position = path.path.GetPointAtDistance(currentDistance);
            transform.rotation = path.path.GetRotationAtDistance(currentDistance, endOfPathInstruction);
            if (Math.Abs(transform.rotation.z) > 0)
            {
                transform.Rotate(0,0,90);
            }
            if(moveSpeed > reducedSpeed)
            {
                moveSpeed -= 1f * Time.deltaTime;
            }
            else if (moveSpeed < reducedSpeed)
            {
                moveSpeed += 1f * Time.deltaTime;
            }
            
        }
        public void OnPathChanged() {
            currentDistance = path.path.GetClosestDistanceAlongPath(transform.position);
        }

        public void SetSpeed(float amount)
        {
            reducedSpeed += amount;
            if (reducedSpeed <= 0) reducedSpeed = 0;
            if (reducedSpeed >= maxSpeed) reducedSpeed = maxSpeed;
        }

    }
}
