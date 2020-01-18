using System;
using System.Runtime.InteropServices;
using Library.Combat.Enemy;
using Library.Events;
using UnityEngine;

namespace Library.Character
{
    public class WaypointMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private bool destroyOnEnd;

        private bool _active;
        private int _curPoint;
        
        private Vector3 _targetVector;
        private Vector3 _oldPos;
        

        private void Start()
        {
            _oldPos = transform.localPosition;
            _curPoint = 0;
        }

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            gameObject.transform.Translate(0,0,moveSpeed * Time.deltaTime);
        }
    }
}
