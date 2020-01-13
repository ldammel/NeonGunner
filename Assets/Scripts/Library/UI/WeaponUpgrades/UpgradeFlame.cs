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
        
        
        [SerializeField] private GameObject flameObject;

        [SerializeField] private UpgradeFlame previousUpgrade;
        [SerializeField] private UpgradeFlame nextUpgrade;
        
        [SerializeField] private UpgradeGas gasUpgrade;
        
        [SerializeField] private Image lockedImage;

        [SerializeField] private ushort upgradeLevel;
        [SerializeField] private ushort upgradeCost;
        
        public bool isLocked;
        public bool isActivated;
        
        private bool _alreadyActivated;
        
        private Image _activatedImage;
        private Button _thisButton;
        private Flamethrower _flame;
        private void Start()
        {
            _activatedImage = gameObject.GetComponent<Image>();
            _flame = flameObject.GetComponentInChildren<Flamethrower>();
            _flame.damage = values.flameDamage;
            _flame.range = values.flameRange;
            _flame.spread = values.flameSpread;
            _flame.ammoConsumptionPerSecond = values.flameAmmoConsumptionPerSecond;
            _flame.ammoRefreshPerSecond = values.flameAmmoRefreshPerSecond;
            _thisButton = gameObject.GetComponent<Button>();
            UpdateImages();
            if (currency.flameLevel == 0) return;
            _alreadyActivated = true;
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
            else
            {
                if (gasUpgrade == null) return;

                gasUpgrade.isLocked = false;
                gasUpgrade.UpdateImages();
            }
            
            if (!_alreadyActivated)
            {
                currency.flameLevel = upgradeLevel;
                currency.currentCurrency -= upgradeCost;
                if(upgradeLevel == 1) _flame.spread = values.flameSpreadUpgrade;
                if(upgradeLevel == 2) _flame.ammoConsumptionPerSecond /= 2;
            }
        }
    }
}
