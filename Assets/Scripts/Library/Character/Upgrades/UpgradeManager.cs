using System;
using Library.Combat;
using Library.Combat.Pooling;
using TMPro;
using UnityEngine;

namespace Library.Character.Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        [SerializeField] private Flak flak;
        [SerializeField] private MachineGun mg;
        [SerializeField] private Flamethrower flame;
        [SerializeField] private BulletPooled pool;
 
        private int _flakUpgradeLevel;
        private int _flameUpgradeLevel;
        private int _mgUpgradeLevel;

        public TextMeshProUGUI flakText;
        public TextMeshProUGUI flameText;
        public TextMeshProUGUI mgText;

        private void Start()
        {
            flak.radius = 5;
            pool.fireRate = 1;
            mg.fireRate = 0.2f;
            _flakUpgradeLevel = 0;
            _flameUpgradeLevel = 0;
            _mgUpgradeLevel = 0;
        }

        private void Update()
        {
            flakText.text = _flakUpgradeLevel.ToString();
            flameText.text = _flameUpgradeLevel.ToString();
            mgText.text = _mgUpgradeLevel.ToString();
        }


        public void UpgradeFlak()
        {
            if (_flakUpgradeLevel < 1)
            {
                flak.radius *= 2;
                _flakUpgradeLevel++;
            }
            else if (_flakUpgradeLevel == 1)
            {
                pool.fireRate /= 2;
                _flakUpgradeLevel++;
            }
        }
        
        public void UpgradeFire()
        {
            if (_flameUpgradeLevel < 1)
            {
                //
            }
        }
        
        public void UpgradeMG()
        {
            if (_mgUpgradeLevel > 2) return;
            mg.fireRate /= 2;
            _mgUpgradeLevel++;

        }

    }
}
