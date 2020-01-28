using System;
using Library.Combat;
using Library.Combat.Pooling;
using Library.Data;
using UnityEngine;
using Library.Events;
using Library.Tools;

public class Test : MonoBehaviour
{
    [SerializeField] private WeaponSelector selector;

    private void Start()
    {
        selector = GameObject.Find("---PLAYER---/Player").GetComponent<WeaponSelector>();
    }

    private void Update()
    {
        if (InputManager.Instance.KeyDown("options"))
        {
            PauseMenu.Instance.TriggerMenu();
        }
        
        if (InputManager.Instance.KeyDown("mg"))
        {
            selector.SelectWeapon(0);
        }
        if (InputManager.Instance.KeyDown("flame"))
        {
            selector.SelectWeapon(1);
        }
        if (InputManager.Instance.KeyDown("flak"))
        {
            selector.SelectWeapon(2);
        }
    }
}
