using UnityEngine;

namespace Library.Events
{
    public class CameraTransition : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        
        [SerializeField] private Transform[] positions;

        [SerializeField] private Transform[] parents;

        private int _lastPos;
        private int _curPos;
        public void Transition(int position)
        {
            _curPos = position;
            if (_curPos == _lastPos) return;
            var transform1 = cam.transform;
            parents[position].eulerAngles = new Vector3(0,0,0);
            transform1.position = positions[position].position;
            transform1.eulerAngles = new Vector3(0,0,0);
            transform1.parent = parents[position];
            _lastPos = position;
        }
    }
}
