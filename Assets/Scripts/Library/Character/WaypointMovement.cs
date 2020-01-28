using System;
using System.Runtime.InteropServices;
using Library.Combat.Enemy;
using Library.Events;
using UnityEngine;

namespace Library.Character
{
    public class WaypointMovement : MonoBehaviour
    {
        public float moveSpeed;
        public float maxSpeed;

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            gameObject.transform.Translate(0,0,moveSpeed * Time.deltaTime);
        }
    }
}
