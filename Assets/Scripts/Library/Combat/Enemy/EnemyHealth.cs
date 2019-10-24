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

        private Transform _parent;

        public Waypoint wp;
        // Start is called before the first frame update
        void Start()
        {
            _parent = transform.parent;
            _startPos = transform.localPosition;
            curHealth = maxHealth;
        }

        // Update is called once per frame
        void Update()
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
                    NotificationManager.Instance.SetNewNotification("Killed Enemy");
                    if(wp != null && wp.active) wp.active = false;
                    transform.localPosition = _startPos;
                    transform.parent = _parent;
                    gameObject.GetComponentInChildren<BulletPooled>().canFire = false;
                    curHealth = maxHealth;
                    gameObject.SetActive(false);
                }
            }
        }

        public void TakeDamage(float damage)
        {
            curHealth -= damage;
        }
    }
}
