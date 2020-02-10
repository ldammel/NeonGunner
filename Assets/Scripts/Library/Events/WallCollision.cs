using Library.Character;
using Library.Tools;
using UnityEngine;

namespace Library.Events
{
    public class WallCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            SoundManager.Instance.PlaySound("Disabled");
            LevelEnd.Instance.totalNegativeScore += LevelEnd.Instance.score / 10;
            other.GetComponentInChildren<WaypointMovement>().SwitchMaterial(0.3f);
            LevelEnd.Instance.enemiesKilled = 0;
        }
    }
}
