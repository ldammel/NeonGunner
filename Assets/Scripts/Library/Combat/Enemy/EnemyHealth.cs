using System;
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

        public AudioSource deathSound;
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

            if (!deathSound.isPlaying)
            {
                deathSound.Play();
            }
            
            gameObject.GetComponent<EnemyPooled>().ReturnToPool();
            curHealth = maxHealth;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("PlayerRear")) return;
            GameObject.Find("---PLAYER---/Player").GetComponent<EnemyHealth>().TakeDamage(10);
            LevelEnd.Instance.enemiesMissed++;
            gameObject.GetComponent<EnemyPooled>().ReturnToPool();
        }

        private void PlayerDeath()
        {
            PauseMenu.Instance.pauseActive = true;
            LevelManager.Instance.failScreen.SetActive(true);
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
