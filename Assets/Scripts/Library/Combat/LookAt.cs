using System;
using UnityEngine;

namespace Library.Combat
{
    public class LookAt : MonoBehaviour
    {
        [SerializeField] private GameObject target;

        private void Start()
        {
            target = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            transform.LookAt(target.transform);
        }
    }
}
