using Library.Combat;
using UnityEngine;

namespace Library.Data
{
    public class WeaponSelector : MonoBehaviour
    {
        [SerializeField] private GameObject[] weapons;

        private Quaternion _prevRotation;

        public void SelectWeapon(int index)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i].activeSelf) _prevRotation = i == 1 ? new Quaternion(0,0,0,0) : weapons[i].GetComponentInChildren<GunMovement>().gameObject.transform.rotation;
                weapons[index].GetComponentInChildren<GunMovement>().gameObject.transform.rotation = index == 1 ? new Quaternion(0,0,0,0) : _prevRotation;
                weapons[i].SetActive(i == index);

            }
        }
    }    
}
