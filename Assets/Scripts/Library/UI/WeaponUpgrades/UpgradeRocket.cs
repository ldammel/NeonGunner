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

        [SerializeField] private GameObject rocketObject;
        
        [SerializeField] private UpgradeRocket previousUpgrade;
        [SerializeField] private UpgradeRocket nextUpgrade;

        [SerializeField] private Sprite activatedImage;
        [SerializeField] private Sprite deactivatedImage;
        
        [SerializeField] private ushort upgradeLevel;
        [SerializeField] private ushort upgradeCost;
        
        public bool isLocked;
        public bool isActivated;
        
        private bool _alreadyActivated;
        private RocketStrike _rocket;
        private Image _activatedImage;
        private Button _thisButton;

        private void Start()
        {
            _activatedImage = gameObject.GetComponent<Image>();
            _rocket = rocketObject.GetComponentInChildren<RocketStrike>();
            _rocket.explosionDamage = (int)values.rocketDamage;
            _rocket.coolDownTime = values.rocketFireRate;
            _rocket.maxMissileTargets = (int)values.rocketEnemiesAmount;
            _thisButton = gameObject.GetComponent<Button>();
            UpdateImages();
            if (currency.rocketLevel == 0) return;
            _alreadyActivated = true;
            Upgrade();
            UpdateImages();
        }

        public void UpdateImages()
        {
            if(previousUpgrade != null) isLocked = !previousUpgrade.isActivated;
            //if(lockedImage != null) lockedImage.enabled = isLocked;
            if(_activatedImage != null) _activatedImage.sprite = isActivated ? activatedImage : deactivatedImage;
            if(_thisButton != null) _thisButton.enabled = !isLocked;
            if(_thisButton != null && !isLocked) _thisButton.enabled = !isActivated;
        }

        public void Upgrade()
        {
            if (currency.currentCurrency < upgradeCost && !_alreadyActivated)
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

            if (!_alreadyActivated)
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
                    _rocket.maxMissileTargets = (int)values.rocketEnemiesAmount;
                    return;
                case 2:
                    _rocket.coolDownTime = values.rocketFireRate;
                    return;
                default:
                    return;
            }
        }
    }
}
