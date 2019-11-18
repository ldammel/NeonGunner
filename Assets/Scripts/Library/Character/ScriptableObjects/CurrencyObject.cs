using Library.Base;
using UnityEngine;

[CreateAssetMenu(menuName = "Currency")]
public class CurrencyObject : BaseScriptableObject
{
    public ushort currentCurrency;
    public ushort flakLevel;
    public ushort flameLevel;
    public ushort mgLevel;

    public bool flakActive;
    public bool flameActive;
}
