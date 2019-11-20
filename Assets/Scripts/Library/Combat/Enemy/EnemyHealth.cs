using System;
using System.Collections;
using System.Collections.Generic;
using Library.AI;
using Library.Character.Upgrades;
using Library.Combat.Pooling;
using Library.Data;
using Library.Events;
using Library.UI;
using UnityEngine;
using UnityEngine.AI;

namespace Library.Combat.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public float maxHealth = 100;
        public float curHealth = 100;

        public bool player;

        private Vector3 _startPos;

        public Waypoint wp;

        public bool godMode;

        public GameObject deathSound;

        public event Action<float> OnHealthPctChanged = delegate{  };    
        
        private void Start()
        {
            _startPos = transform.position;
            curHealth = maxHealth;
        }
        
        private void Update()
        {
            if (godMode)
            {
                curHealth = maxHealth;
            }

            if (curHealth <= 0)
            {
                curHealth = 0;
                if (player)
                {
                    PauseMenu.Instance.pauseActive = true;
                    LevelManager.Instance.failScreen.SetActive(true);
                    LevelEnd.Instance.CalculateReward(1);
                    curHealth = 1;
                }
                else
                {
                    if(wp != null && wp.active) wp.active = false;
                    EnemySpawnController.killedEnemies++;
                    EnemySpawnController.totalKills++;
                    Instantiate(deathSound);
                    Destroy(gameObject);
                }
            }
        }

        public void TakeDamage(float damage)
        {
            curHealth -= damage;
            var currentHealthPct = curHealth / maxHealth;
            OnHealthPctChanged(currentHealthPct);
        }
    }
}
