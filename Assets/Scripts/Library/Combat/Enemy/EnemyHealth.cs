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

        private Transform _parent;
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
                if (player)
                {
                    transform.position = _startPos;
                    curHealth = maxHealth;
                }
                else
                {
                    curHealth = maxHealth;
                    transform.localPosition = _startPos;
                    transform.parent = _parent;
                    gameObject.SetActive(false);
                }
            }
        }

        public void TakeDamage(int damage)
        {
            curHealth -= damage;
        }
    }
}
