﻿using System;
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
        
        [HideInInspector] public NavMeshAgent navMeshAgent;
        public List<Transform> wayPointList;
        [HideInInspector] public int nextWayPoint;

        public bool _aiActive;
        [HideInInspector]
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            SetupAI(true, wayPointList);
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
            currentState.UpdateState(this);
        }
    }
}
