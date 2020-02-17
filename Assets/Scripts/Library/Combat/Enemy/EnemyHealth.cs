using System;
using Library.Combat.Pooling;
using Library.Data;
using Library.Events;
using TMPro;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public float curHealth = 100;
        public float maxHealth = 100;
        public event Action<float> OnHealthPctChanged = delegate{  };
        
        [SerializeField] private bool player;
        [SerializeField] private int scorePerKill;
        [SerializeField] private GameObject killText;
        [SerializeField] private Transform killTextPoint;
        [SerializeField] private GameObject deathVfx;
        [SerializeField] private bool isCloseEnemy;
        
        private int _scoreMultiplier;
        private TextMeshPro _textMeshPro;
        private EnemyPooled _enemyPooled;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody>();
            _enemyPooled = gameObject.GetComponent<EnemyPooled>();
            if(killText != null)_textMeshPro = killText.GetComponentInChildren<TextMeshPro>();
            if (PlayerPrefs.GetString("Difficulty") == "Easy")
            {
                _scoreMultiplier = 1;
            }
            else if (PlayerPrefs.GetString("Difficulty") == "Medium")
            {
                _scoreMultiplier = 2;
            }
            else if (PlayerPrefs.GetString("Difficulty") == "Hard")
            {
                _scoreMultiplier = 4;
            }
            curHealth = maxHealth;
        }
        private void EnemyDeath()
        {
            LevelEnd.Instance.enemiesKilled++;
            LevelEnd.Instance.score += scorePerKill * _scoreMultiplier;
            _textMeshPro.text = (scorePerKill * _scoreMultiplier).ToString();
            Instantiate(killText, killTextPoint.position, Quaternion.identity);

            if (isCloseEnemy) SpawnCloseEnemies.Instance.spawnedAmount--;
            Instantiate(deathVfx, transform.position, transform.rotation);
            _enemyPooled.ReturnToPool();
            curHealth = maxHealth;
        }

        private void PlayerDeath()
        {
            PauseMenu.Instance.pauseActive = true;
            LevelManager.Instance.winScreen.SetActive(true);
            LevelEnd.Instance.CalculateReward();
            _rigidbody.isKinematic = true;
            curHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            curHealth -= damage;
            var currentHealthPct = curHealth / maxHealth;
            OnHealthPctChanged(currentHealthPct);
            if (curHealth > 0) return;
            if(player) PlayerDeath();
            else EnemyDeath();
        }
    }
}
