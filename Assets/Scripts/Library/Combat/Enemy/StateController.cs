using System;
using System.Collections.Generic;
using System.Linq;
using Library.AI;
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

        private bool _aiActive;

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
        }

        private void Update()
        {
            if (!_aiActive) return;
            var go = GameObject.FindGameObjectsWithTag("FarPoint");
            for (int i = 0; i < wayPointList.Count; i++)
            {
                for (int j = 0; j < go.Length; j++)
                {
                    if (!wayPointList.Contains(go[j].transform))
                    {
                        wayPointList[i] = go[j].transform;
                    }
                }
            }
            currentState.UpdateState(this);
        }

        private void OnDrawGizmos()
        {
            if (currentState != null && eyes != null)
            {
                Gizmos.color = currentState.sceneGizmoColor;
                Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
            }
        }
    }
}
