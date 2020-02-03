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
        
        if (InputManager.Instance.KeyDown("mg") || Input.GetKeyDown(KeyCode.Keypad1))
        {
            selector.SelectWeapon(0);
        }
        if (InputManager.Instance.KeyDown("flame") || Input.GetKeyDown(KeyCode.Keypad2))
        {
            selector.SelectWeapon(1);
        }
        if (SpawnNextPatternManager.Instance.levelNumber < 10) return;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selector.SwitchLane(-3);
        }    
        if (Input.GetKeyDown(KeyCode.E))
        {
            selector.SwitchLane(3);
        }    
    }
}
