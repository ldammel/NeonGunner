using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Library.Combat
{
    public class Flamethrower : MonoBehaviour
    {
        [SerializeField] private GameObject flameFx;

        private void Update()
        {
            flameFx.SetActive(Input.GetKey(KeyCode.Mouse0));
        }
    }
}
