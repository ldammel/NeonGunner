using System;
using Library.Character.ScriptableObjects;
using Library.Character.Upgrades;
using Library.Combat;
using Library.Combat.Enemy;
using Library.Combat.Pooling;
using Library.Tools;
using UnityEngine;
using UnityEngine.AI;

namespace Library.Events
{
    public class DifficultySelector : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public GameObject enemyBulletObj;

        public WeaponValues selectedDifficulty;

        private NavMeshAgent _enemyNav;
        private EnemyHealth _enemyHealth;
        private BulletPooled _enemyPool;
        private BulletShot _enemyDamage;

        private void Start()
        {
            _enemyNav = enemyPrefab.GetComponent<NavMeshAgent>();
            _enemyHealth = enemyPrefab.GetComponent<EnemyHealth>();
            _enemyPool = enemyPrefab.GetComponentInChildren<BulletPooled>();
            _enemyDamage = enemyBulletObj.GetComponent<BulletShot>();
            ChangeValues();
        }

        private void ChangeValues()
        {
            _enemyHealth.maxHealth = selectedDifficulty.enemyHealth;
            _enemyDamage.damage = selectedDifficulty.enemyDamage;
            _enemyNav.speed = selectedDifficulty.enemyMoveSpeed;
            _enemyPool.fireRate = selectedDifficulty.enemyAttackSpeed; 
            _enemyNav.stoppingDistance = selectedDifficulty.enemyRange;
        }
    }
}
