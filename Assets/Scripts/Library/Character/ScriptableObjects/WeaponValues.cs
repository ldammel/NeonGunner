using Library.Base;
using NaughtyAttributes;
using UnityEngine;

namespace Library.Character.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Values")]
    public class WeaponValues : BaseScriptableObject
    {
        #region MG Settings
        [BoxGroup("MG Settings")]
        public float mgDamage;
        [BoxGroup("MG Settings")]
        public float mgRange;
        [BoxGroup("MG Settings")]
        public float mgFireRate;
        
        [BoxGroup("MG Upgrade Settings")] 
        public ushort mgMaxUpgradeLevel;
        [BoxGroup("MG Upgrade Settings")] 
        public ushort mgUpgradeCost;
        [BoxGroup("MG Upgrade Settings")] 
        public ushort mgUpgradeCostMultiplier;
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
        public ushort flakMaxUpgradeLevel;
        [BoxGroup(" Flak Upgrade Settings")] 
        public ushort flakUpgradeCost;
        [BoxGroup(" Flak Upgrade Settings")] 
        public ushort flakUpgradeCostMultiplier;
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
        public ushort flameMaxUpgradeLevel;
        [BoxGroup(" Flamethrower Upgrade Settings")] 
        public ushort flameUpgradeCost;
        [BoxGroup(" Flamethrower Upgrade Settings")] 
        public ushort flameUpgradeCostMultiplier;
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
    }
}