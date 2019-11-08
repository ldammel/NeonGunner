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
    }
}