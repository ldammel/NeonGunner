using System;
using Library.Character.ScriptableObjects;
using Library.Combat;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Library.UI.WeaponUpgrades
{
    public class UpgradeMG : MonoBehaviour
    {
        [SerializeField] private CurrencyObject currency;
        [SerializeField] private WeaponValues values;
        
        [SerializeField] private GameObject mgGameObject;
        
        [SerializeField] private UpgradeMG previousUpgrade;
        [SerializeField] private UpgradeMG nextUpgrade;
        
        [SerializeField] private UpgradeLaser laserUpgrade;
        [SerializeField] private UpgradeTesla teslaUpgrade;
        
        [SerializeField] private Image lockedImage;

        [SerializeField] private ushort upgradeLevel;
        [SerializeField] private ushort upgradeCost;
        
        public bool isLocked;
        public bool isActivated;
        
        private bool _alreadyActivated;

        private MachineGun _mg;
        private Image _activatedImage;
        private Button _thisButton;
        
        private void Start()
        {

            _activatedImage = gameObject.GetComponent<Image>();
            _mg = mgGameObject.GetComponentInChildren<MachineGun>();
            _thisButton = gameObject.GetComponent<Button>();
            UpdateImages();
            _mg.fireRate = values.mgFireRate;
            _mg.damage = values.mgDamage;
            _mg.range = values.mgRange;
            if (currency.mgLevel == 0) return;
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
                if (laserUpgrade == null || teslaUpgrade == null) return;
                
                laserUpgrade.isLocked = false;
                laserUpgrade.UpdateImages();

                teslaUpgrade.isLocked = false;
                teslaUpgrade.UpdateImages();
            }

            if (currency.mgLevel < upgradeLevel)
            {
                currency.mgLevel = upgradeLevel;
                currency.currentCurrency -= upgradeCost;
                values.mgFireRate /= values.mgFireRateUpgrade;
            }
            
            UpdateImages();

            if (_mg.fireRate != values.mgFireRate)
            {
                _mg.fireRate = values.mgFireRate;
            }
        }
    }
}
