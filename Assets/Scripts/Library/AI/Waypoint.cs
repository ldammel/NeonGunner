using Library.Character;
using UnityEngine;

namespace Library.AI
{
    public class Waypoint : MonoBehaviour
    {
        public bool active;
        public Vector3 point;
        public GameObject pointObj;
        private void Update()
        {
            point = pointObj.transform.position;
            gameObject.SetActive(active);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //WaypointMovement.NWaypoint = this;
            }
        }
    }
}
