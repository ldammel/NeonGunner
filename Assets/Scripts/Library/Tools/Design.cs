﻿using System;
using Library.Character;
using Library.Character.ScriptableObjects;
using Library.Character.Upgrades;
using Library.Combat;
using Library.Combat.Enemy;
using Library.Combat.Pooling;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.AI;

namespace Library.Tools
{
    public class Design : MonoBehaviour
    {
        public static Design Instance;
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There can only be one instance of Design in this scene!");
                Application.Quit();
            }
            else Instance = this;
        }
        
        #region Script Components

        [Required()] 
        public WeaponValues values;
        [Required()]
        public CurrencyObject currency;
        [Required()]
        public UpgradeManager upgradeObject;
        [Required()]
        public GameObject flakPrefab;
        [Required()]
        public GameObject flyingEnemy;
        [Required()]
        public Flamethrower flame;
        
        private GameObject _player;
        private WaypointMovement _playerSpeed;
        private EnemyHealth _playerHealth;
        private Flak _flak;
        private MachineGun _mg;
        private BulletShot _bullet;
        private BulletPooled _pool;
        
        private NavMeshAgent _enemyNav;
        private EnemyHealth _enemyHealth;
        private BulletPooled _enemyPool;
        private GameObject _enemyBullet;
        private BulletShot _enemyDamage;
        #endregion
        
        #region Player Settings
        
        [BoxGroup("Player Settings")]
        public float playerHealth;
        [BoxGroup("Player Settings")]
        public float playerSpeed;
        [BoxGroup("Player Settings")] 
        public int currencyGainPerEnemy;
        #endregion
        
        #region MG Settings
        [BoxGroup("MG Settings")]
        public float mgDamage;
        [BoxGroup("MG Settings")]
        public float mgRange;
        [BoxGroup("MG Settings")]
        public float mgFireRate;
        
        [BoxGroup("MG Upgrade Settings")] 
        public int mgMaxUpgradeLevel;
        [BoxGroup("MG Upgrade Settings")] 
        public int mgUpgradeCost;
        [BoxGroup("MG Upgrade Settings")] 
        public int mgUpgradeCostMultiplier;
        [BoxGroup("MG Upgrade Settings")] 
        public float mgFireRateUpgrade;
        #endregion
        
        #region Flak Settings
        [BoxGroup("Flak Settings")] 
        public float flakDamage;
        [BoxGroup("Flak Settings")] 
        public float flakRange;
        [BoxGroup("Flak Settings")] 
        public float flakDamageRadius;
        [BoxGroup("Flak Settings")] 
        public float flakFireRate;
        
        [BoxGroup(" Flak Upgrade Settings")] 
        public int flakMaxUpgradeLevel;
        [BoxGroup(" Flak Upgrade Settings")] 
        public int flakUpgradeCost;
        [BoxGroup(" Flak Upgrade Settings")] 
        public int flakUpgradeCostMultiplier;
        [BoxGroup(" Flak Upgrade Settings")] 
        public float flakFireRateUpgrade;
        [BoxGroup(" Flak Upgrade Settings")] 
        public float flakRadiusUpgrade;
        #endregion
        
        #region Flame Settings
        [BoxGroup("Flamethrower Settings")] 
        public float flameDamage;
        [BoxGroup("Flamethrower Settings")] 
        public float flameRange;
        [BoxGroup("Flamethrower Settings")] 
        public float flameMaxAmmo;
        [BoxGroup("Flamethrower Settings")] 
        public float flameAmmoConsumptionPerSecond;
        [BoxGroup("Flamethrower Settings")] 
        public float flameAmmoRefreshPerSecond;
        [BoxGroup("Flamethrower Settings")] 
        public float flameSpread;
        
        [BoxGroup(" Flamethrower Upgrade Settings")] 
        public int flameMaxUpgradeLevel;
        [BoxGroup(" Flamethrower Upgrade Settings")] 
        public int flameUpgradeCost;
        [BoxGroup(" Flamethrower Upgrade Settings")] 
        public int flameUpgradeCostMultiplier;
        [BoxGroup(" Flamethrower Upgrade Settings")] 
        public float flameMaxAmmoUpgrade;
        [BoxGroup(" Flamethrower Upgrade Settings")] 
        public float flameSpreadUpgrade;
        #endregion
        
        #region Flying Enemy Settings
        [BoxGroup("Flying Enemy Settings")] 
        public float enemyHealth;
        [BoxGroup("Flying Enemy Settings")] 
        public float enemyDamage;
        [BoxGroup("Flying Enemy Settings")] 
        public float enemyAttackSpeed;
        [BoxGroup("Flying Enemy Settings")] 
        public float enemyMoveSpeed;
        [BoxGroup("Flying Enemy Settings")] 
        public float enemyRange;
        #endregion

        [Button("Reset Stats")]
        public void ResetStats()
        {
            //--------------- Check if Prefabs are assigned ----------------

            if (flakPrefab == null || flyingEnemy == null || upgradeObject == null)
            {
                Debug.LogError("Please assign Flak, Flame, Upgrade and Enemy Prefab before testing!");
                Application.Quit();
            }

            //----------------- Get Required Components ------------------

            _player = GameObject.FindGameObjectWithTag("Player");
            _playerSpeed = _player.GetComponent<WaypointMovement>();
            _playerHealth = _player.GetComponent<EnemyHealth>();
            _mg = _player.GetComponentInChildren<MachineGun>();
            _flak = flakPrefab.GetComponent<Flak>();
            _bullet = flakPrefab.GetComponent<BulletShot>();
            _pool = _player.GetComponentInChildren<BulletPooled>();
            _enemyNav = flyingEnemy.GetComponent<NavMeshAgent>();
            _enemyHealth = flyingEnemy.GetComponent<EnemyHealth>();
            _enemyPool = flyingEnemy.GetComponentInChildren<BulletPooled>();
            _enemyBullet = flyingEnemy.GetComponent<BulletShotPool>().prefab;
            _enemyDamage = _enemyBullet.GetComponent<BulletShot>();

            //---------------Value Initialization---------------------
            _playerHealth.maxHealth = playerHealth;
            _playerSpeed.speed = playerSpeed;            
            
            values.mgDamage = mgDamage;
            values.mgRange = mgRange;
            values.mgFireRate = mgFireRate;

            values.flakDamageRadius = flakDamageRadius;
            values.flakDamage = flakDamage;;
            values.flakRange = flakRange;;
            values.flakFireRate = flakFireRate;;

            values.flameDamage = flameDamage;
            values.flameRange = flameRange;
            values.flameSpread = flameSpread;
            values.flameMaxAmmo = flameMaxAmmo;
            values.flameAmmoConsumptionPerSecond = flameAmmoConsumptionPerSecond;
            values.flameAmmoRefreshPerSecond = flameAmmoRefreshPerSecond;

            _enemyHealth.maxHealth = enemyHealth;
            _enemyDamage.damage = enemyDamage;
            _enemyNav.speed = enemyMoveSpeed;
            _enemyPool.fireRate = enemyAttackSpeed; 
            _enemyNav.stoppingDistance = enemyRange;

          values.mgMaxUpgradeLevel = mgMaxUpgradeLevel;
          values.mgUpgradeCost = mgUpgradeCost;
          values.mgUpgradeCostMultiplier = mgUpgradeCostMultiplier;
          values.mgFireRateUpgrade = mgFireRateUpgrade;

          values.flameMaxUpgradeLevel = flameMaxUpgradeLevel;
          values.flameUpgradeCost = flameUpgradeCost;
          values.flameUpgradeCostMultiplier = flameUpgradeCostMultiplier;
          values.flameMaxAmmoUpgrade = flameMaxAmmoUpgrade;
          values.flameSpreadUpgrade = flameSpreadUpgrade;
            
          values.flakMaxUpgradeLevel = flakMaxUpgradeLevel;
          values.flakUpgradeCost = flakUpgradeCost;
          values.flakUpgradeCostMultiplier = flakUpgradeCostMultiplier;
          values.flakRadiusUpgrade = flakRadiusUpgrade;
          values.flakFireRateUpgrade = flakFireRateUpgrade;

          currency.currentCurrency = 0;
          currency.flakLevel = 0;
          currency.flameLevel = 0;
          currency.mgLevel = 0;
          currency.flakActive = false;
          currency.flameActive = false;
        }
    }
}
