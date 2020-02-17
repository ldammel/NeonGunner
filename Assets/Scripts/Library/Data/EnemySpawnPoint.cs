using UnityEngine;

namespace Library.Data
{
        public class EnemySpawnPoint : MonoBehaviour
        {
                public Transform point;

                private void Awake()
                {
                        point = transform;
                }
        }
}
