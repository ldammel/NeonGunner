using UnityEngine;

namespace Library.Tools
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject objectToSpawn;
        [SerializeField] private Transform parent;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Instantiate(objectToSpawn, transform.position, transform.rotation, parent);
            }
        }
    }
}
