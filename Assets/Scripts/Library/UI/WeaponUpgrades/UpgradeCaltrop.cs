using Library.Character.ScriptableObjects;
using Library.Combat;
using UnityEngine;
using UnityEngine.UI;

namespace Library.UI.WeaponUpgrades
{
    public class UpgradeCaltrop : MonoBehaviour
    {
        [SerializeField] private CurrencyObject currency;
        [SerializeField] private WeaponValues values;
        
        [SerializeField] private GameObject caltropGameObject;

        [SerializeField] private UpgradeCaltrop previousUpgrade;
        [SerializeField] private UpgradeCaltrop nextUpgrade;

        [SerializeField] private Image lockedImage;
        
        [SerializeField] private ushort upgradeLevel;
        [SerializeField] private ushort upgradeCost;
        
        public bool isLocked;
        public bool isActivated;
        
        private bool _alreadyActivated;

        private Caltrops _caltrops;
        private Image _activatedImage;
        private Button _thisButton;
        
        private void Start()
        {
            _activatedImage = gameObject.GetComponent<Image>();
            _caltrops = caltropGameObject.GetComponentInChildren<Caltrops>();
            _caltrops.caltropAmount = (int)values.caltropsAmount;
            _thisButton = gameObject.GetComponent<Button>();
            UpdateImages();
            if (currency.caltropLevel == 0) return;
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
            
            if (nextUpgrade != null)
            {
                nextUpgrade.isLocked = false;
                nextUpgrade.UpdateImages();
            }

            if (upgradeLevel == 0) return;
            if (currency.caltropLevel >= upgradeLevel) return;
            currency.caltropLevel = upgradeLevel;
            currency.currentCurrency -= upgradeCost;
            _caltrops.caltropAmount += 10;
        }
    }
}
