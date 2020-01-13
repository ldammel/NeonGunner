using System;
using System.Runtime.InteropServices;
using BansheeGz.BGSpline.Curve;
using Library.Events;
using UnityEngine;

namespace Library.Character
{
    public class WaypointMovement : MonoBehaviour
    {
        public float moveSpeed;
        public BGCurve path;
        
        private bool _active;
        private int _curPoint;
        
        private Vector3 _targetVector;
        private Vector3 _oldPos;

        private void Start()
        {
            _oldPos = transform.localPosition;
            _curPoint = 0;
            _targetVector = path.Points[_curPoint].PositionLocal;
        }

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
           
            if(_curPoint <= path.PointsCount -1)
            {
                if(Vector3.Distance(this.transform.localPosition, path.Points[_curPoint].PositionLocal) < 1f)
                {  
                    _curPoint++;
                    if(_curPoint != path.PointsCount)_targetVector = path.Points[_curPoint].PositionLocal;
                    _oldPos = transform.localPosition;
                }
            }
            else
            {
                Destroy(gameObject);
            }

            transform.localPosition += ((_targetVector - _oldPos) * Time.deltaTime * moveSpeed);
            
        }
    }
}
