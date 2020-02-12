using Library.Character.ScriptableObjects;
using UnityEngine;


namespace Library.Events
{
    public class SelectDifficulty : MonoBehaviour
    {
        public WeaponValues value;

        public void SelectDif(WeaponValues values)
        {
           value.mgDamage = values.mgDamage;
           value.mgRange = values.mgRange;

           value.flakDamage = values.flakDamage;

           value.flameDamage = values.flameDamage;

           value.mgFireRateUpgrade = values.mgFireRateUpgrade;
           
           value.flameSpreadUpgrade = values.flameSpreadUpgrade;

           value.flakRadiusUpgrade = values.flakRadiusUpgrade;
           value.flakFireRateUpgrade = values.flakFireRateUpgrade;
            
        }

        public void DifMode(string mode)
        {
            PlayerPrefs.SetString("Difficulty", mode);
        }


    }
}
