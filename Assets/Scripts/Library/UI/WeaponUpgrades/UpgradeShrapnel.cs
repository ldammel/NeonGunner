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
        [SerializeField] private BulletShotPool prefabPool;
        
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
            prefabPool = GameObject.Find("---PLAYER---/GameObjectPool").GetComponent<BulletShotPool>();
            _activatedImage = gameObject.GetComponent<Image>();
            pool = flakGameObject.GetComponentInChildren<BulletPooled>();
            flak.radius = values.flakDamageRadius;
            pool.fireRate = values.flakFireRate;
            flak.damage = values.flakDamage;
            shrapnel.damage = (int)values.shrapnelDamage;
            flak.gameObject.GetComponent<BulletShot>().maxLifeTime = values.flakRange;
            _thisButton = gameObject.GetComponent<Button>();
            UpdateImages();
            if (currency.shrapnelLevel == 0) return;
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
            if (currency.currentCurrency < upgradeCost)
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
            
            prefabPool.prefab = shrapnelGameObject;
            prefabPool.ResetShots();
            
            if (currency.shrapnelLevel < upgradeLevel)
            {
                currency.shrapnelLevel = upgradeLevel;
                currency.currentCurrency -= upgradeCost;
                if(upgradeLevel == 2)values.shrapnelDamage *= values.shrapnelDamageUpgrade;
            }

            UpdateImages();

            switch (upgradeLevel)
            {
                case 1:

                    return;
                case 2:
                    shrapnel.damage = (int)values.shrapnelDamage;
                    return;
                default:
                    return;
            }
        }
    }
}
