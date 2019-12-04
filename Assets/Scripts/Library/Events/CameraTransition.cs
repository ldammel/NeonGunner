using System;
using UnityEngine;

namespace Library.Events
{
    public class CameraTransition : MonoBehaviour
    {
        public Camera cam;
        public Transform[] positions;
        public Transform[] parents;

        private ushort _lastPos;
        private ushort _curPos;

        private Vector3 _lastVec;
        private Vector3 _lastCamVec;
        private Vector3 _newCamVec;

        public void Transition(ushort position)
        {
            _curPos = position;
            if (_curPos == _lastPos) return;
            var transform1 = cam.transform;
            _lastCamVec = new Vector3(transform1.rotation.x,transform1.rotation.y,transform1.rotation.z);
            parents[position].eulerAngles = _lastVec;
            transform1.position = positions[position].position;
            transform1.eulerAngles = _lastVec;
            transform1.parent = parents[position];
            _newCamVec = _lastCamVec;
            _lastVec = new Vector3(parents[_lastPos].transform.rotation.x,parents[_lastPos].transform.rotation.y,parents[_lastPos].transform.rotation.z);
            _lastPos = position;
        }
    }
}
