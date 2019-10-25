using System;
using Library.Combat;
using Library.Combat.Pooling;
using UnityEngine;
using Library.Events;
using Library.Tools;

public class Test : MonoBehaviour
{
    private CameraTransition _cam;

    [SerializeField] private GunMovement[] gun;
    [SerializeField] private AimController[] aim;
    [SerializeField] private BulletPooled bullet;
    [SerializeField] private MachineGun mg;
    [SerializeField] private GameObject flame;
    [SerializeField] private GameObject options;
    private void Start()
    {
        _cam = FindObjectOfType<CameraTransition>();
        flame.SetActive(false);
        mg.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (InputManager.Instance.KeyDown("flak"))
        {
            Transition(0);
        }
        else if (InputManager.Instance.KeyDown("flame"))
        {
            Transition(1);
        }
        else if (InputManager.Instance.KeyDown("mg"))
        {
            Transition(2);
        }
        else if (InputManager.Instance.KeyDown("options"))
        {
            options.SetActive(!options.activeSelf);
            Cursor.visible = options.activeSelf;
            Cursor.lockState = options.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
        }
        
    }

    private void Transition(int position)
    {
        _cam.Transition(position);
        for (int i = 0; i < gun.Length; i++)
        {
            gun[i].enabled = i == position;
            aim[i].enabled = i == position;
        }
        bullet.enabled = position == 0;
        flame.SetActive(position == 1);
        mg.enabled = position == 2;
    }

}
