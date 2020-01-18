using Library.Character.ScriptableObjects;
using Library.Combat;
using Library.Combat.Pooling;
using UnityEngine;
using UnityEngine.UI;

namespace Library.UI.WeaponUpgrades
{
    public class UpgradeFlak : MonoBehaviour
    {
        [SerializeField] private CurrencyObject currency;
        [SerializeField] private WeaponValues values;
        
        [SerializeField] private Flak flak;
        [SerializeField] private GameObject flakGameObject;
        
        [SerializeField] private UpgradeFlak previousUpgrade;
        [SerializeField] private UpgradeFlak nextUpgrade;

        [SerializeField] private Sprite activatedImage;
        [SerializeField] private Sprite deactivatedImage;
        
        [SerializeField] private ushort upgradeLevel;
        [SerializeField] private ushort upgradeCost;
        
        public bool isLocked;
        public bool isActivated;
        private bool _alreadyActivated;

        private Image _activatedImage;
        private UpgradeFlak _thisButton;
        private BulletPooled _pool;
        private void Start()
        {
            _activatedImage = gameObject.GetComponent<Image>();
            _pool = flakGameObject.GetComponentInChildren<BulletPooled>();
            flak.radius = values.flakDamageRadius;
            _pool.fireRate = values.flakFireRate;
            flak.damage = values.flakDamage;
            flak.gameObject.GetComponent<BulletShot>().maxLifeTime = values.flakRange;
            _thisButton = gameObject.GetComponent<UpgradeFlak>();
            UpdateImages();
            if (currency.flakLevel == 0) return;
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
                currency.flakLevel = upgradeLevel;
                currency.currentCurrency -= upgradeCost;
               if(upgradeLevel == 1) values.flakDamageRadius *= values.flakRadiusUpgrade;
               if(upgradeLevel == 2) values.flakFireRate /= values.flakFireRateUpgrade;
            }

            
            UpdateImages();

            switch (upgradeLevel)
            {
                case 1:
                    flak.radius = values.flakDamageRadius;
                    return;
                case 2:
                    _pool.fireRate = values.flakFireRate;
                    return;
                default:
                    return;
            }
        }
    }
}
