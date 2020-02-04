using UnityEngine;

namespace Library.Combat
{
    public class LookAt : MonoBehaviour
    {
        [SerializeField] private GameObject target;

        private void Start()
        {
            target = GameObject.Find("---PLAYER---/Player/Cube");
        }

        private void Update()
        {
            transform.LookAt(target.transform);
        }
    }
}
