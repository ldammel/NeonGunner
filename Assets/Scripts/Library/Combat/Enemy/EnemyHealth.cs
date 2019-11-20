using System;
using System.Collections;
using System.Collections.Generic;
using Library.AI;
using Library.Character;
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
            if(player)
            {
                if (gameObject.GetComponent<WaypointMovement>().speed <= 0 || curHealth <= 0)
                {
                    PlayerDeath();
                }
            }
            if (!(curHealth <= 0) || player) return;
            curHealth = 0;
            if(wp != null && wp.active) wp.active = false;
            if (gameObject.GetComponent<StateController>().setSpeed)
            {
                ResetSpeed();
            }

            EnemySpawnController.killedEnemies++;
            EnemySpawnController.totalKills++;
            Instantiate(deathSound);
            Destroy(gameObject);
        }

        private void PlayerDeath()
        {
            gameObject.GetComponent<WaypointMovement>().speed = 4;
            curHealth = maxHealth;
            PauseMenu.Instance.pauseActive = true;
            LevelManager.Instance.failScreen.SetActive(true);
            LevelEnd.Instance.CalculateReward(1);
        }

        public void TakeDamage(float damage)
        {
            curHealth -= damage;
            var currentHealthPct = curHealth / maxHealth;
            OnHealthPctChanged(currentHealthPct);
        }

        private void ResetSpeed()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<WaypointMovement>().speed += 1;
        }
    }
}
