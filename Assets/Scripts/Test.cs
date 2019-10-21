using System;
using Library.Combat;
using Library.Combat.Pooling;
using UnityEngine;
using Library.Events;
public class Test : MonoBehaviour
{
    private CameraTransition _cam;

    [SerializeField] private GunMovement[] gun;
    [SerializeField] private AimController[] aim;
    [SerializeField] private BulletPooled[] bullet;

    private void Start()
    {
        _cam = FindObjectOfType<CameraTransition>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            TransitionOrigin();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            TransitionOne();
        }
    }

    public void TransitionOrigin()
    {
        _cam.Transition(0);
        gun[0].enabled = true;
        gun[1].enabled = false;
        aim[0].enabled = true;
        aim[1].enabled = false;
        bullet[1].enabled = false;
        bullet[0].enabled = true;
    }
    
    public void TransitionOne()
    {
        _cam.Transition(1);
        gun[1].enabled = true;
        gun[0].enabled = false;
        aim[1].enabled = true;
        aim[0].enabled = false;
        bullet[1].enabled = true;
        bullet[0].enabled = false;
    }

}
