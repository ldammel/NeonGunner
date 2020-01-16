﻿using System;
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

    public GunMovement[] gunMovementComponent = new GunMovement[2];
    public AimController[] aimControllerComponent = new AimController[2];
    public BulletPooled[] bulletPooledComponent = new BulletPooled[2];
    public MachineGun[] machineGunComponent = new MachineGun[2];
    public GameObject[] flamethrowerGameObject = new GameObject[2];
    public ParticleDamage[] gasGameObject = new ParticleDamage[2];
    public Laser[] laserComponent = new Laser[2];
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
        if (InputManager.Instance.KeyDown("options"))
        {
            PauseMenu.Instance.TriggerMenu();
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
        
        if (PauseMenu.Instance.pauseActive) return;
        if (InputManager.Instance.KeyDown("flak"))
        {
            TransitionCameraPosition(0);
        }
        else if (InputManager.Instance.KeyDown("flame") && currencyObject.selectedSlotTwo != null)
        {
            TransitionCameraPosition(1);
        }
    }

    public void TransitionCameraPosition(ushort position)
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
            if(laserComponent[i] != null) laserComponent[i].enabled = i == position;
            if(gasGameObject[i] != null) gasGameObject[i].enabled = i == position;
        }
    }

    public IEnumerator FirstTransitionOnStart()
    {
        yield return new WaitForSeconds(0.2f);
        _cam.FirstTransitionOnStart();
        for (int i = 0; i < gunMovementComponent.Length; i++)
        {
            if(gunMovementComponent[i] != null) gunMovementComponent[i].enabled = i == 0;
            if(bulletPooledComponent[i] != null) bulletPooledComponent[i].enabled = i == 0;
            if(flamethrowerGameObject[i] != null) flamethrowerGameObject[i].SetActive(i == 0);
            if(machineGunComponent[i] != null) machineGunComponent[i].enabled = i == 0;
            if(laserComponent[i] != null) laserComponent[i].enabled = i == 0;
            if(gasGameObject[i] != null) gasGameObject[i].enabled = i == 0;
        }
    }

    public void Transi()
    {
        StartCoroutine(FirstTransitionOnStart());
    }

}
