using System;
using Library.Character.ScriptableObjects;
using Library.Combat;
using Library.Combat.Pooling;
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
        [SerializeField] private int flakPrice;
        [SerializeField] private Flamethrower flame;
        [SerializeField] private GameObject flameGameObject;
        [SerializeField] private int flamePrice;
        [SerializeField] private MachineGun mg;
        [SerializeField] private BulletPooled pool;
        [SerializeField] private TextMeshProUGUI currencyDisplay;

        public TextMeshProUGUI mgText;

        public TextMeshProUGUI flameText;
        public TextMeshProUGUI flameBuyText;
        public GameObject flameUpgradeButton;
        public GameObject flameBuyButton;
   
        public TextMeshProUGUI flakText;
        public TextMeshProUGUI flakBuyText;
        public GameObject flakUpgradeButton;
        public GameObject flakBuyButton;
        
        private void Start()
        {
            flak.radius = values.flakDamageRadius;
            pool.fireRate = values.flakFireRate;
            flame.spread = values.flameSpread;
            flame.maxAmmo = values.flameMaxAmmo;
            mg.fireRate = values.mgFireRate;
        }

        private void Update()
        {
            flakText.text = upgrades.flakLevel + " - Cost:" + values.flakUpgradeCost;
            flameText.text = upgrades.flameLevel + " - Cost:" + values.flameUpgradeCost;
            mgText.text = upgrades.mgLevel + " - Cost: " + values.mgUpgradeCost;
            flakBuyText.text = flakPrice.ToString();
            flameBuyText.text = flamePrice.ToString();
            currencyDisplay.text = upgrades.currentCurrency.ToString();
            flakGameObject.SetActive(upgrades.flakActive);
            flameGameObject.SetActive(upgrades.flameActive);
            flakUpgradeButton.SetActive(upgrades.flakActive);
            flameUpgradeButton.SetActive(upgrades.flameActive);
            flakBuyButton.SetActive(!upgrades.flakActive);
            flameBuyButton.SetActive(!upgrades.flameActive);
        }

        public void UnlockFlak()
        {
            if (upgrades.currentCurrency < flakPrice)
            {
                NotificationManager.Instance.SetNewNotification("Not enough money to buy the Flak!", 3);
                return;
            }
            upgrades.currentCurrency -= flakPrice;
            upgrades.flakActive = true;
            
        }
        public void UnlockFlame()
        {
            if (upgrades.currentCurrency < flakPrice)
            {
                NotificationManager.Instance.SetNewNotification("Not enough money to buy the Flamethrower!", 3);
                return;
            }
            upgrades.currentCurrency -= flamePrice;
            upgrades.flameActive = true;
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
                    flame.spread = values.flameSpreadUpgrade;
                    values.flameSpread = values.flameSpreadUpgrade;
                    return;
                case 2:
                    flame.maxAmmo += values.flameMaxAmmoUpgrade;
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
