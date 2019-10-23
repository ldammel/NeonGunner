using System;
using Library.Character;
using Library.Combat.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace Library.AI
{
    public class Waypoint : MonoBehaviour
    {
        public bool active;
        public GameObject pointObj;

        private void Start()
        {
            active = false;
            pointObj = gameObject;
        }
    }
}
