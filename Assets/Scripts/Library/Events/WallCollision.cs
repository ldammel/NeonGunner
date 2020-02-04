using Library.Character;
using UnityEngine;

namespace Library.Events
{
    public class WallCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            LevelEnd.Instance.totalNegativeScore += LevelEnd.Instance.score / 10;
            other.GetComponentInChildren<WaypointMovement>().SwitchMaterial(0.3f);
        }
    }
}
