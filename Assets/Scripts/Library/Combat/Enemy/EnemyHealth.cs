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

        public BulletPooled pool;
        
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

            if (!deathSound.isPlaying)
            {
                deathSound.Play();
            }

            pool.enabled = false;
            Destroy(gameObject);
        }

        private void PlayerDeath()
        {
            PauseMenu.Instance.pauseActive = true;
            LevelManager.Instance.failScreen.SetActive(true);
            LevelEnd.Instance.CalculateReward(1);
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
