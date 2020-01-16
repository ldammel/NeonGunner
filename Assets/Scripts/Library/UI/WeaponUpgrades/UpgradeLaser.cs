using Library.Character.ScriptableObjects;
using Library.Combat;
using Library.Combat.Pooling;
using UnityEngine;
using UnityEngine.UI;

namespace Library.UI.WeaponUpgrades
{
    public class UpgradeLaser : MonoBehaviour
    {
        [SerializeField] private CurrencyObject currency;
        [SerializeField] private WeaponValues values;

        [SerializeField] private GameObject laserGameObject;

        [SerializeField] private UpgradeLaser previousUpgrade;
        [SerializeField] private UpgradeLaser nextUpgrade;
        
        [SerializeField] private Sprite activatedImage;
        [SerializeField] private Sprite deactivatedImage;
        
        private Image _activatedImage;
        private Button _thisButton;
        
        [SerializeField] private ushort upgradeLevel;
        [SerializeField] private ushort upgradeCost;
        
        public bool isLocked;
        public bool isActivated;

        private bool _alreadyActivated;
        private Laser laser;

        private void Start()
        {
            laser = laserGameObject.GetComponentInChildren<Laser>();
            _activatedImage = gameObject.GetComponent<Image>();
            _thisButton = gameObject.GetComponent<Button>();
            UpdateImages();
            if (currency.laserLevel == 0) return;
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
                currency.laserLevel = upgradeLevel;
                currency.currentCurrency -= upgradeCost;
                values.laserDamage *= values.laserDamageUpgrade;
            }

            laser.damage = values.laserDamage;
        }
    }
}
