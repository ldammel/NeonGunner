using Library.Base;
using UnityEngine;

[CreateAssetMenu(menuName = "Currency")]
public class CurrencyObject : BaseScriptableObject
{
    public int currentCurrency;
    public int flakLevel;
    public int flameLevel;
    public int mgLevel;

    public bool flakActive;
    public bool flameActive;
}
