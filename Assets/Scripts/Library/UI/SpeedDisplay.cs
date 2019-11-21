
using Library.Character;
using UnityEngine;

namespace Library.UI
{
    public class SpeedDisplay : MonoBehaviour
    {
        public GameObject pointer;
        private WaypointMovement mov;
        private const float MaxAngle = 45;
        private const float ZeroAngle = 345;

        private float speedMax;
        private float curSpeed;

        private void Start()
        {
            mov = GameObject.FindGameObjectWithTag("Player").GetComponent<WaypointMovement>();
            speedMax = mov.maxSpeed;
            curSpeed = mov.speed;
        }

        private void Update()
        {
            curSpeed = mov.speed;
            if (curSpeed > speedMax) curSpeed = speedMax;
            pointer.transform.eulerAngles = new Vector3(0,0,Mathf.Lerp(pointer.transform.rotation.z,GetSpeedRotation(),1));
        }

        public float GetSpeedRotation()
        {
            float totalAngleSize = ZeroAngle - MaxAngle;
            float speedNormalized = curSpeed / speedMax;
            return ZeroAngle - speedNormalized * totalAngleSize;
        }
    }
}
