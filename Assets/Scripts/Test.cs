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

    public GunMovement[] gun;
    public AimController[] aim;
    public BulletPooled[] bullet;
    public MachineGun[] mg;
    public GameObject[] flame;
    public CurrencyObject cur;
    public Transform[] positions;
    public Transform[] parents;

    private void Start()
    {
        _cam = FindObjectOfType<CameraTransition>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(FirstTransition());
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
            Transition(0);
        }
        else if (InputManager.Instance.KeyDown("flame"))
        {
            Transition(1);
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

    public void Transition(ushort position)
    {
        _cam.parents[position] = parents[position];
        _cam.positions[position] = positions[position];
        _cam.Transition(position);
        for (int i = 0; i < gun.Length; i++)
        {
            if(gun[i] != null) gun[i].enabled = i == position;
            if(bullet[i] != null) bullet[i].enabled = i == position;
            if(flame[i] != null) flame[i].SetActive(i == position);
            if(mg[i] != null) mg[i].enabled = i == position;
        }
    }

    IEnumerator FirstTransition()
    {
        yield return new WaitForSeconds(0.05f);
        _cam.FirstTransition();
    }

}
