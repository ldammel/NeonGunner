using Library.Character;
using Library.Events;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class CloseEnemy : MonoBehaviour
    {
        public SpawnCloseEnemies spawn;
        
        [SerializeField] private WaypointMovement mov;
        [SerializeField] private int pointsLossPerSecond;
        [SerializeField] private float baseSpeed;

        private bool _onPoint;

        private void OnDisable()
        {
            _onPoint = false;
            mov.moveSpeed = baseSpeed;
        }

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            if (!_onPoint) return;
            spawn.onPoint = true;
            LevelEnd.Instance.negativeScore -= Mathf.RoundToInt(pointsLossPerSecond  * Time.deltaTime);
            LevelEnd.Instance.totalNegativeScore += Mathf.RoundToInt(pointsLossPerSecond  * Time.deltaTime);
            LevelEnd.Instance.enemiesKilled = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("CloseEnemy")) return;
            _onPoint = true;
            mov.moveSpeed = 0;
        }
    }
}
