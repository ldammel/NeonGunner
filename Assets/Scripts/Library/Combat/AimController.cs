using System.Collections.Generic;
using Library.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Library.Combat
{
    public class AimController : MonoBehaviour {

    [SerializeField]
    private Image crosshair;

    [SerializeField] private Transform[] weapons;

    [SerializeField]
    private float sphereCastSize;

    private Camera _mainCamera;
    public Ray crossHairRay;

    private void Start() {

        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

        private void Update() { 
        if (PauseMenu.Instance.pauseActive) return;
        var centerOfCrosshair = crosshair.transform.position;
        crossHairRay = _mainCamera.ScreenPointToRay(centerOfCrosshair);

        if (Physics.SphereCast(crossHairRay, sphereCastSize, 300f, LayerMask.GetMask("Enemy"))) {
            crosshair.color = Color.red;
        } else if (Physics.SphereCast(crossHairRay, 0.1f, 300f, LayerMask.GetMask("Player"))) {
            crosshair.color = Color.green;
        } else{
            crosshair.color = Color.white;
        }
        
        var lookAtPoint = crossHairRay.GetPoint(100f);

        foreach (var w in weapons)
        {
            w.LookAt(lookAtPoint);
        }
        
        }
    }
}
