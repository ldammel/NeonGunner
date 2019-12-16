using System;
using Library.Character.ScriptableObjects;
using Library.Combat;
using Library.Combat.Pooling;
using Library.Events;
using Library.UI;
using TMPro;
using UnityEngine;

namespace Library.Character.Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        public CurrencyObject upgrades;
        public WeaponValues values;
        [SerializeField] private Flak flak;
        [SerializeField] private GameObject flakGameObject;
        [SerializeField] private GameObject mgGameObject;
        [SerializeField] private MachineGun mg;
        [SerializeField] private BulletPooled pool;
        [SerializeField] private TextMeshProUGUI currencyDisplay;

        private void Start()
        {
            
            mg = mgGameObject.GetComponentInChildren<MachineGun>();
            pool = flakGameObject.GetComponentInChildren<BulletPooled>();
            flak.radius = values.flakDamageRadius;
            pool.fireRate = values.flakFireRate;
            flak.damage = values.flakDamage;
            flak.gameObject.GetComponent<BulletShot>().maxLifeTime = values.flakRange;

            mg.fireRate = values.mgFireRate;
            mg.damage = values.mgDamage;
            mg.range = values.mgRange;
        }

        public void UpdateCurrency()
        {
            currencyDisplay.text = upgrades.currentCurrency.ToString();
        }
       
        
        

        public void UpgradeFlak()
        {
            if (upgrades.flakLevel >= values.flakMaxUpgradeLevel) return;
            if (upgrades.currentCurrency < values.flakUpgradeCost)
            {
                NotificationManager.Instance.SetNewNotification("Not enough money to buy the upgrade!", 3);
                return;
            }
            upgrades.flakLevel++;
            upgrades.currentCurrency -= values.flakUpgradeCost;
            values.flakUpgradeCost *= values.flakUpgradeCostMultiplier;
            switch (upgrades.flakLevel)
            {
                case 1:
                    flak.radius *= values.flakRadiusUpgrade;
                    values.flakDamageRadius *= values.flakRadiusUpgrade;
                    return;
                case 2:
                    pool.fireRate /= values.flakFireRateUpgrade;
                    values.flakFireRate /= values.flakFireRateUpgrade;
                    return;
                default:
                    return;
            }
        }
        
        
        
        
        
        public void UpgradeFire()
        {
            if (upgrades.flameLevel >= values.flameMaxUpgradeLevel) return;
            if (upgrades.currentCurrency < values.flameUpgradeCost)
            {
                NotificationManager.Instance.SetNewNotification("Not enough money to buy the upgrade!", 3);
                return;
            }
            upgrades.flameLevel++;
            upgrades.currentCurrency -= values.flameUpgradeCost;
            values.flameUpgradeCost *= values.flameUpgradeCostMultiplier;
            switch (upgrades.flameLevel)
            {
                case 1:
                    values.flameSpread = values.flameSpreadUpgrade;
                    return;
                case 2:
                    values.flameMaxAmmo += values.flameMaxAmmoUpgrade;
                    return;
                default:
                    return;
            }
        }
        
        
        
        
        
        public void UpgradeMG()
        {
            if (upgrades.mgLevel >= values.mgMaxUpgradeLevel) return;
            if (upgrades.currentCurrency < values.mgUpgradeCost)
            {
                NotificationManager.Instance.SetNewNotification("Not enough money to buy the upgrade!", 3);
                return;
            }
            upgrades.mgLevel++;
            upgrades.currentCurrency -= values.mgUpgradeCost;
            values.mgUpgradeCost *= values.mgUpgradeCostMultiplier;
            mg.fireRate /= values.mgFireRateUpgrade;
            values.mgFireRate /= values.mgFireRateUpgrade;
        }
        
        
        
        

        public void CheatMoney()
        {
            upgrades.currentCurrency += 10000;
        }
    }
}
