using System;
using System.Collections;
using System.Collections.Generic;
using Library.AI;
using Library.Combat.Pooling;
using Library.UI;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public float maxHealth = 100;
        public float curHealth = 100;

        public bool player;

        private Vector3 _startPos;

        public Waypoint wp;
        
        public event Action<float> OnHealthPctChanged = delegate{  };    
        
        private void Start()
        {
            curHealth = maxHealth;
        }

        // Update is called once per frame
        private void Update()
        {
            if (curHealth <= 0)
            {
                curHealth = 0;
                if (player)
                {
                    transform.position = _startPos;
                    curHealth = maxHealth;
                }
                else
                {
                    NotificationManager.Instance.SetNewNotification("Killed Enemy", 3);
                    if(wp != null && wp.active) wp.active = false;
                    EnemySpawnController.killedEnemies++;
                    EnemySpawnController.totalKills++;
                    Destroy(gameObject);
                }
            }
        }

        public void TakeDamage(float damage)
        {
            curHealth -= damage;
            float currentHealthPct = curHealth / maxHealth;
            OnHealthPctChanged(currentHealthPct);
        }
    }
}
