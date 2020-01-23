using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
        public Transform point;

        private void Awake()
        {
                point = this.transform;
        }
}
