using System;
using System.Collections;
using System.Collections.Generic;
using Library.Character.Upgrades;
using TMPro;
using UnityEngine;

public class WeaponSelectionManager : MonoBehaviour
{
        [SerializeField] private GameObject[] flakButtons;
        [SerializeField] private GameObject[] flameButtons;
        [SerializeField] private GameObject[] mgButtons;
        [SerializeField] private GameObject[] rocketButtons;
        [SerializeField] private GameObject[] shrapnelButtons;
        [SerializeField] private GameObject[] teslaButtons;
        [SerializeField] private GameObject[] laserButtons;
        [SerializeField] private GameObject[] gasButtons;
        [SerializeField] private GameObject[] caltropButtons;

        [SerializeField] private TextMeshProUGUI[] displayText;

        [SerializeField] private CurrencyObject man;

        private void Update()
        {
                if (man.selectedSlotOne != null)
                {
                        SelectWeaponOne(man.selectedWeaponOne);
                }
                else
                {
                        displayText[0].text = "None";
                }

                if (man.selectedSlotTwo != null)
                {
                        SelectWeaponTwo(man.selectedWeaponTwo);
                }
                else
                {
                        displayText[1].text = "None";
                }
        }

        public void SelectWeaponOne(int weapon)
        {
                switch (weapon)
                {
                        case 0:
                                mgButtons[0].SetActive(false);
                                mgButtons[1].SetActive(true);
                                flameButtons[0].SetActive(true);
                                flakButtons[0].SetActive(true);
                                /*caltropButtons[0].SetActive(true);
                                gasButtons[0].SetActive(true);
                                laserButtons[0].SetActive(true);
                                teslaButtons[0].SetActive(true);
                                shrapnelButtons[0].SetActive(true);
                                rocketButtons[0].SetActive(true);*/
                                displayText[0].text = "MG";
                                break;
                        case 1:
                                mgButtons[0].SetActive(true);
                                flameButtons[0].SetActive(false);
                                flameButtons[1].SetActive(true);
                                flakButtons[0].SetActive(true);
                                /*caltropButtons[0].SetActive(true);
                                gasButtons[0].SetActive(true);
                                laserButtons[0].SetActive(true);
                                teslaButtons[0].SetActive(true);
                                shrapnelButtons[0].SetActive(true);
                                rocketButtons[0].SetActive(true);*/
                                displayText[0].text = "Flame";
                                break;
                        case 2:
                                mgButtons[0].SetActive(true);
                                flameButtons[0].SetActive(true);
                                flakButtons[0].SetActive(false);
                                flakButtons[1].SetActive(true);
                                /*caltropButtons[0].SetActive(true);
                                gasButtons[0].SetActive(true);
                                laserButtons[0].SetActive(true);
                                teslaButtons[0].SetActive(true);
                                shrapnelButtons[0].SetActive(true);
                                rocketButtons[0].SetActive(true);*/
                                displayText[0].text = "Flak";
                                break;
                        /*case 3:
                                mgButtons[0].SetActive(true);
                                flameButtons[0].SetActive(true);
                                flakButtons[0].SetActive(true);
                                caltropButtons[0].SetActive(true);
                                gasButtons[0].SetActive(true);
                                laserButtons[0].SetActive(false);
                                laserButtons[1].SetActive(true);
                                teslaButtons[0].SetActive(true);
                                shrapnelButtons[0].SetActive(true);
                                rocketButtons[0].SetActive(true);
                                displayText[0].text = "Laser";
                                break;
                        case 4:
                                mgButtons[0].SetActive(true);
                                flameButtons[0].SetActive(true);
                                flakButtons[0].SetActive(true);
                                caltropButtons[0].SetActive(true);
                                gasButtons[0].SetActive(true);
                                laserButtons[0].SetActive(true);
                                teslaButtons[0].SetActive(false);
                                teslaButtons[1].SetActive(true);
                                shrapnelButtons[0].SetActive(true);
                                rocketButtons[0].SetActive(true);
                                displayText[0].text = "Tesla";
                                break;
                        case 5:
                                mgButtons[0].SetActive(true);
                                flameButtons[0].SetActive(true);
                                flakButtons[0].SetActive(true);
                                caltropButtons[0].SetActive(true);
                                gasButtons[0].SetActive(false);
                                gasButtons[1].SetActive(true);
                                laserButtons[0].SetActive(true);
                                teslaButtons[0].SetActive(true);
                                shrapnelButtons[0].SetActive(true);
                                rocketButtons[0].SetActive(true);
                                displayText[0].text = "Gas";
                                break;
                        case 6:
                                mgButtons[0].SetActive(true);
                                flameButtons[0].SetActive(true);
                                flakButtons[0].SetActive(true);
                                caltropButtons[0].SetActive(false);
                                caltropButtons[1].SetActive(true);
                                gasButtons[0].SetActive(true);
                                laserButtons[0].SetActive(true);
                                teslaButtons[0].SetActive(true);
                                shrapnelButtons[0].SetActive(true);
                                rocketButtons[0].SetActive(true);
                                displayText[0].text = "Caltrops";
                                break;*/
                        default:
                                break;
                }
        }
        
