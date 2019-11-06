using System.Collections.Generic;
using Library.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Library.Combat
{
    public class AimController : MonoBehaviour {

    [SerializeField]
    private Image crosshair;

    [SerializeField] private Transform[] Weapons;

    [SerializeField]
    private float sphereCastSize;

    private Camera mainCamera;
    public Ray CrossHairRay;

    private void Start() {

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

        private void Update() { 
        if (PauseMenu.Instance.pauseActive) return;
        var centerOfCrosshair = crosshair.transform.position;
        CrossHairRay = mainCamera.ScreenPointToRay(centerOfCrosshair);
        
        Vector3 lookAtPoint;
        if (Physics.SphereCast(CrossHairRay, sphereCastSize, out RaycastHit hitInfoOne, 300f, LayerMask.GetMask("Enemy"))) {
            crosshair.color = Color.red;
        } else if (Physics.SphereCast(CrossHairRay, 0.1f, out RaycastHit hitInfotwo, 300f, LayerMask.GetMask("Player"))) {
            crosshair.color = Color.green;
        } else{
            crosshair.color = Color.white;
        }
        
        lookAtPoint = CrossHairRay.GetPoint(100f);
        
       //if (Physics.SphereCast(CrossHairRay, sphereCastSize, out RaycastHit hitInfo, 1000f, LayerMask.GetMask("Enemy"))) {
       //    lookAtPoint = hitInfo.point;
       //} else {
       //    lookAtPoint = CrossHairRay.GetPoint(100f);
       //}

           foreach (var w in Weapons)
           {
               w.LookAt(lookAtPoint);
           }
        }
    }
}
