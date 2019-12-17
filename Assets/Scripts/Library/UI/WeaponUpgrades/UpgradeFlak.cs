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
        [SerializeField] private BulletPooled pool;
        
        [SerializeField] private UpgradeFlak previousUpgrade;
        [SerializeField] private UpgradeFlak nextUpgrade;
        
        [SerializeField] private UpgradeRocket rocketUpgrade;
        [SerializeField] private UpgradeShrapnel shrapnelUpgrade;
        
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
            pool = flakGameObject.GetComponentInChildren<BulletPooled>();
            flak.radius = values.flakDamageRadius;
            pool.fireRate = values.flakFireRate;
            flak.damage = values.flakDamage;
            flak.gameObject.GetComponent<BulletShot>().maxLifeTime = values.flakRange;
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
                if (rocketUpgrade == null || shrapnelUpgrade == null) return;
                
                rocketUpgrade.isLocked = false;
                rocketUpgrade.UpdateImages();

                shrapnelUpgrade.isLocked = false;
                shrapnelUpgrade.UpdateImages();
            }
            
            currency.flakLevel = upgradeLevel;
            currency.currentCurrency -= upgradeCost;

            isActivated = true;
            _thisButton.enabled = false;

            switch (upgradeLevel)
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
    }
}
