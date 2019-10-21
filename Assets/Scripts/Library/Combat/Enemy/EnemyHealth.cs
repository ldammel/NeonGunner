using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public int maxHealth = 100;
        public int curHealth = 100;

        public bool player;

        private Vector3 _startPos;
        // Start is called before the first frame update
        void Start()
        {
            _startPos = transform.localPosition;
            curHealth = maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            if (curHealth <= 0)
            {
                if (player)
                {
                    transform.position = _startPos;
                    curHealth = maxHealth;
                }
                else
                {
                    gameObject.SetActive(false);
                    curHealth = maxHealth;
                    transform.localPosition = _startPos;
                }
            }
        }

        public void TakeDamage(int damage)
        {
            curHealth -= damage;
        }
    }
}
