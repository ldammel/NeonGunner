using Library.Character.ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Library.Data
{
    public class SaveData : MonoBehaviour
    {
        public static SaveData Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There can only be one instance of SaveData!");
                Application.Quit();
            }

            Instance = this;
        }

        public CurrencyObject cO;
        public WeaponValues wV;
        
        [Button]
        public void SaveAllData()
        {
            PlayerPrefs.SetInt("CurrentCurrency", cO.currentCurrency);
            PlayerPrefs.SetInt("flakLevel", cO.flakLevel);
            PlayerPrefs.SetInt("flameLevel", cO.flameLevel);
            PlayerPrefs.SetInt("mgLevel", cO.mgLevel);
            PlayerPrefs.SetInt("rocketLevel", cO.rocketLevel);
            PlayerPrefs.SetInt("shrapnelLevel", cO.shrapnelLevel);
            PlayerPrefs.SetInt("caltropLevel", cO.caltropLevel);
            PlayerPrefs.SetInt("gasLevel", cO.gasLevel);
            PlayerPrefs.SetInt("laserLevel", cO.laserLevel);
            PlayerPrefs.SetInt("teslaLevel", cO.teslaLevel);
            
            PlayerPrefs.SetFloat("mgDamage", wV.mgDamage);
            PlayerPrefs.SetFloat("mgRange", wV.mgRange);
            PlayerPrefs.SetFloat("mgFireRate", wV.mgFireRate);
            PlayerPrefs.SetFloat("mgFireRateUpgrade", wV.mgFireRateUpgrade);
            
            PlayerPrefs.SetFloat("flakDamage", wV.flakDamage);
            PlayerPrefs.SetFloat("flakRange", wV.flakRange);
            PlayerPrefs.SetFloat("flakFireRate", wV.flakFireRate);
            PlayerPrefs.SetFloat("flakDamageRadius", wV.flakDamageRadius);
            PlayerPrefs.SetFloat("flakFireRateUpgrade", wV.flakFireRateUpgrade);
            PlayerPrefs.SetFloat("flakRadiusUpgrade", wV.flakRadiusUpgrade);
            
            PlayerPrefs.SetFloat("flameDamage", wV.flameDamage);
            PlayerPrefs.SetFloat("flameRange", wV.flameRange);
            PlayerPrefs.SetFloat("flameSpread", wV.flameSpread);
            PlayerPrefs.SetFloat("flameSpreadUpgrade", wV.flameSpreadUpgrade);
            PlayerPrefs.SetFloat("flameAmmoConsumptionPerSecond", wV.flameAmmoConsumptionPerSecond);
            PlayerPrefs.SetFloat("flameAmmoRefreshPerSecond", wV.flameAmmoRefreshPerSecond);
            
            PlayerPrefs.SetFloat("laserDamage", wV.laserDamage);
            PlayerPrefs.SetFloat("laserRange", wV.laserRange);
            PlayerPrefs.SetFloat("laserDamageUpgrade", wV.laserDamageUpgrade);
            
            PlayerPrefs.SetFloat("teslaDamage", wV.teslaDamage);
            PlayerPrefs.SetFloat("teslaFireRate", wV.teslaFireRate);
            PlayerPrefs.SetFloat("teslaJumpAmount", wV.teslaJumpAmount);
            PlayerPrefs.SetFloat("teslaFireRateUpgrade", wV.teslaFireRateUpgrade);
            PlayerPrefs.SetFloat("teslaJumpAmountUpgrade", wV.teslaJumpAmountUpgrade);
            
            PlayerPrefs.SetFloat("shrapnelAmount", wV.shrapnelAmount);
            PlayerPrefs.SetFloat("shrapnelDamage", wV.shrapnelDamage);
            PlayerPrefs.SetFloat("shrapnelRadius", wV.shrapnelRadius);
            PlayerPrefs.SetFloat("shrapnelDamageUpgrade", wV.shrapnelDamageUpgrade);
            PlayerPrefs.SetFloat("shrapnelRadiusUpgrade", wV.shrapnelRadiusUpgrade);
            
            PlayerPrefs.SetFloat("rocketDamage", wV.rocketDamage);
            PlayerPrefs.SetFloat("rocketEnemiesAmount", wV.rocketEnemiesAmount);
            PlayerPrefs.SetFloat("rocketFireRate", wV.rocketFireRate);
            PlayerPrefs.SetFloat("rocketEnemiesAmountUpgrade", wV.rocketEnemiesAmountUpgrade);
            PlayerPrefs.SetFloat("rocketFireRateUpgrade", wV.rocketFireRateUpgrade);
            
            PlayerPrefs.SetFloat("caltropsAmount", wV.caltropsAmount);
            PlayerPrefs.SetFloat("caltropsDamage", wV.caltropsDamage);
            PlayerPrefs.SetFloat("caltropsAmountUpgrade", wV.caltropsAmountUpgrade);
            
            PlayerPrefs.SetFloat("gasDamage", wV.gasDamage);
            PlayerPrefs.SetFloat("gasDamageUpgrade", wV.gasDamageUpgrade);
            PlayerPrefs.SetFloat("gasMaxRadius", wV.gasMaxRadius);
            PlayerPrefs.SetFloat("gasMaxRadiusUpgrade", wV.gasMaxRadiusUpgrade);
            Debug.Log("Saved Data");
        }

        [Button]
        public void LoadAllData()
        {
            cO.currentCurrency = (ushort)PlayerPrefs.GetInt("CurrentCurrency", cO.currentCurrency);
            cO.flakLevel = (ushort)PlayerPrefs.GetInt("flakLevel", cO.flakLevel);
            cO.flameLevel = (ushort)PlayerPrefs.GetInt("flameLevel", cO.flameLevel);
            cO.mgLevel = (ushort)PlayerPrefs.GetInt("mgLevel", cO.mgLevel);
            cO.rocketLevel = (ushort)PlayerPrefs.GetInt("rocketLevel", cO.rocketLevel);
            cO.shrapnelLevel = (ushort)PlayerPrefs.GetInt("shrapnelLevel", cO.shrapnelLevel);
            cO.caltropLevel = (ushort)PlayerPrefs.GetInt("caltropLevel", cO.caltropLevel);
            cO.gasLevel = (ushort)PlayerPrefs.GetInt("gasLevel", cO.gasLevel);
            cO.laserLevel = (ushort)PlayerPrefs.GetInt("laserLevel", cO.laserLevel);
            cO.teslaLevel = (ushort)PlayerPrefs.GetInt("teslaLevel", cO.teslaLevel);
            
            wV.mgDamage = PlayerPrefs.GetFloat("mgDamage", wV.mgDamage);
            wV.mgRange = PlayerPrefs.GetFloat("mgRange", wV.mgRange);
            wV.mgFireRate = PlayerPrefs.GetFloat("mgFireRate", wV.mgFireRate);
            wV.mgFireRateUpgrade = PlayerPrefs.GetFloat("mgFireRateUpgrade", wV.mgFireRateUpgrade);
            
            wV.flakDamage = PlayerPrefs.GetFloat("flakDamage", wV.flakDamage);
            wV.flakRange = PlayerPrefs.GetFloat("flakRange", wV.flakRange);
            wV.flakFireRate = PlayerPrefs.GetFloat("flakFireRate", wV.flakFireRate);
            wV.flakDamageRadius = PlayerPrefs.GetFloat("flakDamageRadius", wV.flakDamageRadius);
            wV.flakFireRateUpgrade = PlayerPrefs.GetFloat("flakFireRateUpgrade", wV.flakFireRateUpgrade);
            wV.flakRadiusUpgrade = PlayerPrefs.GetFloat("flakRadiusUpgrade", wV.flakRadiusUpgrade);
            
            wV.flameDamage = PlayerPrefs.GetFloat("flameDamage", wV.flameDamage);
            wV.flameRange = PlayerPrefs.GetFloat("flameRange", wV.flameRange);
            wV.flameSpread = PlayerPrefs.GetFloat("flameSpread", wV.flameSpread);
            wV.flameSpreadUpgrade = PlayerPrefs.GetFloat("flameSpreadUpgrade", wV.flameSpreadUpgrade);
            wV.flameAmmoConsumptionPerSecond = PlayerPrefs.GetFloat("flameAmmoConsumptionPerSecond", wV.flameAmmoConsumptionPerSecond);
            wV.flameAmmoRefreshPerSecond =  PlayerPrefs.GetFloat("flameAmmoRefreshPerSecond", wV.flameAmmoRefreshPerSecond);
            
            wV.laserDamage = PlayerPrefs.GetFloat("laserDamage", wV.laserDamage);
            wV.laserRange = PlayerPrefs.GetFloat("laserRange", wV.laserRange);
            wV.laserDamageUpgrade = PlayerPrefs.GetFloat("laserDamageUpgrade", wV.laserDamageUpgrade);
            
            wV.teslaDamage = PlayerPrefs.GetFloat("teslaDamage", wV.teslaDamage);
            wV.teslaFireRate = PlayerPrefs.GetFloat("teslaFireRate", wV.teslaFireRate);
            wV.teslaJumpAmount = PlayerPrefs.GetFloat("teslaJumpAmount", wV.teslaJumpAmount);
            wV.teslaFireRateUpgrade = PlayerPrefs.GetFloat("teslaFireRateUpgrade", wV.teslaFireRateUpgrade);
            wV.teslaJumpAmountUpgrade = PlayerPrefs.GetFloat("teslaJumpAmountUpgrade", wV.teslaJumpAmountUpgrade);
            
            wV.shrapnelAmount = PlayerPrefs.GetFloat("shrapnelAmount", wV.shrapnelAmount);
            wV.shrapnelDamage = PlayerPrefs.GetFloat("shrapnelDamage", wV.shrapnelDamage);
            wV.shrapnelRadius = PlayerPrefs.GetFloat("shrapnelRadius", wV.shrapnelRadius);
            wV.shrapnelDamageUpgrade = PlayerPrefs.GetFloat("shrapnelAmountUpgrade", wV.shrapnelDamageUpgrade);
            wV.shrapnelRadiusUpgrade = PlayerPrefs.GetFloat("shrapnelRadiusUpgrade", wV.shrapnelRadiusUpgrade);
            
            wV.rocketDamage = PlayerPrefs.GetFloat("rocketDamage", wV.rocketDamage);
            wV.rocketEnemiesAmount = PlayerPrefs.GetFloat("rocketEnemiesAmount", wV.rocketEnemiesAmount);
            wV.rocketFireRate = PlayerPrefs.GetFloat("rocketFireRate", wV.rocketFireRate);
            wV.rocketEnemiesAmountUpgrade = PlayerPrefs.GetFloat("rocketEnemiesAmountUpgrade", wV.rocketEnemiesAmountUpgrade);
            wV.rocketFireRateUpgrade = PlayerPrefs.GetFloat("rocketFireRateUpgrade", wV.rocketFireRateUpgrade);
            
            wV.caltropsAmount = PlayerPrefs.GetFloat("caltropsAmount", wV.caltropsAmount);
            wV.caltropsDamage = PlayerPrefs.GetFloat("caltropsDamage", wV.caltropsDamage);
            wV.caltropsAmountUpgrade = PlayerPrefs.GetFloat("caltropsAmountUpgrade", wV.caltropsAmountUpgrade);
            
            wV.gasDamage = PlayerPrefs.GetFloat("gasDamage", wV.gasDamage);
            wV.gasDamageUpgrade = PlayerPrefs.GetFloat("gasDamageUpgrade", wV.gasDamageUpgrade);
            wV.gasMaxRadius = PlayerPrefs.GetFloat("gasMaxRadius", wV.gasMaxRadius);
            wV.gasMaxRadiusUpgrade = PlayerPrefs.GetFloat("gasMaxRadiusUpgrade", wV.gasMaxRadiusUpgrade);
            
            Debug.Log("Loaded Data");
        }
    }
}