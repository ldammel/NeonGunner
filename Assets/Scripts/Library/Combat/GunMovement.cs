using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Library.Combat
{
    public class GunMovement : MonoBehaviour
    {
        [SerializeField]
        private float rotationSpeed = 2.0f;
        private Vector3 _rotation = Vector3.zero;
        
        float ClampAngle(float angle, float from, float to)
        {
            // accepts e.g. -80, 80
            if (angle < 0f) angle = 360 + angle;
            if (angle > 180f) return Mathf.Max(angle, 360+from);
            return Mathf.Min(angle, to);
        }

        private void FixedUpdate()
        {
            _rotation.x = Input.GetAxis("Mouse X")* Time.deltaTime * rotationSpeed;
            _rotation.y = Input.GetAxis("Mouse Y")* Time.deltaTime * rotationSpeed;
            _rotation.z = 0;
           // transform.Rotate(_rotation);
            
            Vector3 rot = transform.rotation.eulerAngles + new Vector3(-_rotation.y, _rotation.x, 0f); //use local if your char is not always oriented Vector3.up
            rot.x = ClampAngle(rot.x, -10f, 20f);
         
            transform.eulerAngles = rot;
        }
    }
}
