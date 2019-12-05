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
                
                if (man.flakActive) return;
                if (man.flameActive) return;
                foreach (var x in flakButtons)
                {
                        x.SetActive(man.flakActive);
                }

                foreach (var x in flameButtons)
                {
                        x.SetActive(man.flameActive);
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
                                displayText[0].text = "MG";
                                break;
                        case 1:
                                mgButtons[0].SetActive(true);
                                flameButtons[0].SetActive(false);
                                flameButtons[1].SetActive(true);
                                flakButtons[0].SetActive(true);
                                displayText[0].text = "Flame";
                                break;
                        case 2:
                                mgButtons[0].SetActive(true);
                                flameButtons[0].SetActive(true);
                                flakButtons[0].SetActive(false);
                                flakButtons[1].SetActive(true);
                                displayText[0].text = "Flak";
                                break;
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
                                displayText[1].text = "MG";
                                break;
                        case 1:
                                mgButtons[1].SetActive(true);
                                flameButtons[1].SetActive(false);
                                flameButtons[0].SetActive(true);
                                flakButtons[1].SetActive(true);
                                displayText[1].text = "Fire";
                                break;
                        case 2:
                                mgButtons[1].SetActive(true);
                                flameButtons[1].SetActive(true);
                                flakButtons[1].SetActive(false);
                                flakButtons[0].SetActive(true);
                                displayText[1].text = "Flak";
                                break;
                        default:
                                break;
                }
        }
}
