using UnityEngine;

namespace Library.Data
{
    public class WeaponSelector : MonoBehaviour
    {
        [SerializeField] private GameObject[] weapons;

        public void SelectWeapon(int index)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(i == index);
            }
        }
    }    
}
