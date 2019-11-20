using System;
using System.Collections.Generic;
using System.Linq;
using Library.AI;
using Library.Character;
using Library.Events;
using UnityEngine;
using UnityEngine.AI;

namespace Library.Combat.Enemy
{
    public class StateController : MonoBehaviour
    {
        public State currentState;
        public EnemyStats enemyStats;
        public Transform eyes;

        public EnemyHealth eh;
        [HideInInspector] public NavMeshAgent navMeshAgent;
        public List<Transform> wayPointList;
        [HideInInspector] public int nextWayPoint;
        public string waypointName;
        public bool isMelee;

        public bool _aiActive;
        [HideInInspector]
        public bool setSpeed;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            SetupAI(true, wayPointList);
            eh = gameObject.GetComponent<EnemyHealth>();
        }

        public void SetupAI(bool aiActivation, List<Transform> wayPoints)
        {
            wayPointList = wayPoints;
            _aiActive = aiActivation;
            navMeshAgent.enabled = _aiActive;
            setSpeed = false;
        }

        private void Update()
        {
            if (!_aiActive) return;
            var go = GameObject.FindGameObjectsWithTag(waypointName);
            for (int i = 0; i < wayPointList.Count; i++)
            {
                foreach (var t in go)
                {
                    if (!wayPointList.Contains(t.transform))
                    {
                        wayPointList[i] = t.transform;
                    }
                }
            }
            currentState.UpdateState(this);
        }

        private void OnDrawGizmos()
        {
            if (currentState == null || eyes == null) return;
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }
}
