using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTransitionPoint : MonoBehaviour
{
        public Transform point;

        private void Start()
        {
                point = transform;
        }
}
