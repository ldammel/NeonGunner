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
        [BoxGroup("MG Settings")] 
        public float mgFireRateUpgrade;
        #endregion
        
        #region Laser Settings
        [BoxGroup("Laser Settings")] 
        public float laserDamage;
        [BoxGroup("Laser Settings")] 
        public float laserDamageUpgrade;
        [BoxGroup("Laser Settings")] 
        public float laserRange;
        #endregion
        
        #region Tesla Settings
        [BoxGroup("Tesla Settings")] 
        public float teslaDamage;
        [BoxGroup("Tesla Settings")] 
        public float teslaFireRate;
        [BoxGroup("Tesla Settings")] 
        public float teslaJumpAmount;
        [BoxGroup("Tesla Settings")] 
        public float teslaFireRateUpgrade;
        [BoxGroup("Tesla Settings")] 
        public float teslaJumpAmountUpgrade;
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
        [BoxGroup(" Flak Settings")] 
        public float flakFireRateUpgrade;
        [BoxGroup(" Flak Settings")] 
        public float flakRadiusUpgrade;
        #endregion
        
        #region Shrapnel Settings
        [BoxGroup("Shrapnel Settings")] 
        public float shrapnelDamage;
        [BoxGroup("Shrapnel Settings")] 
        public float shrapnelRadius;
        [BoxGroup("Shrapnel Settings")] 
        public float shrapnelAmount;
        [BoxGroup("Shrapnel Settings")] 
        public float shrapnelRadiusUpgrade;
        [BoxGroup("Shrapnel Settings")] 
        public float shrapnelDamageUpgrade;
        #endregion
        
        #region Rocket Settings
        [BoxGroup("Rocket Settings")] 
        public float rocketDamage;
        [BoxGroup("Rocket Settings")] 
        public float rocketFireRate;
        [BoxGroup("Rocket Settings")] 
        public float rocketEnemiesAmount;
        [BoxGroup("Rocket Settings")] 
        public float rocketFireRateUpgrade;
        [BoxGroup("Rocket Settings")] 
        public float rocketEnemiesAmountUpgrade;
        #endregion
        
        #region Flame Settings
        [BoxGroup("Flamethrower Settings")] 
        public float flameDamage;
        [BoxGroup("Flamethrower Settings")] 
        public float flameRange;
        [BoxGroup("Flamethrower Settings")] 
        public float flameAmmoConsumptionPerSecond;
        [BoxGroup("Flamethrower Settings")] 
        public float flameAmmoRefreshPerSecond;
        [BoxGroup("Flamethrower Settings")] 
        public float flameSpread;
        [BoxGroup(" Flamethrower Settings")] 
        public float flameSpreadUpgrade;
        #endregion
        
        #region Caltrops Settings
        [BoxGroup("Caltrops Settings")] 
        public float caltropsDamage;
        [BoxGroup("Caltrops Settings")] 
        public float caltropsAmount;
        [BoxGroup("Caltrops Settings")] 
        public float caltropsAmountUpgrade;
        #endregion
        
        #region Gas Settings
        [BoxGroup("Gas Settings")] 
        public float gasDamage;
        [BoxGroup("Gas Settings")] 
        public float gasMaxRadius;
        [BoxGroup("Gas Settings")] 
        public float gasDamageUpgrade;
        [BoxGroup("Gas Settings")] 
        public float gasMaxRadiusUpgrade;
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