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
        
        [SerializeField] private Caltrops caltrops;
        [SerializeField] private GameObject caltropGameObject;

        [SerializeField] private UpgradeCaltrop previousUpgrade;
        [SerializeField] private UpgradeCaltrop nextUpgrade;

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
            caltrops = caltropGameObject.GetComponentInChildren<Caltrops>();
            caltrops.caltropAmount = (int)values.caltropsAmount;
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

            if (nextUpgrade != null)
            {
                nextUpgrade.isLocked = false;
                nextUpgrade.UpdateImages();
            }

            currency.caltropLevel = upgradeLevel;
            currency.currentCurrency -= upgradeCost;

            isActivated = true;
            _thisButton.enabled = false;

            if (upgradeLevel == 0) return;

            caltrops.caltropAmount += 10;
        }
    }
}
