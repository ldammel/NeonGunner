﻿using System;
using Library.Character.ScriptableObjects;
using UnityEngine;


namespace Library.Events
{
    public class SelectDifficulty : MonoBehaviour
    {
        public WeaponValues value;

        public void SelectDif(WeaponValues values)
        {
           value.mgDamage = values.mgDamage;
           value.mgRange = values.mgRange;

           value.flakDamage = values.flakDamage;

           value.flameDamage = values.flameDamage;
           value.flameAmmoConsumptionPerSecond = values.flameAmmoConsumptionPerSecond;
           value.flameAmmoRefreshPerSecond = values.flameAmmoRefreshPerSecond;

           value.enemyDamage = values.enemyDamage;
           value.enemyHealth = values.enemyHealth;
           value.enemyMoveSpeed = values.enemyMoveSpeed;
           value.enemyAttackSpeed = values.enemyAttackSpeed;
           value.enemyRange = values.enemyRange ;

           value.mgMaxUpgradeLevel = values.mgMaxUpgradeLevel ;
           value.mgUpgradeCostMultiplier = values.mgUpgradeCostMultiplier;
           value.mgFireRateUpgrade = values.mgFireRateUpgrade;

           value.flameMaxUpgradeLevel = values.flameMaxUpgradeLevel;
           value.flameUpgradeCostMultiplier = values.flameUpgradeCostMultiplier;
           value.flameMaxAmmoUpgrade = values.flameMaxAmmoUpgrade;
           value.flameSpreadUpgrade = values.flameSpreadUpgrade;

           value.flakMaxUpgradeLevel = values.flakMaxUpgradeLevel;
           value.flakUpgradeCostMultiplier = values.flakUpgradeCostMultiplier;
           value.flakRadiusUpgrade = values.flakRadiusUpgrade;
           value.flakFireRateUpgrade = values.flakFireRateUpgrade;
            
        }


    }
}