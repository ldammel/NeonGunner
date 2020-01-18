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

        #region Flame Settings
        [BoxGroup("Flamethrower Settings")] 
        public float flameDamage;
        [BoxGroup("Flamethrower Settings")] 
        public float flameRange;
        [BoxGroup("Flamethrower Settings")] 
        public float flameSpread;
        [BoxGroup(" Flamethrower Settings")] 
        public float flameSpreadUpgrade;
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
    }
}