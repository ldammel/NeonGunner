using System;
using BansheeGz.BGSpline.Curve;
using Library.Events;
using UnityEngine;

namespace Library.Character
{
    public class WaypointMovement : MonoBehaviour
    {
        public float moveSpeed;
        public float maxSpeed;
        public BGCurve path;
        private bool _active;
        public float reducedSpeed;

        private Rigidbody rb;

        public void Start()
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            rb.isKinematic = PauseMenu.Instance.pauseActive;
            if (PauseMenu.Instance.pauseActive) return;
            if (path == null) return;
        }

        public void SetSpeed(float amount)
        {
            reducedSpeed += amount;
            if (reducedSpeed <= 0) reducedSpeed = 0;
            if (reducedSpeed >= maxSpeed) reducedSpeed = maxSpeed;
        }

    }
}
