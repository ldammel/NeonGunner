using System;
using System.Collections;
using Library.Combat;
using Library.Combat.Pooling;
using Library.Data;
using UnityEngine;
using Library.Events;
using Library.Tools;

public class Test : MonoBehaviour
{
    private CameraTransition _cam;

    public GunMovement[] gunMovementComponent;
    public AimController[] aimControllerComponent;
    public BulletPooled[] bulletPooledComponent;
    public MachineGun[] machineGunComponent;
    public GameObject[] flamethrowerGameObject;
    public CurrencyObject currencyObject;
    public Transform[] positions;
    public Transform[] parents;

    private void Start()
    {
        _cam = FindObjectOfType<CameraTransition>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(FirstTransitionOnStart());
    }

    private void Update()
    {
        if (InputManager.Instance.KeyDown("options") && !LevelManager.Instance.levelSelection.activeSelf)
        {
            PauseMenu.Instance.TriggerMenu();
        }
        
        if (PauseMenu.Instance.pauseActive) return;
        if (InputManager.Instance.KeyDown("flak"))
        {
            TransitionCameraPosition(0);
        }
        else if (InputManager.Instance.KeyDown("flame") && currencyObject.selectedSlotTwo != null)
        {
            TransitionCameraPosition(1);
        }
        
        for (int i = 0; i < positions.Length; i++)
        {
            if (parents[i] == null) continue;
            _cam.positions[i] = positions[i];
        }

        for (int i = 0; i < parents.Length; i++)
        {
            if (parents[i] == null) continue;
            _cam.parents[i] = parents[i];
        }
    }

    private void TransitionCameraPosition(ushort position)
    {
        _cam.parents[position] = parents[position];
        _cam.positions[position] = positions[position];
        _cam.TransitionCameraPosition(position);
        for (int i = 0; i < gunMovementComponent.Length; i++)
        {
            if(gunMovementComponent[i] != null) gunMovementComponent[i].enabled = i == position;
            if(bulletPooledComponent[i] != null) bulletPooledComponent[i].enabled = i == position;
            if(flamethrowerGameObject[i] != null) flamethrowerGameObject[i].SetActive(i == position);
            if(machineGunComponent[i] != null) machineGunComponent[i].enabled = i == position;
        }
    }

    private IEnumerator FirstTransitionOnStart()
    {
        yield return new WaitForSeconds(0.2f);
        _cam.FirstTransitionOnStart();
        for (int i = 0; i < gunMovementComponent.Length; i++)
        {
            if(gunMovementComponent[i] != null) gunMovementComponent[i].enabled = i == 0;
            if(bulletPooledComponent[i] != null) bulletPooledComponent[i].enabled = i == 0;
            if(flamethrowerGameObject[i] != null) flamethrowerGameObject[i].SetActive(i == 0);
            if(machineGunComponent[i] != null) machineGunComponent[i].enabled = i == 0;
        }
    }

}
