using System;
using Library.Character;
using Library.Events;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class CloseEnemy : MonoBehaviour
    {
        [SerializeField] private WaypointMovement mov;
        [SerializeField] private int pointsLossPerSecond;
        [SerializeField] private float baseSpeed;

        private bool _onPoint;

        private void Update()
        {
            if (!_onPoint) return;
            LevelEnd.Instance.score -= Mathf.RoundToInt((pointsLossPerSecond * (SpawnNextPatternManager.Instance.levelNumber/2)) * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("CloseEnemy")) return;
            mov.moveSpeed = 0;
            _onPoint = true;
        }

        private void OnTriggerExit(Collider other)
        {
            mov.moveSpeed = baseSpeed;
            _onPoint = false;
        }
    }
}
