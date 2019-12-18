using Library.Character.ScriptableObjects;
using Library.Combat;
using Library.Combat.Pooling;
using UnityEngine;
using UnityEngine.UI;

namespace Library.UI.WeaponUpgrades
{
    public class UpgradeRocket : MonoBehaviour
    {
        [SerializeField] private CurrencyObject currency;
        [SerializeField] private WeaponValues values;

        [SerializeField] private RocketStrike rocket;
        [SerializeField] private GameObject rocketObject;
        
        [SerializeField] private UpgradeRocket previousUpgrade;
        [SerializeField] private UpgradeRocket nextUpgrade;

        [SerializeField] private Image lockedImage;
        private Image _activatedImage;
        private Button _thisButton;
        
        [SerializeField] private ushort upgradeLevel;
        [SerializeField] private ushort upgradeCost;
        
        public bool isLocked;
        public bool isActivated;

        private void Start()
        {
            _activatedImage = gameObject.GetComponent<Image>();
            rocket = rocketObject.GetComponentInChildren<RocketStrike>();
            rocket.explosionDamage = (int)values.rocketDamage;
            rocket.coolDownTime = values.rocketFireRate;
            rocket.maxMissileTargets = (int)values.rocketEnemiesAmount;
            _thisButton = gameObject.GetComponent<Button>();
            UpdateImages();
            if (currency.rocketLevel < upgradeLevel) return;
            Upgrade();
            UpdateImages();
        }

        public void UpdateImages()
        {
            if(previousUpgrade != null) isLocked = !previousUpgrade.isActivated;
            if(lockedImage != null) lockedImage.enabled = isLocked;
            if(_activatedImage != null) _activatedImage.color = isActivated ? Color.yellow : Color.gray;
            if(_thisButton != null) _thisButton.enabled = !isLocked;
            if(_thisButton != null && !isLocked) _thisButton.enabled = !isActivated;
        }

        public void Upgrade()
        {
            if (currency.currentCurrency < upgradeCost)
            {
                NotificationManager.Instance.SetNewNotification("Not enough Souls!", 3);
                return;
            }
            
            isActivated = true;
            _thisButton.enabled = false;
            
            if (nextUpgrade !=null)
            {
                nextUpgrade.isLocked = false;
                nextUpgrade.UpdateImages();
            }

            if (currency.rocketLevel < upgradeLevel)
            {
                currency.rocketLevel = upgradeLevel;
                currency.currentCurrency -= upgradeCost;
                if(upgradeLevel == 1)values.rocketEnemiesAmount = values.rocketEnemiesAmountUpgrade;
                if(upgradeLevel == 2)values.rocketFireRate /= values.rocketFireRateUpgrade;
            }

            UpdateImages();

            switch (upgradeLevel)
            {
                case 0:
                    rocketObject.SetActive(true);
                    break;
                case 1:
                    rocket.maxMissileTargets = (int)values.rocketEnemiesAmount;
                    return;
                case 2:
                    rocket.coolDownTime = values.rocketFireRate;
                    return;
                default:
                    return;
            }
        }
    }
}
