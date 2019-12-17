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
        }

        public void UpdateImages()
        {
            if (previousUpgrade.isActivated && isLocked) isLocked = false;
            lockedImage.enabled = isLocked;
            _activatedImage.color = isActivated ? Color.yellow : Color.gray;
            _thisButton.enabled = !isLocked;
        }

        public void Upgrade()
        {
            if (currency.currentCurrency < upgradeCost)
            {
                NotificationManager.Instance.SetNewNotification("Not enough Souls!", 3);
                return;
            }
            
            if (nextUpgrade !=null)
            {
                nextUpgrade.isLocked = false;
                nextUpgrade.UpdateImages();
            }

            currency.rocketLevel = upgradeLevel;
            currency.currentCurrency -= upgradeCost;

            isActivated = true;
            _thisButton.enabled = false;

            switch (upgradeLevel)
            {
                case 1:
                    rocket.maxMissileTargets = 8;
                    return;
                case 2:
                    rocket.coolDownTime /= 2;
                    return;
                default:
                    return;
            }
        }
    }
}
