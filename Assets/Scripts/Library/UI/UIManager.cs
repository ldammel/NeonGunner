using System;
using Library.Character.ScriptableObjects;
using Library.Character.Upgrades;
using Library.Combat;
using Library.Combat.Pooling;
using Library.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Library.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UpgradeManager upgradeManager;
        [SerializeField] private CurrencyObject upgrades;
        [SerializeField] private WeaponValues values;
        [SerializeField] private GameObject[] mgUpgradeImages;
        [SerializeField] private GameObject[] flameUpgradeImages;
        [SerializeField] private GameObject[] flakUpgradeImages;
        [SerializeField] private GameObject[] rocketUpgradeImages;
        [SerializeField] private GameObject[] shrapnelUpgradeImages;

        [SerializeField] private ushort flakBuyPrice;
        [SerializeField] private ushort flameBuyPrice;
        
        [SerializeField] private GameObject flakBuyButton;
        [SerializeField] private GameObject flameBuyButton;
        
        [SerializeField] private TextMeshProUGUI flameBuyText;
        [SerializeField] private TextMeshProUGUI flakBuyText;
        
        [SerializeField] private TextMeshProUGUI mgText;
        [SerializeField] private TextMeshProUGUI flakText;
        [SerializeField] private TextMeshProUGUI flameText;

        private void Start()
        {
            upgradeManager = FindObjectOfType<UpgradeManager>();
            UpdateText();
        }

        private void UpdateText()
        {
            flakText.text = upgrades.flakLevel + " - Cost:" + values.flakUpgradeCost;
            flameText.text = upgrades.flameLevel + " - Cost:" + values.flameUpgradeCost;
            mgText.text = upgrades.mgLevel + " - Cost: " + values.mgUpgradeCost;
            flakBuyText.text = flakBuyPrice.ToString();
            flameBuyText.text = flameBuyPrice.ToString();
            flakBuyButton.SetActive(!upgrades.flakActive);
            flameBuyButton.SetActive(!upgrades.flameActive);
        }


        public void UnlockNextStage(string weapon)
        {
            switch (weapon)
            {
                case "mg":
                    for (int i = 0; i < upgrades.mgLevel; i++)
                    {
                        mgUpgradeImages[i].SetActive(false);
                    }
                    break;
                case "flame":
                    for (int i = 0; i < upgrades.flameLevel; i++)
                    {
                        flameUpgradeImages[i].SetActive(false);
                    }
                    break;
                case "flak":
                    for (int i = 0; i < upgrades.flakLevel; i++)
                    {
                        if (upgrades.flakLevel == 2)
                        {
                            shrapnelUpgradeImages[0].SetActive(false);
                            rocketUpgradeImages[0].SetActive(false);
                        }
                        else
                        {
                            flakUpgradeImages[i].SetActive(false);
                        }
                    }
                    break;
                case "rocket":
                    for (int i = 0; i < upgrades.rocketLevel; i++)
                    {
                        rocketUpgradeImages[i].SetActive(false);
                    }
                    break;
                case "shrapnel":
                    for (int i = 0; i < upgrades.shrapnelLevel; i++)
                    {
                        shrapnelUpgradeImages[i].SetActive(false);
                    }
                    break;
                default:
                    break;
            }
        }

        public void UnlockFlak()
        {
            if (upgrades.currentCurrency < flakBuyPrice)
            {
                NotificationManager.Instance.SetNewNotification("Not enough money to buy the Flak!", 3);
                return;
            }
            upgrades.currentCurrency -= flakBuyPrice;
            upgrades.flakActive = true;
            
        }
        
        public void UnlockFlame()
        {
            if (upgrades.currentCurrency < flameBuyPrice)
            {
                NotificationManager.Instance.SetNewNotification("Not enough money to buy the Caltrops!", 3);
                return;
            }
            upgrades.currentCurrency -= flameBuyPrice;
            upgrades.flameActive = true;
        }

    }
}
