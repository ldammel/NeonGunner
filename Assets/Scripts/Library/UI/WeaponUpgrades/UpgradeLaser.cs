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

        [SerializeField] private UpgradeLaser previousUpgrade;
        [SerializeField] private UpgradeLaser nextUpgrade;
        
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
            _thisButton = gameObject.GetComponent<Button>();
            UpdateImages();
        }

        public void UpdateImages()
        {
            if(previousUpgrade != null) isLocked = !previousUpgrade.isActivated;
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
            
            currency.laserLevel = upgradeLevel;
            currency.currentCurrency -= upgradeCost;

            isActivated = true;
            _thisButton.enabled = false;

        }
    }
}
