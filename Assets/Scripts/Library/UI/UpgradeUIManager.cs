using System;
using Library.Events;
using UnityEngine;

namespace Library.UI
{
    public class UpgradeUIManager : MonoBehaviour
    {
        public VoidEvent onFlameUpgrade;
        public VoidEvent onMgUpgrade;
        public VoidEvent onFlakUpgrade;
        public VoidEvent onFlameUpgradeTwo;
        public VoidEvent onMgUpgradeTwo;
        public VoidEvent onFlakUpgradeTwo;
        public CurrencyObject upgrades;


        private void Update()
        {
            if (upgrades.mgLevel >= 1)
            {
                onMgUpgrade.Raise();
            }
            if (upgrades.mgLevel >= 2)
            {
                onMgUpgradeTwo.Raise();
            }
            if (upgrades.flameLevel >= 1)
            {
                onFlameUpgrade.Raise();
            }
            if (upgrades.flameLevel >= 2)
            {
                onFlameUpgradeTwo.Raise();
            }
            if (upgrades.flakLevel >= 1)
            {
                onFlakUpgrade.Raise();
            }
            if (upgrades.flakLevel >= 2)
            {
                onFlakUpgradeTwo.Raise();
            }
        }
    }
}