        public void SelectWeaponTwo(int weapon)
        {
                switch (weapon)
                { 
                        case 0:
                                mgButtons[1].SetActive(false);
                                mgButtons[0].SetActive(true);
                                flameButtons[1].SetActive(true);
                                flakButtons[1].SetActive(true);
                                /*caltropButtons[1].SetActive(true);
                                gasButtons[1].SetActive(true);
                                laserButtons[1].SetActive(true);
                                teslaButtons[1].SetActive(true);
                                shrapnelButtons[1].SetActive(true);
                                rocketButtons[1].SetActive(true);*/
                                displayText[1].text = "MG";
                                break;
                        case 1:
                                mgButtons[1].SetActive(true);
                                flameButtons[1].SetActive(false);
                                flameButtons[0].SetActive(true);
                                flakButtons[1].SetActive(true);
                                /*caltropButtons[1].SetActive(true);
                                gasButtons[1].SetActive(true);
                                laserButtons[1].SetActive(true);
                                teslaButtons[1].SetActive(true);
                                shrapnelButtons[1].SetActive(true);
                                rocketButtons[1].SetActive(true);*/
                                displayText[1].text = "Flame";
                                break;
                        case 2:
                                mgButtons[1].SetActive(true);
                                flameButtons[1].SetActive(true);
                                flakButtons[1].SetActive(false);
                                flakButtons[0].SetActive(true);
                               /* caltropButtons[1].SetActive(true);
                                gasButtons[1].SetActive(true);
                                laserButtons[1].SetActive(true);
                                teslaButtons[1].SetActive(true);
                                shrapnelButtons[1].SetActive(true);
                                rocketButtons[1].SetActive(true);*/
                                displayText[1].text = "Flak";
                                break;
                        /*case 3:
                                mgButtons[1].SetActive(true);
                                flameButtons[1].SetActive(true);
                                flakButtons[1].SetActive(true);
                                caltropButtons[1].SetActive(true);
                                gasButtons[1].SetActive(true);
                                laserButtons[1].SetActive(false);
                                laserButtons[0].SetActive(true);
                                teslaButtons[1].SetActive(true);
                                shrapnelButtons[1].SetActive(true);
                                rocketButtons[1].SetActive(true);
                                displayText[1].text = "Laser";
                                break;
                        case 4:
                                mgButtons[1].SetActive(true);
                                flameButtons[1].SetActive(true);
                                flakButtons[1].SetActive(true);
                                caltropButtons[1].SetActive(true);
                                gasButtons[1].SetActive(true);
                                laserButtons[1].SetActive(true);
                                teslaButtons[1].SetActive(false);
                                teslaButtons[0].SetActive(true);
                                shrapnelButtons[1].SetActive(true);
                                rocketButtons[1].SetActive(true);
                                displayText[1].text = "Tesla";
                                break;
                        case 5:
                                mgButtons[1].SetActive(true);
                                flameButtons[1].SetActive(true);
                                flakButtons[1].SetActive(true);
                                caltropButtons[1].SetActive(true);
                                gasButtons[1].SetActive(false);
                                gasButtons[0].SetActive(true);
                                laserButtons[1].SetActive(true);
                                teslaButtons[1].SetActive(true);
                                shrapnelButtons[1].SetActive(true);
                                rocketButtons[1].SetActive(true);
                                displayText[1].text = "Gas";
                                break;
                        case 6:
                                mgButtons[1].SetActive(true);
                                flameButtons[1].SetActive(true);
                                flakButtons[1].SetActive(true);
                                caltropButtons[1].SetActive(false);
                                caltropButtons[0].SetActive(true);
                                gasButtons[1].SetActive(true);
                                laserButtons[1].SetActive(true);
                                teslaButtons[1].SetActive(true);
                                shrapnelButtons[1].SetActive(true);
                                rocketButtons[1].SetActive(true);
                                displayText[1].text = "Caltrops";*/
                                break;
                        default:
                                break;
                }
        }
}
