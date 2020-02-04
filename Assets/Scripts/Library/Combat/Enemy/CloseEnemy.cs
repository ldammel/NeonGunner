using Library.Character;
using Library.Events;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class CloseEnemy : MonoBehaviour
    {
        [SerializeField] private WaypointMovement mov;
        public SpawnCloseEnemies spawn;
        [SerializeField] private int pointsLossPerSecond;
        [SerializeField] private float baseSpeed;

        private bool _onPoint;
        private bool _blinking;

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
        }

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.CompareTag("shield")) gameObject.GetComponent<EnemyHealth>().TakeDamage(100);
            if (!other.CompareTag("CloseEnemy")) return;
            mov.moveSpeed = 0;
            _onPoint = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("CloseEnemy")) return;
            mov.moveSpeed = baseSpeed;
            _onPoint = false;
        }

    }
}
