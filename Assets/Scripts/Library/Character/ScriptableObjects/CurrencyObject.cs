using Library.Base;
using UnityEngine;

[CreateAssetMenu(menuName = "Currency")]
public class CurrencyObject : BaseScriptableObject
{
    public int currentCurrency;
    public ushort flakLevel;
    public ushort flameLevel;
    public ushort mgLevel;
    public ushort rocketLevel;
    public ushort shrapnelLevel;
    public ushort caltropLevel;
    public ushort gasLevel;
    public ushort laserLevel;
    public ushort teslaLevel;

    public GameObject selectedSlotOne;
    public GameObject selectedSlotTwo;
    public int selectedWeaponOne;
    public int selectedWeaponTwo;
}
