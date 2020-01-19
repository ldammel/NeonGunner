using System;
using UnityEngine;

namespace Library.Data
{
    public class SelectWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject[] weaponsOnPlayer;
        [SerializeField] private int weaponIndex;
        [SerializeField] private GameObject objectToDeactivate;

        public void ActivateWeapon()
        {
            for (int i = 0; i < weaponsOnPlayer.Length; i++)
            {
                weaponsOnPlayer[i].SetActive(i == weaponIndex);
            }
            objectToDeactivate.SetActive(false);
        }
    }
}
