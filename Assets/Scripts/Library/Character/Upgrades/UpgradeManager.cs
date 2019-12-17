using System;
using Library.Character.ScriptableObjects;
using Library.Combat;
using Library.Combat.Pooling;
using Library.Events;
using Library.UI;
using TMPro;
using UnityEngine;

namespace Library.Character.Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        public CurrencyObject upgrades;
        public void CheatMoney()
        {
            upgrades.currentCurrency += 10000;
        }
    }
}
