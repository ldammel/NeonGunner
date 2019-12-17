using Library.Combat.Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Library.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private CurrencyObject upgrades;
        [SerializeField] private TextMeshProUGUI currencyDisplay;
        
        [SerializeField] private  Image healthImage;
        [SerializeField] private  EnemyHealth eh;
        private void Update()
        {
            currencyDisplay.text = upgrades.currentCurrency.ToString();
            healthImage.fillAmount = eh.curHealth / eh.maxHealth;
        }
    }
}
