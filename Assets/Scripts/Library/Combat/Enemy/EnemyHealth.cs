using System;
using Library.Character;
using Library.Combat.Pooling;
using Library.Data;
using Library.Events;
using TMPro;
using Unity.Mathematics;
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
        public GameObject killText;
        public Transform killTextPoint;

        public AudioSource deathSound;
        public GameObject deathVfx;
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
            LevelEnd.Instance.score += scorePerKill;
            killText.GetComponent<TextMeshPro>().text = scorePerKill.ToString();
            Instantiate(killText, killTextPoint.position, Quaternion.identity);

            if (!deathSound.isPlaying)
            {
                deathSound.Play();
            }
            
            if (iscloseEnemy) SpawnCloseEnemies.Instance.spawnedAmount--;
            Instantiate(deathVfx, transform.position, transform.rotation);
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
