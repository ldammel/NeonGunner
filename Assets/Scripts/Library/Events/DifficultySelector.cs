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
        public WeaponValues easy;
        public WeaponValues medium;
        public WeaponValues hard;

        public GameObject enemyPrefab;

        private WeaponValues _selectedDifficulty;
        private UpgradeManager _manager;
        private Design _design;
        
        private NavMeshAgent _enemyNav;
        private EnemyHealth _enemyHealth;
        private BulletPooled _enemyPool;
        private BulletShot _enemyDamage;

        private void Start()
        {
            _manager = FindObjectOfType<UpgradeManager>();
            _enemyNav = enemyPrefab.GetComponent<NavMeshAgent>();
            _enemyHealth = enemyPrefab.GetComponent<EnemyHealth>();
            _enemyPool = enemyPrefab.GetComponentInChildren<BulletPooled>();
            _enemyDamage = enemyPrefab.GetComponent<BulletShot>();
            _design = FindObjectOfType<Design>();
        }

        public void SelectDifficulty(string difficulty)
        {
            switch (difficulty)
            {
                case "easy":
                    _selectedDifficulty = easy;
                    return;
                case "medium":
                    _selectedDifficulty = medium;
                    return;
                case "hard":
                    _selectedDifficulty = hard;
                    return;
                default:
                    return;
            }
        }

        private void ChangeValues()
        {
            _manager.values = _selectedDifficulty;
            _design.values = _selectedDifficulty;
            
            _enemyHealth.maxHealth = _selectedDifficulty.enemyHealth;
            _enemyDamage.damage = _selectedDifficulty.enemyDamage;
            _enemyNav.speed = _selectedDifficulty.enemyMoveSpeed;
            _enemyPool.fireRate = _selectedDifficulty.enemyAttackSpeed; 
            _enemyNav.stoppingDistance = _selectedDifficulty.enemyRange;
            
        }



    }
}
