using Library.Character.ScriptableObjects;
using Library.Combat;
using Library.Combat.Pooling;
using UnityEngine;
using UnityEngine.UI;

namespace Library.UI.WeaponUpgrades
{
    public class UpgradeFlame : MonoBehaviour
    {
        [SerializeField] private CurrencyObject currency;
        [SerializeField] private WeaponValues values;
        
        [SerializeField] private Flamethrower flame;
        [SerializeField] private GameObject flameObject;

        [SerializeField] private UpgradeFlame previousUpgrade;
        [SerializeField] private UpgradeFlame nextUpgrade;
        
        [SerializeField] private UpgradeCaltrop caltropUpgrade;
        [SerializeField] private UpgradeGas gasUpgrade;
        
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
            flame = flameObject.GetComponentInChildren<Flamethrower>();
            flame.damage = values.flameDamage;
            flame.range = values.flameRange;
            flame.spread = values.flameSpread;
            flame.ammoConsumptionPerSecond = values.flameAmmoConsumptionPerSecond;
            flame.ammoRefreshPerSecond = values.flameAmmoRefreshPerSecond;
            _thisButton = gameObject.GetComponent<Button>();
            UpdateImages();
        }

        public void UpdateImages()
        {
            if (previousUpgrade.isActivated) isLocked = false;
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
            else
            {
                if (caltropUpgrade == null || gasUpgrade == null) return;
                
                caltropUpgrade.isLocked = false;
                caltropUpgrade.UpdateImages();

                gasUpgrade.isLocked = false;
                gasUpgrade.UpdateImages();
            }
            
            currency.flameLevel = upgradeLevel;
            currency.currentCurrency -= upgradeCost;

            isActivated = true;
            _thisButton.enabled = false;

            switch (upgradeLevel)
            {
                case 1:
                    flame.spread = values.flameSpreadUpgrade;
                    return;
                case 2:
                    flame.ammoConsumptionPerSecond /= 2;
                    return;
                default:
                    return;
            }
        }
    }
}
