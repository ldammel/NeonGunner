using System;
using Library.Character;
using Library.Combat.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace Library.AI
{
    public class Waypoint : MonoBehaviour
    {
        public bool isWaypointActive;
        public GameObject thisWaypointObject;

        private void Start()
        {
            isWaypointActive = false;
            thisWaypointObject = gameObject;
        }
    }
}
