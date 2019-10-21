using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AimController : MonoBehaviour {

    [SerializeField]
    private Image crosshair;

    [SerializeField]
    private List<Transform> Weapons;

    [SerializeField]
    private float sphereCastSize;

    private Camera mainCamera;
    public Ray CrossHairRay;

    private void Start() {

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update() {
        var centerOfCrosshair = crosshair.transform.position;
        CrossHairRay = mainCamera.ScreenPointToRay(centerOfCrosshair);
        
        Vector3 lookAtPoint;
        if (Physics.SphereCast(CrossHairRay, sphereCastSize, out RaycastHit hitInfoOne, 300f, LayerMask.GetMask("Enemy"))) {
            crosshair.color = Color.red;
        } else {
            crosshair.color = Color.white;
        }
        
        lookAtPoint = CrossHairRay.GetPoint(100f);
        
       //if (Physics.SphereCast(CrossHairRay, sphereCastSize, out RaycastHit hitInfo, 1000f, LayerMask.GetMask("Enemy"))) {
       //    lookAtPoint = hitInfo.point;
       //} else {
       //    lookAtPoint = CrossHairRay.GetPoint(100f);
       //}
        
        Weapons.ForEach(w => w.LookAt(lookAtPoint));
    }
}
