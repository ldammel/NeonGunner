using System;
using Library.Character;
using Library.Combat.Pooling;
using Library.Data;
using Library.Events;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public float maxHealth = 100;
        public float curHealth = 100;

        public bool player;

        public bool godMode;

        public int scorePerKill;

        public AudioSource deathSound;
        public bool iscloseEnemy;
        public event Action<float> OnHealthPctChanged = delegate{  };

        private void Start()
        {
            deathSound = GameObject.Find("---PLAYER---/Sounds/DeathSound").GetComponent<AudioSource>();
            curHealth = maxHealth;
        }
        
        private void Update()
        {
            if (godMode)
            {
                curHealth = maxHealth;
            }
            if(player)
            {
                if (curHealth <= 0)
                {
                    PlayerDeath();
                }
            }
            if (!(curHealth <= 0) || player) return;
            curHealth = 1;
            LevelEnd.Instance.enemiesKilled++;
            LevelEnd.Instance.score += Mathf.RoundToInt(scorePerKill * (SpawnNextPatternManager.Instance.levelNumber / 2));
            WaveMovement.Instance.UpdatePosition(Mathf.RoundToInt(scorePerKill * (SpawnNextPatternManager.Instance.levelNumber / 2)));

            if (!deathSound.isPlaying)
            {
                deathSound.Play();
            }
            
            if (iscloseEnemy) SpawnCloseEnemies.Instance.spawnedAmount--;
            gameObject.GetComponent<EnemyPooled>().ReturnToPool();
            curHealth = maxHealth;
        }

        private void PlayerDeath()
        {
            PauseMenu.Instance.pauseActive = true;
            LevelManager.Instance.winScreen.SetActive(true);
            LevelEnd.Instance.CalculateReward();
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            curHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            curHealth -= damage;
            var currentHealthPct = curHealth / maxHealth;
            OnHealthPctChanged(currentHealthPct);
        }
    }
}
