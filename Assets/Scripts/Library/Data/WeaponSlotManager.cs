using System;
using Library.Combat;
using Library.Combat.Pooling;
using UnityEngine;

namespace Library.Data
{
        public class WeaponSlotManager : MonoBehaviour
        {
                public static WeaponSlotManager Instance;
                public CurrencyObject currencyObject;

                private void Awake()
                {
                        if (Instance != null)
                        {
                                Debug.LogError("There can only be one Instance of WeaponSlotManager!");
                                Application.Quit();
                        }
                        Instance = this;
                        if(currencyObject.selectedSlotOne == null) SelectSlotOne(0);
                }
                
                public GameObject[] weapons;
                public GameObject[] parents;
                
                public Test test;

                private void Start()
                {
                        test = FindObjectOfType<Test>();
                        if (currencyObject.selectedSlotOne != null) SelectSlotOne(currencyObject.selectedWeaponOne);
                        if (currencyObject.selectedSlotTwo != null) SelectSlotTwo(currencyObject.selectedWeaponTwo);
                }

                public void SelectSlotOne(int weapon)
                {
                        if (currencyObject.selectedWeaponTwo == weapon)
                        {
                                currencyObject.selectedSlotTwo = null;
                                currencyObject.selectedWeaponTwo = 0;
                        }
                        var go = Instantiate(weapons[weapon], parents[0].transform);
                        go.transform.localPosition = Vector3.zero;
                        currencyObject.selectedSlotOne = weapons[weapon];
                        currencyObject.selectedWeaponOne = weapon;
                        test.gunMovementComponent[0] = go.GetComponentInChildren<GunMovement>();
                        test.aimControllerComponent[0] = go.GetComponentInChildren<AimController>();
                        test.parents[0] = test.aimControllerComponent[0].transform;
                        test.positions[0] = go.GetComponentInChildren<CamTransitionPoint>().transform;
                        switch (weapon)
                        {
                                case 0:
                                        test.machineGunComponent[0] = go.GetComponentInChildren<MachineGun>();
                                        break;
                                case 1:
                                        test.flamethrowerGameObject[0] = go.GetComponentInChildren<Caltrops>().gameObject;
                                        break;
                                case 2:
                                        test.bulletPooledComponent[0] = go.GetComponentInChildren<BulletPooled>();
                                        break;
                                case 3:
                                        test.laserComponent[0] = go.GetComponentInChildren<Laser>();
                                        break;
                                case 4:
                                        
                                        break;
                                default:
                                        break;
                        }
                }
                
                public void SelectSlotTwo(int weapon)
                {
                        if (currencyObject.selectedWeaponOne == weapon)
                        {
                                currencyObject.selectedSlotOne = null;
                                currencyObject.selectedWeaponOne = 0;
                        }
                        var go = Instantiate(weapons[weapon], parents[1].transform);
                        go.transform.localPosition = Vector3.zero;
                        currencyObject.selectedSlotTwo = weapons[weapon];
                        currencyObject.selectedWeaponTwo = weapon;
                        test.gunMovementComponent[1] = go.GetComponentInChildren<GunMovement>();
                        test.aimControllerComponent[1] = go.GetComponentInChildren<AimController>();
                        test.parents[1] = test.aimControllerComponent[1].transform;;
                        test.positions[1] = go.GetComponentInChildren<CamTransitionPoint>().transform;
                        switch (weapon)
                        {
                                case 0:
                                        test.machineGunComponent[1] = go.GetComponentInChildren<MachineGun>();
                                        break;
                                case 1:
                                        test.flamethrowerGameObject[1] = go.GetComponentInChildren<Flamethrower>().gameObject;
                                        break;
                                case 2:
                                        test.bulletPooledComponent[1] = go.GetComponentInChildren<BulletPooled>();
                                        break;
                                case 3:
                                        test.laserComponent[1] = go.GetComponentInChildren<Laser>();
                                        break;
                                case 4:
                                        
                                        break;
                                default:
                                        break;
                        }
                }

        }
}
