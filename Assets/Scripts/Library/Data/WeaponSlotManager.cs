using System;
using Library.Combat;
using Library.Combat.Pooling;
using UnityEngine;

namespace Library.Data
{
        public class WeaponSlotManager : MonoBehaviour
        {
                public static WeaponSlotManager Instance;
                public CurrencyObject manager;

                private void Awake()
                {
                        if (Instance != null)
                        {
                                Debug.LogError("There can only be one Instance of WeaponSlotManager!");
                                Application.Quit();
                        }
                        Instance = this;
                        if(manager.selectedSlotOne == null) SelectSlotOne(0);
                }
                
                public GameObject[] weapons;
                public GameObject[] parents;
                
                public Test test;

                private void Start()
                {
                        if (manager.selectedSlotOne != null) SelectSlotOne(manager.selectedWeaponOne);
                        if (manager.selectedSlotTwo != null) SelectSlotTwo(manager.selectedWeaponTwo);
                }

                private void Update()
                {
                        test = FindObjectOfType<Test>();
                }


                public void SelectSlotOne(int weapon)
                {
                        if (manager.selectedWeaponTwo == weapon)
                        {
                                manager.selectedSlotTwo = null;
                                manager.selectedWeaponTwo = 0;
                        }
                        var go = Instantiate(weapons[weapon], parents[0].transform);
                        manager.selectedSlotOne = weapons[weapon];
                        manager.selectedWeaponOne = weapon;
                        test.gun[0] = go.GetComponentInChildren<GunMovement>();
                        test.aim[0] = go.GetComponentInChildren<AimController>();
                        test.parents[0] = test.aim[0].transform;
                        test.positions[0] = go.GetComponentInChildren<CamTransitionPoint>().transform;
                        switch (weapon)
                        {
                                case 0:
                                        test.mg[0] = go.GetComponentInChildren<MachineGun>();
                                        break;
                                case 1:
                                        test.flame[0] = go.GetComponentInChildren<Flamethrower>().gameObject;
                                        break;
                                case 2:
                                        test.bullet[0] = go.GetComponentInChildren<BulletPooled>();
                                        break;
                                default:
                                        break;
                        }
                }
                
                public void SelectSlotTwo(int weapon)
                {
                        if (manager.selectedWeaponOne == weapon)
                        {
                                manager.selectedSlotOne = null;
                                manager.selectedWeaponOne = 0;
                        }
                        var go = Instantiate(weapons[weapon], parents[1].transform);
                        manager.selectedSlotTwo = weapons[weapon];
                        manager.selectedWeaponTwo = weapon;
                        test.gun[1] = go.GetComponentInChildren<GunMovement>();
                        test.aim[1] = go.GetComponentInChildren<AimController>();
                        test.parents[1] = test.aim[1].transform;;
                        test.positions[1] = go.GetComponentInChildren<CamTransitionPoint>().transform;
                        switch (weapon)
                        {
                                case 0:
                                        test.mg[1] = go.GetComponentInChildren<MachineGun>();
                                        break;
                                case 1:
                                        test.flame[1] = go.GetComponentInChildren<Flamethrower>().gameObject;
                                        break;
                                case 2:
                                        test.bullet[1] = go.GetComponentInChildren<BulletPooled>();
                                        break;
                                default:
                                        break;
                        }
                }

        }
}
