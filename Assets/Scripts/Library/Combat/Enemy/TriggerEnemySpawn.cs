using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class TriggerEnemySpawn : MonoBehaviour
    {
        [SerializeField] private bool usePathLeft;
        [SerializeField] private bool usePathRight;
        [SerializeField] private bool usePathUpLeft;
        [SerializeField] private bool usePathUpRight;

        [ShowIf("usePathLeft")]
        [SerializeField] private float[] timeBetweenSpawnsPathLeft;
        [ShowIf("usePathRight")]
        [SerializeField] private float[] timeBetweenSpawnsPathRight;
        [ShowIf("usePathUpLeft")]
        [SerializeField] private float[] timeBetweenSpawnsPathUpLeft;
        [ShowIf("usePathUpRight")]
        [SerializeField] private float[] timeBetweenSpawnsPathUpRight;

        private WaypointManager _manager;

        private void Start()
        {
            _manager = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<WaypointManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (usePathLeft)
            {
                _manager.TriggerSpawn(1,timeBetweenSpawnsPathLeft);
            }
            if (usePathRight)
            {
                _manager.TriggerSpawn(2,timeBetweenSpawnsPathRight);
            }
            if (usePathUpLeft)
            {
                _manager.TriggerSpawn(3,timeBetweenSpawnsPathUpLeft);
            }
            if (usePathUpRight)
            {
                _manager.TriggerSpawn(4,timeBetweenSpawnsPathUpRight);
            }
            gameObject.SetActive(false);
        }
    }
}
