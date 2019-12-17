using Library.Character.ScriptableObjects;
using Library.Combat;
using Library.Combat.Pooling;
using UnityEngine;
using UnityEngine.UI;

namespace Library.UI.WeaponUpgrades
{
    public class UpgradeShrapnel : MonoBehaviour
    {
        [SerializeField] private CurrencyObject currency;
        [SerializeField] private WeaponValues values;
        
        [SerializeField] private Flak flak;
        [SerializeField] private GameObject flakGameObject;
        [SerializeField] private GameObject shrapnelGameObject;
        [SerializeField] private ShrapnelPiece shrapnel;
        [SerializeField] private BulletPooled pool;
        
        [SerializeField] private UpgradeShrapnel previousUpgrade;
        [SerializeField] private UpgradeShrapnel nextUpgrade;

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
            shrapnel = shrapnelGameObject.GetComponentInChildren<ShrapnelPiece>();
            flak.radius = values.flakDamageRadius;
            pool.fireRate = values.flakFireRate;
            flak.damage = values.flakDamage;
            shrapnel.damage = (int)values.shrapnelDamage;
            flak.gameObject.GetComponent<BulletShot>().maxLifeTime = values.flakRange;
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
            
            currency.shrapnelLevel = upgradeLevel;
            currency.currentCurrency -= upgradeCost;

            isActivated = true;
            _thisButton.enabled = false;

            switch (upgradeLevel)
            {
                case 1:
                    flak.radius *= values.shrapnelRadiusUpgrade;
                    return;
                case 2:
                    shrapnel.damage *= (int)values.shrapnelDamageUpgrade;
                    return;
                default:
                    return;
            }
        }
    }
}
