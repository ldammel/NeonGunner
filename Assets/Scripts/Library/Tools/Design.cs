﻿using Library.Character;
using Library.Character.ScriptableObjects;
using Library.Character.Upgrades;
using Library.Combat;
using Library.Combat.Enemy;
using Library.Data;
using UnityEngine;
using Sirenix.OdinInspector;

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
        [TabGroup("Required Objects")]
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        [DetailedInfoBox("Click for Info...",
            "Values: Select the Object you want to Balance (Difficulty). \n\n" +
                    "Once done with balancing, Select the 'SelectedDif' Object to play the game!")]
        [Required()] 
        public WeaponValues values;
        
        [TabGroup("Required Objects")]
        [Tooltip("The Object containing the Currency Informations.")]
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        [Required()]
        public CurrencyObject currency;

        private GameObject _player;
        private EnemyHealth _playerHealth;
        #endregion
        
        #region Player Settings
        [TabGroup("Player Settings")]
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public float playerHealth;
        [TabGroup("Player Settings")]
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public float playerSpeed;
        [TabGroup("Player Settings")]
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public float currencyGainPerEnemy;
        #endregion
        
        #region MG Settings
        [TabGroup("Weapon Settings","MG Base Settings")]
        [GUIColor(1, 0.6f, 0.4f)]
        public float mgDamage;
        [TabGroup("Weapon Settings","MG Base Settings")]
        [GUIColor(1, 0.6f, 0.4f)]
        public float mgRange;
        [TabGroup("Weapon Settings","MG Base Settings")]
        [GUIColor(1, 0.6f, 0.4f)]
        public float mgFireRate;
        [TabGroup("Weapon Settings","MG Base Settings")] 
        [GUIColor(0, 1, 0)]
        public float mgFireRateUpgrade;
        #endregion 
        
        #region Flak Settings
        [TabGroup("Weapon Settings","Flak Base Settings")] 
        [GUIColor(1, 0.6f, 0.4f)]
        public float flakDamage;
        [TabGroup("Weapon Settings","Flak Base Settings")] 
        [GUIColor(1, 0.6f, 0.4f)]
        public float flakRange;
        [TabGroup("Weapon Settings","Flak Base Settings")] 
        [GUIColor(1, 0.6f, 0.4f)]
        public float flakDamageRadius;
        [TabGroup("Weapon Settings","Flak Base Settings")] 
        [GUIColor(1, 0.6f, 0.4f)]
        public float flakFireRate;
        [TabGroup("Weapon Settings","Flak Base Settings")] 
        [GUIColor(0, 1, 0)]
        public float flakFireRateUpgrade;
        [TabGroup("Weapon Settings","Flak Base Settings")] 
        [GUIColor(0, 1, 0)]
        public float flakRadiusUpgrade;
        #endregion
        
        #region Flame Settings
        [TabGroup("Weapon Settings","Flamethrower Base Settings")] 
        [GUIColor(1, 0.6f, 0.4f)]
        public float flameDamage;
        [TabGroup("Weapon Settings","Flamethrower Base Settings")] 
        [GUIColor(1, 0.6f, 0.4f)]
        public float flameRange;
        [TabGroup("Weapon Settings","Flamethrower Base Settings")] 
        [GUIColor(1, 0.6f, 0.4f)]
        public float flameAmmoConsumptionPerSecond;
        [TabGroup("Weapon Settings","Flamethrower Base Settings")] 
        [GUIColor(1, 0.6f, 0.4f)]
        public float flameAmmoRefreshPerSecond;
        [TabGroup("Weapon Settings","Flamethrower Base Settings")] 
        [GUIColor(1, 0.6f, 0.4f)]
        public float flameSpread;
        [TabGroup("Weapon Settings","Flamethrower Base Settings")] 
        [GUIColor(0, 1, 0)]
        public float flameSpreadUpgrade;
        #endregion
        
        #region Flying Enemy Settings
        [TabGroup("Enemy Settings")] 
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public float enemyHealth;
        [TabGroup("Enemy Settings")] 
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public float enemyDamage;
        [TabGroup("Enemy Settings")] 
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public float enemyAttackSpeed;
        [TabGroup("Enemy Settings")] 
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public float enemyMoveSpeed;
        [TabGroup("Enemy Settings")] 
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public float enemyRange;
        #endregion

        [Button("Reset Stats On Scriptable Object",(ButtonSizes.Large))]
        [GUIColor(0.4f, 0.8f, 1)]
        public void ResetStats()
        {
          //----------------- Get Required Components ------------------

          _player = GameObject.FindGameObjectWithTag("Player");
          _playerHealth = _player.GetComponent<EnemyHealth>();

          //---------------Value Initialization---------------------
          _playerHealth.maxHealth = playerHealth;
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
          values.flameAmmoConsumptionPerSecond = flameAmmoConsumptionPerSecond;
          values.flameAmmoRefreshPerSecond = flameAmmoRefreshPerSecond;
          values.enemyDamage = enemyDamage;
          values.enemyHealth = enemyHealth;
          values.enemyMoveSpeed = enemyMoveSpeed;
          values.enemyAttackSpeed = enemyAttackSpeed;
          values.enemyRange = enemyRange;
          values.mgFireRateUpgrade = mgFireRateUpgrade;
          values.flameSpreadUpgrade = flameSpreadUpgrade;
          values.flakRadiusUpgrade = flakRadiusUpgrade;
          values.flakFireRateUpgrade = flakFireRateUpgrade;
        }

        [Button("Reset Progress in Game",(ButtonSizes.Large))]
        [GUIColor(0.4f, 0.8f, 1)]
        public void ResetProgress()
        {
            currency.currentCurrency = 0;
            currency.flakLevel = 0;
            currency.flameLevel = 0;
            currency.mgLevel = 0;
            currency.rocketLevel = 0;
            currency.shrapnelLevel = 0;
            currency.caltropLevel = 0;
            currency.gasLevel = 0;
            currency.laserLevel = 0;
            currency.teslaLevel = 0;
            currency.selectedWeaponOne = 0;
            currency.selectedWeaponTwo = 0;
            currency.selectedSlotTwo = null;
        }
        [Button("Reset Stats in Designer",(ButtonSizes.Large))]
        [GUIColor(0.4f, 0.8f, 1)]
        public void ResetInitialValues()
        {
          mgDamage = values.mgDamage;
          mgRange = values.mgRange;
          mgFireRate =  values.mgFireRate;
          flakDamageRadius = values.flakDamageRadius;
          flakDamage = values.flakDamage;
          flakRange = values.flakRange;
          flakFireRate = values.flakFireRate;
          flameDamage = values.flameDamage;
          flameRange = values.flameRange;
          flameSpread = values.flameSpread;
          flameAmmoConsumptionPerSecond = values.flameAmmoConsumptionPerSecond;
          flameAmmoRefreshPerSecond = values.flameAmmoRefreshPerSecond;
          enemyDamage = values.enemyDamage;
          enemyHealth = values.enemyHealth;
          enemyMoveSpeed = values.enemyMoveSpeed;
          enemyAttackSpeed = values.enemyAttackSpeed;
          enemyRange = values.enemyRange ;
          mgFireRateUpgrade = values.mgFireRateUpgrade;
          flameSpreadUpgrade = values.flameSpreadUpgrade;
          flakRadiusUpgrade = values.flakRadiusUpgrade;
          flakFireRateUpgrade = values.flakFireRateUpgrade;
          currency.currentCurrency = 0;
          currency.flakLevel = 0;
          currency.flameLevel = 0;
          currency.mgLevel = 0;
          currency.rocketLevel = 0;
          currency.shrapnelLevel = 0;
          currency.caltropLevel = 0;
          currency.gasLevel = 0;
          currency.laserLevel = 0;
          currency.teslaLevel = 0;
        }
    }
}
