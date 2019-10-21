using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int curHealth = 100;
        // Start is called before the first frame update
        void Start()
        {
            curHealth = maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            if (curHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        public void TakeDamage(int damage)
        {
            curHealth -= damage;
        }
    }
}
