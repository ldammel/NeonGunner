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
                }
                
                public GameObject[] weapons;
                public GameObject[] parents;
                
                public Test test;

                public Camera cam;
                
                public GameObject[] currentWeapons = new GameObject[2];

                public bool _firstActiveOne;
                public bool _firstActiveTwo;

                private void Start()
                {
                        test = FindObjectOfType<Test>();
                        if (currencyObject.selectedSlotOne != null) SelectSlotOne(currencyObject.selectedWeaponOne);
                        if(currencyObject.selectedSlotOne == null) SelectSlotOne(0);
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
                        if (!_firstActiveOne)
                        {
                                currentWeapons[0] = go;
                                Debug.Log("Assigned First GO");
                        }
                        cam.gameObject.transform.parent = go.GetComponentInChildren<CamTransitionPoint>().transform;
                        currencyObject.selectedSlotOne = weapons[weapon];
                        currencyObject.selectedWeaponOne = weapon;
                        
                        test.gunMovementComponent[0] = go.GetComponentInChildren<GunMovement>();
                        test.aimControllerComponent[0] = go.GetComponentInChildren<AimController>();
                        test.parents[0] = test.aimControllerComponent[0].transform;
                        test.positions[0] = go.GetComponentInChildren<CamTransitionPoint>().transform;
                        
                        if (currentWeapons[0] != null && _firstActiveOne)
                        {
                                Destroy(currentWeapons[0]);
                                Debug.Log("Destroyed First GO");
                        }
                        currentWeapons[0] = go;
                        _firstActiveOne = true;
                        switch (weapon)
                        {
                                case 0:
                                        test.machineGunComponent[0] = go.GetComponentInChildren<MachineGun>();
                                        break;
                                case 1:
                                        test.flamethrowerGameObject[0] = go.GetComponentInChildren<Flamethrower>().gameObject;
                                        break;
                                case 2:
                                        test.bulletPooledComponent[0] = go.GetComponentInChildren<BulletPooled>();
                                        break;
                                case 3:
                                        test.laserComponent[0] = go.GetComponentInChildren<Laser>();
                                        break;
                                case 4:
                                        test.gasGameObject[0] = go.GetComponentInChildren<ParticleDamage>();
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
                        if (!_firstActiveTwo)
                        {
                                currentWeapons[1] = go;
                                Debug.Log("Assigned Second GO");
                        }
                        cam.gameObject.transform.parent = go.GetComponentInChildren<CamTransitionPoint>().transform;
                        currencyObject.selectedSlotTwo = weapons[weapon];
                        currencyObject.selectedWeaponTwo = weapon;
                        
                        test.gunMovementComponent[1] = go.GetComponentInChildren<GunMovement>();
                        test.aimControllerComponent[1] = go.GetComponentInChildren<AimController>();
                        test.parents[1] = test.aimControllerComponent[1].transform;;
                        test.positions[1] = go.GetComponentInChildren<CamTransitionPoint>().transform;
                        
                        if (currentWeapons[1] != null && _firstActiveTwo)
                        {
                                Destroy(currentWeapons[1]);
                                Debug.Log("Destroyed Second GO");
                        }
                        currentWeapons[1] = go;
                        _firstActiveTwo = true;
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
                                        test.gasGameObject[1] = go.GetComponentInChildren<ParticleDamage>();
                                        break;
                                default:
                                        break;
                        }
                }

        }
}
