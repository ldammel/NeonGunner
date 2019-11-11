using System;
using System.Collections;
using System.Collections.Generic;
using Library.Events;
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

        private float ClampAngle(float angle, float from, float to)
        {
            if (angle < 0f) angle = 360 + angle;
            return angle > 180f ? Mathf.Max(angle, 360+@from) : Mathf.Min(angle, to);
        }

        private void FixedUpdate()
        {
            if (PauseMenu.Instance.pauseActive) return;
            _rotation.x = Input.GetAxis("Mouse X")* Time.deltaTime * rotationSpeed;
            _rotation.y = Input.GetAxis("Mouse Y")* Time.deltaTime * rotationSpeed;
            _rotation.z = 0;

            var rot = transform.rotation.eulerAngles + new Vector3(-_rotation.y, _rotation.x, 0f); //use local if your char is not always oriented Vector3.up
            rot.x = ClampAngle(rot.x, -10f, 20f);
         
            transform.eulerAngles = rot;
        }
    }
}
